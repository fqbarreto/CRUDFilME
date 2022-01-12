import { Injectable } from '@angular/core';
import { FilmesDetail } from './filmes-detail.model'
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class FilmesDetailService {
  readonly baseUrl = 'https://localhost:7148/Filmes'
  constructor(private http:HttpClient) {

   }

  data:FilmesDetail = new FilmesDetail();
  filmesList:FilmesDetail[];
  deleteFilmeDetail(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
  postFilmeDetail(){
    return this.http.post(this.baseUrl, this.data);
  }
  putFilmeDetail(){
    return this.http.put(`${this.baseUrl}/${this.data.filmeId}`, this.data);
  }
  public contains(element:any){
    if (this.filmesList.includes(element)){
      return true;
    }
    else{
      return false;
    }
  }
  public refreshList(){
    this.http.get(this.baseUrl).toPromise()
    .then(res=>this.filmesList = res as FilmesDetail[]); 
  }
}

