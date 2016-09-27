﻿(function () {
    angular.module('ntdshop.products', ['ntdshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: '/app/compoments/products/productListView.html',
            controller: 'productListController'
        }).state('products_add', {
            url: '/products_add',
            templateUrl: '/app/compoments/products/productAddView.html',
            controller: 'productAddController'
        });
    }


})();