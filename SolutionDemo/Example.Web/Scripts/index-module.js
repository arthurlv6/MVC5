var indexModule = angular.module("indexModule", ['ngRoute', 'ngResource'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Index/Home', { templateUrl: '/templates/home.html', controller: 'HomeController' });
        $routeProvider.when('/Index/About', { templateUrl: '/templates/about.html', controller: 'AboutController' });
        $routeProvider.when('/Index/Contact', { templateUrl: '/templates/contact.html', controller: 'ContactController' });
        $locationProvider.html5Mode(true);
    });