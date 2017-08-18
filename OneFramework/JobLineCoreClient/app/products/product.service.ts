import {Injectable} from 'angular2/core';
import {IProduct} from './product';
import {Observable} from 'rxjs/Observable';
import {Http, Response} from 'angular2/http';

@Injectable()
export class ProductService{
    private _productUrl = 'api/products/products.json';
    private _serviceUrl = 'http://localhost:56506/api/values';

    constructor(private _http : Http){}

    getProducts() : Observable<IProduct[]>{
        return this._http.get(this._serviceUrl)
            .map((response : Response) => <IProduct[]> response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error:Response){
        console.error('Test: '+error);
        return Observable.throw(error.json().error || 'Server error');
        
    }

    getProductDetail(id:number) : IProduct{
        return;
    }
}