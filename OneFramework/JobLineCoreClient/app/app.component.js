System.register(["angular2/core", "angular2/http", "angular2/router", "rxjs/Rx", "./products/product-list.component", "./home/welcome.component", "./products/product.service", "./news/news.service", "./products/product-detail.component", "./news/news-list.component", "./news/news-detail.component", "./account/login.component", "./account/private.component"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, http_1, router_1, product_list_component_1, welcome_component_1, product_service_1, news_service_1, product_detail_component_1, news_list_component_1, news_detail_component_1, login_component_1, private_component_1, AppComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (_1) {
            },
            function (product_list_component_1_1) {
                product_list_component_1 = product_list_component_1_1;
            },
            function (welcome_component_1_1) {
                welcome_component_1 = welcome_component_1_1;
            },
            function (product_service_1_1) {
                product_service_1 = product_service_1_1;
            },
            function (news_service_1_1) {
                news_service_1 = news_service_1_1;
            },
            function (product_detail_component_1_1) {
                product_detail_component_1 = product_detail_component_1_1;
            },
            function (news_list_component_1_1) {
                news_list_component_1 = news_list_component_1_1;
            },
            function (news_detail_component_1_1) {
                news_detail_component_1 = news_detail_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (private_component_1_1) {
                private_component_1 = private_component_1_1;
            }
        ],
        execute: function () {
            AppComponent = class AppComponent {
                constructor() {
                    this.pageTitle = "Hello Creators!";
                }
            };
            AppComponent = __decorate([
                core_1.Component({
                    selector: 'pm-app',
                    template: `
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
                    directives: [product_list_component_1.ProductListComponent, router_1.ROUTER_DIRECTIVES],
                    providers: [product_service_1.ProductService, http_1.HTTP_PROVIDERS, router_1.ROUTER_PROVIDERS, news_service_1.NewsService]
                }),
                router_1.RouteConfig([
                    { path: '/welcome', name: 'Welcome', component: welcome_component_1.WelcomeComponent },
                    { path: '/products', name: 'Products', component: product_list_component_1.ProductListComponent },
                    { path: '/product/:id', name: 'ProductDetail', component: product_detail_component_1.ProductDetailComponent },
                    { path: '/news', name: 'News', component: news_list_component_1.NewsListComponent },
                    { path: '/news/:id', name: 'NewsDetail', component: news_detail_component_1.NewsDetailComponent },
                    { path: '/home', name: 'Home', component: private_component_1.PrivateComponent, useAsDefault: true },
                    { path: '/login', name: 'Login', component: login_component_1.LoginComponent }
                ])
            ], AppComponent);
            exports_1("AppComponent", AppComponent);
        }
    };
});
//# sourceMappingURL=app.component.js.map