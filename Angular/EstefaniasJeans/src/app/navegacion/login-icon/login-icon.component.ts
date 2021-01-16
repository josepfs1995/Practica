import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { UsuarioRespuesta } from "src/app/autenticacion/model/UsuarioRespuesta";
import { TokenService } from "src/app/services/token.service";

@Component({
  selector: "app-login-icon",
  templateUrl:"login-icon.component.html"
})
export class LoginIconComponent implements OnInit{
  logueado:boolean = false;
  usuarioRespuesta: any;
  constructor(private tokenService: TokenService,
              private toastr: ToastrService) {
    
  }
  ngOnInit(): void {
    this.logueado = this.tokenService.estaConectado();
    if(this.logueado){
      this.usuarioRespuesta = this.tokenService.obtenerToken();
      
    }
  }

  salir():void{
    this.tokenService.limpiarToken();
    this.logueado = false;
    this.toastr.success("Gracias por conectarte, vuelve pronto!");
  }
}