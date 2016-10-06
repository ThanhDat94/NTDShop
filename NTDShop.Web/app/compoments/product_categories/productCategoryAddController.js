(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject=['$scope','apiService','notificationService','$state']

    function productCategoryAddController($scope,apiService,notificationService,$state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            Name:'Danh mục 1'
        }
        $scope.parentCategories = []

        $scope.AddProductCategory = AddProductCategory;
        function AddProductCategory() {
            apiService.post('api/productCategory/Create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được thêm mới thành công');
                    $state.go('product_categories');
                },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                })
        }

        function loadParentCategory() {
            apiService.get('api/productCategory/getallParents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        loadParentCategory();
    }
})(angular.module('ntdshop.product_categories'));