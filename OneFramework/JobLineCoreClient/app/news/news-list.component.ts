import {Component, OnInit} from 'angular2/core';
import {ROUTER_DIRECTIVES} from 'angular2/router';
import {INews} from './news';
import {NewsService } from './news.service';


@Component({
    selector: 'pm-news',
    templateUrl: 'app/news/news-list.component.html',
    styleUrls: ['app/news/news-list.component.css'],
    directives: [ROUTER_DIRECTIVES]
})
export class NewsListComponent implements OnInit{
    pageTitle: string = "List news";
    newsList: INews[];
    ErrorMessage: string;

    constructor(private _newsService:NewsService){

    }
    ngOnInit(): void{
        //call server here
        this._newsService.getListNews()
            .subscribe(news => this.newsList = news, error => this.ErrorMessage = <any>error);
    }
}