(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {

        $scope.product = {
            CreatedDate: new Date(),
            Name:'San pham moi'
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }
        function productLoadCategory() {

            apiService.get('api/productCategory/getallParents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }
        $scope.ChosseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        productLoadCategory();
    }
    
})(angular.module('ntdshop.products'))