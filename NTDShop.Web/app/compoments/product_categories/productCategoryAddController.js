(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    function productCategoryAddController() {
        $scope.productCategory = {
            CreatedDate:new Date()
        }
    }
})(angular.module('ntdshop.product_categories'));