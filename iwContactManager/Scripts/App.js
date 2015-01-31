(function () {
    var app = angular.module('iwContactManager', ['ngAnimate']);
    app.value('$', $);

    app.service('signalRSvc', function ($, $rootScope) {
        var proxy = null;

        var initialize = function () {
            //Getting the connection object
            connection = $.hubConnection();

            //Creating proxy
            this.proxy = connection.createHubProxy('chatHub');

            //Starting connection
            connection.start();
            //Publishing an event when server pushes a greeting message
            this.proxy.on('broadcastMessage', function (name, message) {
                $rootScope.$emit("broadcastMessage", name, message);
            });
        };

        var sendRequest = function (name, message) {
            //console.log('sendRequest - name: ' + name + ' - message: ' + message);
            //Invoking greetAll method defined in hub
            this.proxy.invoke('Send', name, message);
        };

        return {
            initialize: initialize,
            sendRequest: sendRequest
        };
    });


    
    app.controller('ChatController', function ($scope, signalRSvc, $rootScope) {
    
        //console.log('chat controller');
        $scope.discussion = [];

        $scope.submitName = function () {
            //console.log('sumit name');
        }
        $scope.greetAll = function () {
            //console.log('greetAll - $scope.name: ' + $scope.name + ' this.name: ' + this.name + '- $rootScope.message: ' + $rootScope.message);
            signalRSvc.sendRequest(this.name, this.message);
        }

        updateGreetingMessage = function (name, message) {
            //console.log('updateGreetingMessage');
            var msg = { "name": name, "message": message };
            //console.log('pushing msg: ' + msg.name + ' : ' + msg.message);
            $scope.discussion.push(msg);
        }

        signalRSvc.initialize();

        //Updating greeting message after receiving a message through the event

        $scope.$parent.$on("broadcastMessage", function (e, name, message) {
            $scope.$apply(function () {
                //console.log('broadcastMessage - name: ' + name + ' - message: ' + message);
                updateGreetingMessage(name, message);
            });
        });
        
    });
    

    app.directive('noticeDirective', function () {
        return {
            scope: {
                index: '@',
                //isolatedBindingWinners: '=bindingWinners'
            },
            link: function (scope, element, attrs) {
            }
        }

    })

    app.controller('WinnersController', ['$http', '$scope', '$interval', function ($http, $scope, $interval) {
        //var store = this;
        var timeoutId;
        $scope.winners = [];
        $scope.currentNotice = 0;


        $http.get('/Api/Values').success(function (data) {
            $scope.winners = data;
        });

        timeoutId = $interval(function () {
            $scope.currentNotice++;
            if ($scope.currentNotice >= $scope.winners.length) $scope.currentNotice = 0;
            console.log($scope.currentNotice);
        }, 3000);

    }]);


})();
