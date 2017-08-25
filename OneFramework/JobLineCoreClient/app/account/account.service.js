System.register(["angular2/core", "angular2/router", "angular2/http", "rxjs/Observable"], function (exports_1, context_1) {
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
    var core_1, router_1, http_1, Observable_1, http_2, User, users, AuthenticatedService;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
                http_2 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }
        ],
        execute: function () {
            User = class User {
                constructor(email, password) {
                    this.email = email;
                    this.password = password;
                }
                ;
            };
            exports_1("User", User);
            users = [new User('oaile', '123456'), new User('namro', '123456')];
            AuthenticatedService = class AuthenticatedService {
                constructor(_router, _http) {
                    this._router = _router;
                    this._http = _http;
                    this._userUrl = 'http://localhost:56081/api/user';
                }
                logout() {
                    localStorage.removeItem('user');
                    this._router.navigate(['Login']);
                }
                login(user) {
                    // this._http.get(this._newsUrl+"/"+user)
                    // .map((response : Response) => <IUserInfo> response.json())
                    // .subscribe  (
                    //     data => {this._userInfo = data},
                    //     err => console.error(err),
                    //     ()=> console.log('Done')
                    // );
                    let headers = new http_2.Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
                    var params = new http_2.URLSearchParams();
                    params.set('Username', user.userName);
                    params.set('Password', user.password);
                    this._http.post(this._userUrl + "/login", params.toString(), { headers: headers }).map((response) => response.json())
                        .subscribe(data => { this._userInfo = data; }, err => console.error(err), () => console.log('Done'));
                    //var authenticatedUser = this._userInfo.Username === null;
                    if (this._userInfo.Username === user.Username) {
                        localStorage.setItem('user', JSON.stringify(this._userInfo));
                        //localStorage.setItem("user", authenticatedUser);
                        this._router.navigate(['Home']);
                        return true;
                    }
                }
                checkCredentials() {
                    if (localStorage.getItem('user') === null) {
                        this._router.navigate(["Login"]);
                    }
                }
                handleError(error) {
                    console.error('Test: ' + error);
                    return Observable_1.Observable.throw(error.json().error || 'Server error');
                }
            };
            AuthenticatedService = __decorate([
                core_1.Injectable(),
                __metadata("design:paramtypes", [router_1.Router, http_1.Http])
            ], AuthenticatedService);
            exports_1("AuthenticatedService", AuthenticatedService);
        }
    };
});
//# sourceMappingURL=account.service.js.map