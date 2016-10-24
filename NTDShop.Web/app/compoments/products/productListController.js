/// <reference path="productListController.js" />
(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.products = [];
        $scope.page = 0;
        $scope.totalCount = 0;
        $scope.pagesCount = 0;
        $scope.getProducts = getProducts;
        $scope.keyWord = '';
        $scope.search = search;

        $scope.deleteMultiple = deleteMultiple;
        $scope.selectedAll = selectedAll;

        $scope.deleteProduct = deleteProduct;

        $scope.$watch('products', function (n, o) {
            var checked = $filter('filter')(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.isAll = false;

        function selectedAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            })
            var config = {
                params: {
                    listIDs: JSON.stringify(listId)
                }
            }
            apiService.del('/api/product/deleteMulti', config, function (res) {
                notificationService.displaySuccess('Xóa thành công' + res.data + 'bản ghi');
                search();
            }, function (error) {
                notificationService.displayError('Xóa thất bại!');
            })
        }

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc chắn muốn xóa không ?').then(
                function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/product/delete', config, function () {
                        notificationService.displaySuccess('Xóa thành công !');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công !');
                    });
                });
        }
        function search() {
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không tìm thấy kết quả');
                }

                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }
        $scope.getProducts();
    }
})(angular.module('ntdshop.products'));