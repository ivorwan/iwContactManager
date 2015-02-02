(function () {
    var app = angular.module('winner-module', []);

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
        // private methods
        var get = function () {
            
            return $http.get("/api/Values/")
                        .then(
                            function (response) {
                                // this function still returns a promise that wraps response.data
                                return response.data;
                            });

        }

        // define public methods
        return {
            get : get
        };

    });

    app.controller('WinnersController', ['$http', '$scope', '$interval', '$log', 'winnerService', function ($http, $scope, $interval, $log, winnerService) {
        
        var timeoutId;
        $scope.winners = [];
        $scope.currentNotice = 0;

        // grabs data from external service
        winnerService.get().then(
            function (data) {
                $scope.winners = data;
            },
            function (errorPl) {
                $log.error('failure loading Winners', errorPl);
            });
        /* alternate solution without creating winners service */
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