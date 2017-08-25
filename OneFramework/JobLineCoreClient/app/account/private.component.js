System.register(["angular2/core", "./account.service"], function (exports_1, context_1) {
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
    var core_1, account_service_1, PrivateComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (account_service_1_1) {
                account_service_1 = account_service_1_1;
            }
        ],
        execute: function () {
            PrivateComponent = class PrivateComponent {
                constructor(_service) {
                    this._service = _service;
                }
                ngOnInit() {
                    this._service.checkCredentials();
                }
                logout() {
                    this._service.logout();
                }
            };
            PrivateComponent = __decorate([
                core_1.Component({
                    selector: 'login-form',
                    providers: [account_service_1.AuthenticatedService],
                    template: `
            <div class="container" >
                <div class="content">
                    <span>Congratulations, you have successfully logged in!!</span>
                    <br />
                    <a (click)="logout()" href="#">Click Here to logout</a>
                </div>
            </div>
    	`
                }),
                __metadata("design:paramtypes", [account_service_1.AuthenticatedService])
            ], PrivateComponent);
            exports_1("PrivateComponent", PrivateComponent);
        }
    };
});
//# sourceMappingURL=private.component.js.map