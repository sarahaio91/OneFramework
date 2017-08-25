System.register(["angular2/core", "rxjs/Observable", "angular2/http"], function (exports_1, context_1) {
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
    var core_1, Observable_1, http_1, NewsService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            }
        ],
        execute: function () {
            NewsService = class NewsService {
                constructor(_http) {
                    this._http = _http;
                    //private _newsUrl = 'api/news/news.json';
                    this._newsUrl = 'http://localhost:56081/api/news';
                }
                getListNews() {
                    return this._http.get(this._newsUrl)
                        .map((response) => response.json())
                        .do(data => console.log('All: ' + JSON.stringify(data)))
                        .catch(this.handleError);
                }
                getNews(id) {
                    return this._http.get(this._newsUrl + "/" + id)
                        .map((response) => response.json())
                        .do(data => console.log('One: ' + JSON.stringify(data)))
                        .catch(this.handleError);
                }
                handleError(error) {
                    console.error('Test: ' + error);
                    return Observable_1.Observable.throw(error.json().error || 'Server error');
                }
            };
            NewsService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [http_1.Http])
            ], NewsService);
            exports_1("NewsService", NewsService);
        }
    };
});
//# sourceMappingURL=news.service.js.map