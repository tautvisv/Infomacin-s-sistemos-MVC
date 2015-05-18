var App = angular.module('App', ['ngRoute']);

App.controller('LandingPageController', LandingPageController);
App.controller('LoginController', LoginController);
App.controller('RegisterController', RegisterController);

App.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
App.factory('LoginFactory', LoginFactory);
App.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/routeOne', {
            templateUrl: 'routesDemo/one'
        })
        .when('/routeTwo/:donuts', {
            templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
        })
        .when('/routeThree', {
            templateUrl: 'routesDemo/three',
        })
        .when('/login', {
            templateUrl: '/Account/Prisijungti',
            controller: LoginController
        })
        .when('/register', {
            templateUrl: '/Account/Register',
            controller: RegisterController
        });
    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
};

configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);