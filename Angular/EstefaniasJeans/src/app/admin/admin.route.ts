import { NgModule } from "@angular/core";
import {  RouterModule, Routes } from "@angular/router";
import { AdminAppComponent } from "./admin.app.component";

const adminRouterConfig:Routes = [
  {
    path: '', component:AdminAppComponent,
    children:[
      {
        path: 'pedido', 
        loadChildren: () => import("./pedido/pedido.module")
          .then(m=>m.PedidoModule),
        data:{
          breadcrumb:"Pedido"
        }
      },
      {
        path:'mercaderia',
        loadChildren: () => import("./mercaderia/mercaderia.module")
          .then(m=>m.MercaderiaModule),
        data:{
          breadcrumb: "Mercaderia"
        }
      }
    ]
  }
]
@NgModule({
  imports:[
    RouterModule.forChild(adminRouterConfig)
  ],
  exports:[
    RouterModule
  ]
})
export class AdminRoutingModule{

}