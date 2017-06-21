'use strict';
app.factory('listService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:62967/';
    var listServiceFactory = {};

    var _getList = function () {

        return $http.get(serviceBase + 'api/Jwt').then(function (results) {
            return results.data;
        });
    };

    listServiceFactory.getList = _getList;

    return listServiceFactory;

}]);