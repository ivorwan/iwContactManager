(function () {
    var app = angular.module('chat-module', []);


    app.service('signalRSvc', function ($rootScope) {
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
            $scope.messageForm.$setPristine();
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
})();