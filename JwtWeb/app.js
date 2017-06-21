var app = angular.module('JwtApp', ['ngRoute', 'LocalStorageModule']);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        controller: "homeController",
        templateUrl: "home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "login.html"
    });

    $routeProvider.when("/list", {
        controller: "listController",
        templateUrl: "list.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);