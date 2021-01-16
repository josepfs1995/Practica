import { formatDate } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { TokenService } from "src/app/services/token.service";
import { AutenticacionService } from "../services/autenticacion.service";

@Component({
  selector:"app-registrar",
  templateUrl:"registrar.component.html"
})
export class RegistrarComponent implements OnInit{
  registrarForm !: FormGroup;
  errors:string[] = [];
  constructor(private fb: FormBuilder, 
            private autenticacionService: AutenticacionService,
            private tokenService: TokenService,
            private toast: ToastrService) {
    
  }
  ngOnInit(): void {
    this.registrarForm = this.fb.group({
      Email: new FormControl('',{
        validators:[
          Validators.required,
          Validators.email
        ]
      }),
      Contrasena: new FormControl('', {
        validators:[
          Validators.required
        ]
      },
      ),
      ConfirmarContrasena: new FormControl('', {
        validators:[
          Validators.required
        ]
      }),
      Persona:  new FormGroup({
        Nombres: new FormControl('', {
          validators:[
            Validators.required
          ]
        }),
        Apellidos: new FormControl('', {
          validators:[
            Validators.required
          ]
        }),
        FechaNacimiento: new FormControl(formatDate(new Date(), "yyyy-MM-dd", 'en-US'), {
          validators:[
            Validators.required
          ]
        }),
        Direccion1: new FormControl('', {
          validators:[
            Validators.required
          ]
        }),
        Direccion2: new FormControl(''),
        Documento: new FormControl('', {
          validators:[
            Validators.required
          ]
        }),
        Celular: new FormControl('', {
          validators:[
            Validators.required
          ]
        })
      })
    });
  }
  registrar():void{
    if(this.registrarForm.valid){
      let values = this.registrarForm.value;
      this.autenticacionService.registrar(values)
      .subscribe(
        success => {this.procesarSuccess(success); },
        error => {this.procesarError(error); }
      );
    }
    else{
      this.toast.error("Debes completar con los datos obligatorios");
    }
  }
  procesarSuccess(response:any):void{
    this.tokenService.guardarToken(response);
    window.location.href="/";
  }
  procesarError(fail:any):void{
    this.errors = [];
    this.toast.error("Ocurrio un error");
    fail.error.Errors.forEach((error:string) => {
      this.errors.push(error);
    }); 
  }
}