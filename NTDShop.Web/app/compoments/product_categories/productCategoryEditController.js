(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', 'apiService', 'notificationService','$stateParams', '$state','commonService']

    function productCategoryEditController($scope, apiService, notificationService, $stateParams, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.parentCategories = [];
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productCategory/getByID/' + $stateParams.id, null,
                function (res) {
                    $scope.productCategory = res.data;
                },
                function (er) {
                    notificationService.displayError(er.data);
                });
        }
        function UpdateProductCategory() {
            apiService.put('api/productCategory/Update',$scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + 'đã được cập nhật thành công');
                    $state.go('product_categories');
                },
                function (error) {
                    notificationService.displayError('Cập Nhật không thành công');
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
        loadProductCategoryDetail();
    }
})(angular.module('ntdshop.product_categories'));