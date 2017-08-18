import {Injectable} from 'angular2/core';
import {INews} from './news';
import {Observable} from 'rxjs/Observable';
import {Http, Response} from 'angular2/http';


@Injectable()
export class NewsService{
    //private _newsUrl = 'api/news/news.json';
    private _newsUrl = 'http://localhost:56081/api/news';

    constructor(private _http : Http){}

    getListNews() : Observable<INews[]>{
        return this._http.get(this._newsUrl)
            .map((response : Response) => <INews[]> response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    getNews(id):Observable<INews>{
        return this._http.get(this._newsUrl+"/"+id)
        .map((response : Response) => <INews> response.json())
        .do(data=>console.log('One: '+JSON.stringify(data)))
        .catch(this.handleError);
        
    }

     private handleError(error:Response){
        console.error('Test: '+error);
        return Observable.throw(error.json().error || 'Server error');
        
    }
}