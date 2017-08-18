import {Component} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';
import {ROUTER_PROVIDERS, RouteConfig, ROUTER_DIRECTIVES, APP_BASE_HREF} from 'angular2/router';
import 'rxjs/Rx';

import {ProductListComponent} from './products/product-list.component';
import {WelcomeComponent} from './home/welcome.component';
import {ProductService} from './products/product.service';
import {NewsService } from './news/news.service';
import {ProductDetailComponent} from './products/product-detail.component';
import {NewsListComponent} from './news/news-list.component';
import {NewsDetailComponent} from './news/news-detail.component';
import {LoginComponent} from './account/login.component';
import {PrivateComponent} from './account/private.component';

@Component({
    selector:'pm-app',
    template:`
    <div>
        <nav class="navbar navbar-default">
            <div class="container-fluid">            
                <a class="navbar-brand">{{pageTitle}}</a>
                <ul class="nav navbar-nav">
                    <li><a [routerLink]="['Welcome']">Home</a></li> 
                    <li><a [routerLink]="['Products']">Products</a></li>
                    <li><a [routerLink]="['News']">News</a></li>
                    <li><a [routerLink]="['Login']">Login</a></li> 
                </ul>
            </div>
        </nav>
        <div class="container">
            <router-outlet></router-outlet>
        </div>
    </div>
    `,
    directives: [ProductListComponent, ROUTER_DIRECTIVES],
    providers: [ProductService, HTTP_PROVIDERS, ROUTER_PROVIDERS, NewsService]
})

@RouteConfig([
    { path: '/welcome', name: 'Welcome', component: WelcomeComponent},
    { path: '/products', name: 'Products', component: ProductListComponent },
    { path: '/product/:id', name: 'ProductDetail', component: ProductDetailComponent},
    { path: '/news', name:'News', component:NewsListComponent},
    { path: '/news/:id', name: 'NewsDetail', component: NewsDetailComponent},
    { path: '/home', name: 'Home', component: PrivateComponent, useAsDefault:true },
    { path: '/login', name: 'Login', component: LoginComponent }
])

export class AppComponent {
    pageTitle: string = "Hello Creators!";
}