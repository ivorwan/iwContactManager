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
        this.get = function () {
            return $http.get("/api/Values/");
        }
    });

    app.controller('WinnersController', ['$http', '$scope', '$interval', '$log', 'winnerService', function ($http, $scope, $interval, $log, winnerService) {
        
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