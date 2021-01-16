import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { BaseAppComponent } from "./base.app.component";

const baseRouterConfig: Routes = [
    {
        path:'', component: BaseAppComponent,
    }
]
@NgModule({
    imports:[
        RouterModule.forChild(baseRouterConfig)
    ],
    exports: [RouterModule]
})
export class BaseRoutingModule{

}