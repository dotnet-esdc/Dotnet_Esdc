var ProductsController = /** @class */ (function () {
    function ProductsController($scope, prodSrv) {
        this.$scope = $scope;
        this.prodSrv = prodSrv;
        this.collection = [];
        this.resultVal = 0;
        this.element = null;
    }
    ProductsController.prototype.$onInit = function () {
        this.loadData();
    };
    ProductsController.prototype.$doCheck = function () { };
    ProductsController.prototype.$onChanges = function (onChangesObj) { };
    ProductsController.prototype.$onDestroy = function () { };
    ProductsController.prototype.$postLink = function () { };
    ProductsController.prototype.loadData = function () {
        var _this = this;
        this.prodSrv.GetCollection().then(function (res) {
            _this.collection = res.data.map(function (m) { return m; });
        });
    };
    ProductsController.prototype.save = function () {
        var _this = this;
        this.prodSrv.PostElement(this.element).then(function (res) {
            _this.loadData();
        });
    };
    ProductsController.prototype.selectItem = function (product) {
        console.log(this.element);
        if (this.element == null || this.element.ID != product.ID) {
            this.element = {
                ID: product.ID,
                Name: product.Name,
                Rating: product.Rating
            };
            var totalSum = this.collection
                .map(function (item) { return item.Rating; })
                .reduce(function (oldVal, nVal) { return oldVal + nVal; });
            var piece = product.Rating * 100 / totalSum;
            this.resultVal = piece;
        }
        else {
            this.element = null;
        }
    };
    ProductsController.$inject = ['$scope', 'productsService'];
    return ProductsController;
}());
//# sourceMappingURL=productsController.js.map