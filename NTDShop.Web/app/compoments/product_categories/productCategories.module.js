﻿(function () {
    angular.module('ntdshop.product_categories', ['ntdshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: '/products_categories',
            templateUrl: '/app/compoments/product_categories/productCategoryListView.html',
            controller: 'productCategoryListController'
        }).state('add_product_category', {
            url: '/add_product_category',
            templateUrl: '/app/compoments/product_categories/productCategoryAddView.html',
            controller: 'productCategoryAddController'
        });
    }


})();