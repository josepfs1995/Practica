import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Categoria } from "../model/Categoria";
import { BaseService } from "./base.service";

@Injectable({
    providedIn:'root'
})
export class CategoriaService extends BaseService{
    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<Categoria[]>{
        return this.http.get<Categoria[]>(this.UrlServiceV1 + 'Categoria', this.obtenerHeaderJson())
                .pipe(
                    map(this.extraerData),
                    catchError(this.serviceError)
                );
    }
}