import {Component} from 'angular2/core';
import {RouteParams, Router} from 'angular2/router';

@Component({
    templateUrl: 'app/products/product-detail.component.html'
})

export class ProductDetailComponent{
    pageTitle:string = 'Product detail';
    constructor(private _routeParam : RouteParams, private _router : Router){
        let id = +this._routeParam.get('id');
        this.pageTitle += `: ${id}`;
    }

    onBack() : void{
        this._router.navigate(['Products']);
    }
    
}