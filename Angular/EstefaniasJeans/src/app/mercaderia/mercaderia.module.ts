import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import {  NgModule } from "@angular/core";
import { MercaderiaDetalleComponent } from "./detalle/mercaderia.detalle.component";
import { MercaderiaCardComponent } from "./card/mercaderia-card.component";
import { MercaderiaRoutingModule } from "./mercaderia.route";
import { MercaderiaAppComponent } from "./mercaderia.app.component";
import { ImagePipe } from "../pipes/ImagePipe";
import { BaseModule } from "../base/base.module";
import { MercaderiaListaComponent } from "./lista/mercaderia-lista.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { OrderByPipe } from "../pipes/OrderByPipe";

@NgModule({
    declarations:[
        MercaderiaAppComponent,
        MercaderiaCardComponent,
        MercaderiaDetalleComponent,
        MercaderiaListaComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        MercaderiaRoutingModule,
        BaseModule,
        NgbModule
    ],
    providers:[
        ImagePipe,
        OrderByPipe
    ],
    exports:[
        MercaderiaCardComponent, 
        BaseModule
    ]
})
export class MercaderiaModule{

}