var ProductsService = /** @class */ (function () {
    function ProductsService($http) {
        this.$http = $http;
        this._url = "/api/Products";
    }
    ProductsService.prototype.GetCollection = function () {
        return this.$http({
            url: this._url,
            method: 'GET'
        });
    };
    ProductsService.prototype.GetElement = function (id) {
        return null;
    };
    ProductsService.prototype.PostElement = function (product) {
        return this.$http({
            url: this._url,
            method: 'POST',
            data: product
        });
    };
    ProductsService.$inject = ['$http'];
    return ProductsService;
}());
//# sourceMappingURL=productsService.js.map