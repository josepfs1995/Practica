import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CrearComponent } from "./crear/crear.component";
import { EditarComponent } from "./editar/editar.component";
import { ListaComponent } from "./lista/lista.component";
import { MercaderiaAppComponent } from "./mercaderia.app.component";

const mercaderiaRouterConfig :Routes = [
  {
    path: "", component:MercaderiaAppComponent,
    children:[
      {
        path: '', component:ListaComponent,
        data: {
          breadcrumb: 'Lista'
        }
      },
      {
        path: 'crear', component:CrearComponent,
        data: {
          breadcrumb: 'Crear'
        }
      },
      {
        path: 'editar/:id', component: EditarComponent,
        data: {
          breadcrumb: 'Editar'
        }
      }
    ]
  }
]
@NgModule({
  imports:[
    RouterModule.forChild(mercaderiaRouterConfig)
  ],
  exports:[
    RouterModule
  ]
})
export class MercaderiaRoutingModule{

}