/*
 * MVVM
 * M - Model
 * V - View
 * VM - ViewModel
 * 
 * JQuery - MVP (Model View Presenter)
 * 
 */

angular
    .module('my-app-module', [])
    .controller('my-app-controller', function ($scope, $http) {

        $scope.productCollection = [];

        $scope.Id = 0;
        $scope.Name = "sd";
        $scope.Price = 100;

        $scope.currentItem = {
            Id: 0,
            Name: 'default',
            Price: 100
        };

        // 1 - create 
        // 2 - update
        // 3 - delete
        $scope.actionFlat = 0;

        $scope.create = function () {
            $scope.currentItem = {
                Id: 0,
                Name: 'default',
                Price: 0
            };
            $scope.actionFlat = 1;
        };

        $scope.update = function (item) {
            $scope.currentItem.Id = item.Id;
            $scope.currentItem.Name = item.Name;
            $scope.currentItem.Price = item.Price;
            $scope.actionFlat = 2;
        };

        $scope.remove = function (item) {
            $scope.currentItem.Id = item.Id;
            $scope.currentItem.Name = item.Name;
            $scope.currentItem.Price = item.Price;
            $scope.actionFlat = 3;
        };

        $scope.getProducts = function () {
            $http({
                url: '/api/Products',
                method: 'get'
            }).then(function (response) {
                console.log('getProducts result', response);
                $scope.productCollection = response.data;
                });
        };

        $scope.saveChanges = function () {
            console.log('save changes', $scope.actionFlat);

            switch ($scope.actionFlat) {
                case 1: $scope.postProduct(); break;
                case 2: $scope.putProduct(); break;
                case 3: $scope.deleteProduct(); break;
                default: break;
            }

        };

        $scope.postProduct = function () {
            var data = {
                Id: $scope.currentItem.Id,
                Name: $scope.currentItem.Name,
                Price: $scope.currentItem.Price
            };

            $http({
                url: '/api/Products',
                method: 'post',
                data: data
            }).then(function (response) {
                $scope.getProducts();
            });
        };

        $scope.putProduct = function () {
            var data = {
                Id: $scope.currentItem.Id,
                Name: $scope.currentItem.Name,
                Price: $scope.currentItem.Price
            };

            $http({
                url: '/api/Products/' + data.Id,
                method: 'put',
                data: data
            }).then(function (response) {
                $scope.getProducts();
            });
        };

        $scope.deleteProduct = function () {
            $http({
                url: '/api/Products/' + $scope.currentItem.Id,
                method: 'delete'
            }).then(function (response) {
                $scope.getProducts();
            });
        };



    });