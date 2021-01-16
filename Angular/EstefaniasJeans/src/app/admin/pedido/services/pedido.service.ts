import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { BaseService } from "src/app/services/base.service";
import { TokenService } from "src/app/services/token.service";
import { ObtenerPedido } from "../model/ObtenerPedido";
import { Pedido } from "../model/Pedido";

@Injectable({
    providedIn: 'root'
})
export class PedidoService extends BaseService{
    constructor(private http:HttpClient,
        private tokenService:TokenService) {
        super();
    }
    crear(pedido:Pedido):Observable<any>{
        return this.http.post(this.UrlServiceV1 + "Pedido", pedido, this.obtenerHeaderJson(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken));
    }
    get():Observable<ObtenerPedido[]>{
        return this.http.get<Pedido>(this.UrlServiceV1 + 'Pedido', this.obtenerHeaderJson(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken))
        .pipe(
            map(this.extraerData),
            catchError(this.serviceError)
        );
    }
    getById(id:string):Observable<ObtenerPedido>{
        return this.http.get<Pedido>(this.UrlServiceV1 + 'Pedido/'+ id, this.obtenerHeaderJson(this.tokenService.estaConectado(), this.tokenService.obtenerToken()?.AccessToken))
        .pipe(
            map(this.extraerData),
            catchError(this.serviceError)
        );
    }
}