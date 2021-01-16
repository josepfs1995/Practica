import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DetalleComponent } from "./detalle/detalle.component";
import { ListaComponent } from "./lista/lista.component";
import { PedidoAppComponent } from "./pedido.app.component";

const pedidoRoutingConfig: Routes = [
  {
    path: '', component:PedidoAppComponent,
    children:[
      {
        path:'', component:ListaComponent
      },
      {
        path:'detalle/:id', component:DetalleComponent,
        data:{
          breadcrumb:""
        }
      }
    ]
  }
]
@NgModule({
  imports:[ RouterModule.forChild(pedidoRoutingConfig)],
  exports:[
    RouterModule
  ]
})
export class PedidoRoutingModule{

}