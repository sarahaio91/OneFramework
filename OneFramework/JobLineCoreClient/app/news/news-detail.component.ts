import {Component} from 'angular2/core';
import {RouteParams, Router} from 'angular2/router';
import {NewsService } from './news.service';
import {INews} from './news';

@Component({
    templateUrl: 'app/news/news-detail.component.html'
})

export class NewsDetailComponent{
    pageTitle: string = 'Detail news' ;
    news: INews;
    ErrorMessage: string;
    id : number;
    constructor(private _routeParams: RouteParams, private _router: Router, private _newsService: NewsService){
         this.id = +this._routeParams.get('id');
        this._newsService.getNews(this._routeParams.get('id'))
            .subscribe(news => this.news = news, error => this.ErrorMessage = <any>error);
    }
    // ngOnInit(): void{
    //     //call server here
    //     this._newsService.getNews(this.id)
    //         .subscribe(news => this.news = news, error => this.ErrorMessage = <any>error);
    // }
    onBack() : void{
        this._router.navigate(['News']);
    }
}

