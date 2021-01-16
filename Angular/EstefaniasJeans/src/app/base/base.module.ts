import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { ImagePipe } from "../pipes/ImagePipe";
import { BaseAppComponent } from "./base.app.component";
import { BaseRoutingModule } from "./base.route";
import { BreadcrumbComponent } from "./breadcrumb/breadcrumb.component";
import { CartActionComponent } from "./cart-action/cart-action.component";
import { PreLoaderComponent } from "./pre-loader/pre-loader.component";
import { SliderComponent } from "./slider/slider.component";

@NgModule({
    declarations:[
        BaseAppComponent,
        SliderComponent, 
        CartActionComponent,
        PreLoaderComponent,
        BreadcrumbComponent,
        ImagePipe
    ],
    imports:[
        CommonModule,
        NgbModule,
        BaseRoutingModule
    ],
    exports:[SliderComponent, 
        CartActionComponent,
        PreLoaderComponent,
        BreadcrumbComponent,
        ImagePipe]
})
export class BaseModule{

}