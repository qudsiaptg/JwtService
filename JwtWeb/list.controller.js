'use strict';
app.controller('listController', ['$scope', 'listService', function ($scope, listService) {
    $scope.list = [];

    listService.getList().then(function (response) {
        $scope.list = response;
    });
}]);