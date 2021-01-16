import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { MercaderiaDetalleComponent } from "./detalle/mercaderia.detalle.component";
import { MercaderiaListaComponent } from "./lista/mercaderia-lista.component";
import { MercaderiaAppComponent } from "./mercaderia.app.component";

const mercaderiaRouterConfig: Routes = [
    {
        path:'', component: MercaderiaAppComponent,
        children:[
            {
                path:'', component: MercaderiaListaComponent,
            },
            {
                path:'pantalon-jumper', component: MercaderiaListaComponent,
                data: {
                    filtro: ["8b2b3d2b-5eb4-460a-ac44-37f6c081bdd2",
                    "da623463-9123-4890-9193-350172843fb3"]
                }    
            },
            {
                path:'faldas-short', component: MercaderiaListaComponent,
                data: {
                    filtro: ["10deaf97-b2ad-4a52-8ad2-511082d4049c",
                    "7f5ba8d6-6af3-438e-8c19-1e45215b756b"]
                }    
            },
            {
                path:'toreros', component: MercaderiaListaComponent,
                data: {
                    filtro: ["fbe611c7-259d-4a2b-9b81-f0174a74b8ae"]
                }    
            },
            {
                path:'detalle/:id', component:MercaderiaDetalleComponent,
                data: {
                    breadcrumb: ""
                }
            }
        ]
    }
]
@NgModule({
    imports:[
        RouterModule.forChild(mercaderiaRouterConfig)
    ],
    exports: [RouterModule]
})
export class MercaderiaRoutingModule{

}