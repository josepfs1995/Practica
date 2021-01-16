import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { BaseModule } from "../base/base.module";
import { AutenticacionAppComponent } from "./autenticacion.app.component";
import { AutenticacionRoutingModule } from "./autenticacion.route";
import { LoginComponent } from "./login/login.component";
import { RegistrarComponent } from "./registrar/registrar.component";

@NgModule({
  declarations:[
    AutenticacionAppComponent,
    LoginComponent,
    RegistrarComponent
  ],
  imports:[
    CommonModule,
    AutenticacionRoutingModule,
    BaseModule,
    ReactiveFormsModule
  ],
  exports:[]
})
export class AutenticacionModule{

}