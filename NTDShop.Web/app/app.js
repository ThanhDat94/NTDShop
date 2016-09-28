/// <reference path="/Assets/admin/libs/angular/angular.js" />


(function(){
    angular.module('ntdshop',
        ['ntdshop.products',
         'ntdshop.product_categories',
         'ntdshop.common'])
         .config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: '/admin',
            templateUrl: '/app/compoments/home/homeView.html',
            controller:'homeController'
        });
        $urlRouterProvider.otherwise('/admin');
    }


})();