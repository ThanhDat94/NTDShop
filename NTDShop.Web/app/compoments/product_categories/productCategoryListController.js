/// <reference path="productListController.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService','$ngBootbox'];

    function productCategoryListController($scope, apiService, notificationService,$ngBootbox) {

        $scope.productCategories = [];
        $scope.page = 0;
        $scope.totalCount = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyWord = '';
        $scope.search = search;

        $scope.deleteProductCategory = deleteProductCategory;
        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa không ?').then(
                function () {
                    var config={
                        params: {
                            id:id
                        }
                    }
                    apiService.del('/api/productCategory/delete', config, function () {
                        notificationService.displaySuccess('Xóa thành công !');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thàn công !');
                    });
                });
        }
        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord:$scope.keyWord,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/productCategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả');
                }
  
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('ntdshop.product_categories'));