import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { FooterComponent } from "./footer/footer.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { MenuComponent } from "./menu/menu.component";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CollectionComponent } from "./collection/collection.component";
import { HttpClientModule } from "@angular/common/http";
import { MercaderiaModule } from "../mercaderia/mercaderia.module";
import { BaseModule } from "../base/base.module";
import { CarritoIconComponent } from "./carrito-icon/carrito-icon.component";
import { CarritoComponent } from "./carrito/carrito.component";
import { FavoritoIconComponent } from "./favorito-icon/favorito-icon.component";
import { LoginIconComponent } from "./login-icon/login-icon.component";
@NgModule({
    declarations:[ 
        HomeComponent,
        FooterComponent,
        NotFoundComponent,
        MenuComponent,
        CollectionComponent,
        CarritoIconComponent,
        CarritoComponent,
        FavoritoIconComponent,
        LoginIconComponent
    ],
    imports:[
        CommonModule,
        RouterModule,
        NgbModule,
        HttpClientModule,
        MercaderiaModule,
        BaseModule
    ],
    exports:[
        HomeComponent,
        FooterComponent,
        NotFoundComponent,
        MenuComponent, 
        BaseModule
    ]
})
export class NavegacionModule{

}