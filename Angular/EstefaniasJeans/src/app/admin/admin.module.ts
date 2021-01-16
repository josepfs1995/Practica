import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { BaseModule } from "../base/base.module";
import { MercaderiaModule } from "../mercaderia/mercaderia.module";
import { AdminAppComponent } from "./admin.app.component";
import { AdminRoutingModule } from "./admin.route";
import { PedidoModule } from "./pedido/pedido.module";

@NgModule({
  declarations:[
    AdminAppComponent],
  imports:[CommonModule, 
    AdminRoutingModule, 
    BaseModule,
    PedidoModule,
    MercaderiaModule ],
  exports:[]
})
export class AdminModule{

}