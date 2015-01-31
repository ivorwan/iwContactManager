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
            //Invoking Send method defined in ChatHub
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
        $scope.nameIsSet = false;
        $scope.submitName = function () {
            $scope.nameIsSet = true;
            //console.log('sumit name');
        }
        $scope.sendMessage = function () {
            //console.log('sendMessage - $scope.name: ' + $scope.name + ' this.name: ' + this.name + '- $rootScope.message: ' + $rootScope.message);
            signalRSvc.sendRequest(this.name, this.message);
            this.message = '';
        }

        updateDiscussionMessages = function (name, message) {
            //console.log('updateDiscussionMessages');
            var msg = { "name": name, "message": message };
            //console.log('pushing msg: ' + msg.name + ' : ' + msg.message);
            $scope.discussion.push(msg);
        }

        signalRSvc.initialize();

        //Updating discussion message after receiving a message through the event

        $scope.$parent.$on("broadcastMessage", function (e, name, message) {
            $scope.$apply(function () {
                //console.log('broadcastMessage - name: ' + name + ' - message: ' + message);
                updateDiscussionMessages(name, message);
            });
        });
        
    });
    
    ///===================================================================================
    // winners
    ///===================================================================================
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
   

    
    // winners external service
    app.service('winnerService', function ($http) {
        this.get = function () {
            return $http.get("/api/Values/");
        }
    });

    app.controller('WinnersController', ['$http', '$scope', '$interval', '$log', 'winnerService', function ($http, $scope, $interval, $log, winnerService) {
        //var store = this;
        var timeoutId;
        $scope.winners = [];
        $scope.currentNotice = 0;

        var promiseGet = winnerService.get(); //The Method Call from service

        promiseGet.then(
            function (pl) {
                $scope.winners = pl.data;
            },
            function (errorPl) {
                $log.error('failure loading Winners', errorPl);
            });
        /*
        $http.get('/Api/Values').success(function (data) {
            $scope.winners = data;
        });
        */
        timeoutId = $interval(function () {
            $scope.currentNotice++;
            if ($scope.currentNotice >= $scope.winners.length) $scope.currentNotice = 0;
            console.log($scope.currentNotice);
        }, 3000);

    }]);


})();
