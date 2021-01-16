import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AutenticacionAppComponent } from "./autenticacion.app.component";
import { LoginComponent } from "./login/login.component";
import { RegistrarComponent } from "./registrar/registrar.component";

const autenticacionRouterConfig: Routes = [
  {
      path:'', component: AutenticacionAppComponent,
      children:[
          {
            path:'', component: LoginComponent,
          },
         
          {
            path:'registrar', component: RegistrarComponent,
          }
      ]
  }
]
@NgModule({
  imports:[
    RouterModule.forChild(autenticacionRouterConfig)
  ],
  exports:[RouterModule]
})
export class AutenticacionRoutingModule{

}