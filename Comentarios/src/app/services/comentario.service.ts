import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comentario } from '../interfaces/Comentario';

@Injectable({
  providedIn: 'root'
})
export class ComentarioService {

  private myAppUrl = "http://localhost:14113/";
  private myApiUrl = "api/Comentario/"

  constructor(private http: HttpClient) { }

  getComntario(id:number): Observable<any>{
    return this.http.get(this.myAppUrl+this.myApiUrl+id);
  }

  getListComentarios(): Observable<any>{
    return this.http.get(this.myAppUrl+this.myApiUrl);
  }

  saveComentario(comentario: Comentario): Observable<any>{
    return this.http.post(this.myAppUrl+this.myApiUrl,comentario);
  }

  deletecomentario(id:number): Observable<any>{
    return this.http.delete(this.myAppUrl+this.myApiUrl+id)
  }

  editComentario(id:number,comentario: Comentario):Observable<any>
  {
    return this.http.put(this.myAppUrl+this.myApiUrl+id, comentario)
  }
}
