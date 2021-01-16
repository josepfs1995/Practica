import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { BaseService } from "src/app/services/base.service";
import { Usuario } from "../model/Usuario";
import { UsuarioRespuesta } from "../model/UsuarioRespuesta";

@Injectable({
  providedIn: 'root'
})
export class AutenticacionService extends BaseService{
  constructor(private http: HttpClient) {
    super();
  }
  login(usuario:Usuario):Observable<UsuarioRespuesta>{
    return this.http.post(this.UrlServiceV1 + "token/login", usuario, this.obtenerHeaderJson()).pipe(
      map(this.extraerData),
      catchError(this.serviceError)
    );
  }
  registrar(usuario:Usuario):Observable<UsuarioRespuesta>{
    return this.http.post(this.UrlServiceV1 + "token/cuenta-nueva", usuario, this.obtenerHeaderJson()).pipe(
      map(this.extraerData),
      catchError(this.serviceError)
    );
  }
}