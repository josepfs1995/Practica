import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { BaseService } from "src/app/services/base.service";
import { TokenService } from "src/app/services/token.service";
import { CrearMercaderia } from "../model/CrearMercaderia";
import { EditarMercaderia } from "../model/EditarMercaderia";
import { Mercaderia } from "../model/Mercaderia";

@Injectable({
    providedIn:'root'
})
export class MercaderiaService extends BaseService{

    constructor(private http: HttpClient,
                private tokenService: TokenService) {
        super();
    }
    crear(mercaderia: CrearMercaderia):Observable<CrearMercaderia>{
        return this.http.post<CrearMercaderia>(this.UrlServiceV1+"Mercaderia",mercaderia, this.obtenerHeaderJson(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken));
    }
    editar(mercaderia: EditarMercaderia):Observable<EditarMercaderia>{
        return this.http.put<EditarMercaderia>(this.UrlServiceV1+"Mercaderia",mercaderia, this.obtenerHeaderJson(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken));
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
    remove(id:string): Observable<Mercaderia>{
        return this.http.delete<Mercaderia>(this.UrlServiceV1 + 'Mercaderia/'+id, this.obtenerHeaderJsonDelete(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken))
            .pipe(map(this.extraerData),
                catchError(this.serviceError));
    }
}