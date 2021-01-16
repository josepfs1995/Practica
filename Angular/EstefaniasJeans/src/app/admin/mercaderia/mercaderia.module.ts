import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { NgxDropzoneModule } from "ngx-dropzone";
import { BaseModule } from "src/app/base/base.module";
import { ListaComponent } from "../mercaderia/lista/lista.component";
import { CrearComponent } from "./crear/crear.component";
import { EditarComponent } from "./editar/editar.component";
import { MercaderiaAppComponent } from "./mercaderia.app.component";
import { MercaderiaRoutingModule } from "./mercaderia.route";

@NgModule({
  declarations:[MercaderiaAppComponent, ListaComponent, CrearComponent, EditarComponent],
  imports:[CommonModule, MercaderiaRoutingModule, ReactiveFormsModule, BaseModule,NgxDropzoneModule],
  exports:[]
})
export class MercaderiaModule{

}