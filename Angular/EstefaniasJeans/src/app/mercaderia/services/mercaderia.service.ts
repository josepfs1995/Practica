import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "src/app/services/base.service";
import { Mercaderia } from "../models/mercaderia";
import { catchError, map } from 'rxjs/operators';

@Injectable({
    providedIn:"root"
})
export class MercaderiaService extends BaseService{

    constructor(private http:HttpClient) {
        super();
    }

    get(): Observable<Mercaderia[]>{
        return this.http.get(this.UrlServiceV1 + 'Mercaderia', this.obtenerHeaderJson())
                    .pipe(
                        map(this.extraerData),
                        catchError(this.serviceError)
                    );
    }
    getById(id:string): Observable<Mercaderia>{
        return this.http.get<Mercaderia>(this.UrlServiceV1 + 'Mercaderia/'+ id, this.obtenerHeaderJson())
                    .pipe(map(this.extraerData),
                            catchError(this.serviceError));
    }
}