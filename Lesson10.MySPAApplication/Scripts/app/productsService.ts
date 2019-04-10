class ProductsService {

    private _url: string = "/api/Products";

    public GetCollection(): ng.IHttpPromise<IProducts[]> {
        return this.$http({
            url: this._url,
            method: 'GET'
        });
    }

    public GetElement(id: number): ng.IHttpPromise<IProducts> {
        return null;
    }

    public PostElement(product: IProducts): ng.IHttpPromise<null> {
        return this.$http({
            url: this._url,
            method: 'POST',
            data: product
        });
    }

    static $inject = ['$http']
    public constructor(private $http: ng.IHttpService) {

    }

}