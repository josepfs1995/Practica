import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { BaseModule } from "src/app/base/base.module";
import { DetalleComponent } from "./detalle/detalle.component";
import { ListaComponent } from "./lista/lista.component";
import { PedidoAppComponent } from "./pedido.app.component";
import { PedidoRoutingModule } from "./pedido.route";

@NgModule({
  declarations:[
    PedidoAppComponent,
    ListaComponent,
    DetalleComponent
  ],
  imports:[CommonModule, PedidoRoutingModule, BaseModule],
  exports:[]
})
export class PedidoModule{

}