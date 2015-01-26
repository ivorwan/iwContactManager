(function () {
    var app = angular.module('iwContactManager', ['ngAnimate']);

    app.directive('noticeDirective', function () {
        return {
            scope: {
                index: '@',
                isolatedBindingWinners: '=bindingWinners'
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
