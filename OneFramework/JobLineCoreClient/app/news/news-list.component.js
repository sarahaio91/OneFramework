System.register(["angular2/core", "angular2/router", "./news.service"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, router_1, news_service_1, NewsListComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (news_service_1_1) {
                news_service_1 = news_service_1_1;
            }
        ],
        execute: function () {
            NewsListComponent = class NewsListComponent {
                constructor(_newsService) {
                    this._newsService = _newsService;
                    this.pageTitle = "List news";
                }
                ngOnInit() {
                    //call server here
                    this._newsService.getListNews()
                        .subscribe(news => this.newsList = news, error => this.ErrorMessage = error);
                }
            };
            NewsListComponent = __decorate([
                core_1.Component({
                    selector: 'pm-news',
                    templateUrl: 'app/news/news-list.component.html',
                    styleUrls: ['app/news/news-list.component.css'],
                    directives: [router_1.ROUTER_DIRECTIVES]
                }),
                __metadata("design:paramtypes", [news_service_1.NewsService])
            ], NewsListComponent);
            exports_1("NewsListComponent", NewsListComponent);
        }
    };
});
//# sourceMappingURL=news-list.component.js.map