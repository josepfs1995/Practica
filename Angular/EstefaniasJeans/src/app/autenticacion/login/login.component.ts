import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { TokenService } from "src/app/services/token.service";
import { Usuario } from "../model/Usuario";
import { AutenticacionService } from "../services/autenticacion.service";

@Component({
  selector: "app-login",
  templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup;
  usuario!:Usuario;
  errors:string[] = [];
  returnUrl !:string;
  constructor(private fb: FormBuilder, 
            private router: ActivatedRoute,
            private autenticacionService: AutenticacionService,
            private tokenService: TokenService,
            private toast: ToastrService) {
    
  }
  ngOnInit(): void {
    this.loginForm = this.fb.group({
      Email: new FormControl(''),
      Contrasena: new FormControl('')
    });
    this.router.params.subscribe(param =>{
      this.returnUrl = param["returnUrl"];
    })
  }
  login():void{
    if(this.loginForm.dirty && this.loginForm.valid){
      this.usuario = Object.assign({}, this.loginForm.value);
      this.autenticacionService.login(this.usuario)
      .subscribe(
        success => {
          this.procesarSuccess(success);
        },
        error => { 
          this.procesarError(error);
        }
      );
    }
  }
  procesarSuccess(response:any):void{
    this.tokenService.guardarToken(response);
    window.location.href= this.returnUrl ?? "/";
  }
  procesarError(fail:any):void{
    this.errors = [];
    this.toast.error("Ocurrio un error");
    fail.error.Errors.forEach((error:string) => {
      this.errors.push(error);
    }); 
  }
}