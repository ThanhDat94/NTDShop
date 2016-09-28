/// <reference path="productListController.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope,apiService) {

        $scope.productCategories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {
            apiService.get('/api/productCategory/getall', null, function (res) {
                $scope.productCategories = res.data;
            }
                , function () {
                    console.log('Load product categories Failed.');
                });
        }
        $scope.getProductCategories();
    }
})(angular.module('ntdshop.product_categories'))