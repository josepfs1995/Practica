import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { UsuarioRespuesta } from "../autenticacion/model/UsuarioRespuesta";

@Injectable({
  providedIn: 'root'
})
export class TokenService{
  public subject = new Subject();
  suscribirse():Observable<any>{
    return this.subject.asObservable();
  }
  guardarToken(usuarioRespuesta: UsuarioRespuesta):void{
      sessionStorage.setItem("Usuario", JSON.stringify(usuarioRespuesta));
  }
  obtenerToken():UsuarioRespuesta | null{
      let json:string = sessionStorage.getItem("Usuario") ?? "json";
      return this.estaConectado() ? JSON.parse(json) : null;
  }
  estaConectado():boolean{
    let json:string = sessionStorage.getItem("Usuario") ?? "";
    return json != "";
  }
  limpiarToken():void{
      sessionStorage.removeItem("Usuario");
      this.subject.next(this.estaConectado());
  }
  esAdmin():boolean{
    let usuario = this.obtenerToken();
    return (usuario?.UsuarioToken?.Claims?.find(x=>x.Type === "role")?.Value ?? "") === "Administrador";
  }
}