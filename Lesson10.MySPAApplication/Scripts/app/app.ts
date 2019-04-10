interface IProducts {
    ID: number,
    Name: string,
    Rating?: number
}


angular
    .module('app', [])
    .service('productsService', ProductsService)
    .controller('productsController', ProductsController);

