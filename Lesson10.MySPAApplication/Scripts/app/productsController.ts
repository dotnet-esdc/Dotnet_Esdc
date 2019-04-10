class ProductsController implements ng.IController {

    public $onInit?(): void {
        this.loadData();
    }

    public $doCheck?(): void { }

    public $onChanges?(onChangesObj: ng.IOnChangesObject): void { }

    public $onDestroy?(): void { }

    public $postLink?(): void { }

    public collection: IProducts[] = [];

    public resultVal: number = 0;

    public element: IProducts = null;

    static $inject = ['$scope' , 'productsService'];
    public constructor(private $scope: ng.IScope, private prodSrv: ProductsService) {

    }

    private loadData(): void {
        this.prodSrv.GetCollection().then(res => {
            this.collection = res.data.map(m => m);
        });
    }

    public save(): void {
        this.prodSrv.PostElement(this.element).then(res => {
            this.loadData();
        });
    }

    public selectItem(product: IProducts): void {

        console.log(this.element);

        if (this.element == null || this.element.ID != product.ID) {
            this.element = {
                ID: product.ID,
                Name: product.Name,
                Rating: product.Rating
            };
            var totalSum = this.collection
                .map(item => item.Rating)
                .reduce((oldVal, nVal) => oldVal + nVal);

            var piece = product.Rating * 100 / totalSum;

            this.resultVal = piece;
        } else {
            this.element = null;
        }

        
    }
    
}
