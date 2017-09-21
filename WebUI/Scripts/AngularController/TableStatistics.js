var app = angular.module("Homeapp", ['ui.bootstrap']);

app.controller("StatisticController", function ($scope, $http) {
    $scope.maxsize = 3;
    $scope.totalcount = 0;
    $scope.pageIndex = 1;
    $scope.pageSize = 3;

    $scope.registerlist = function () {
        $http.get("/Statistic/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.registerdata = response.data.registerdata;
            $scope.totalcount = response.data.totalcount;
        }, function (error) {
            alert('failed');
        });
    }

    $scope.registerlist();

    $scope.pagechanged = function () {
        $scope.registerlist();
    }

    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.registerlist();
    }
});