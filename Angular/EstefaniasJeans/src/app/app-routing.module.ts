import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarritoComponent } from './navegacion/carrito/carrito.component';
import { HomeComponent } from './navegacion/home/home.component';
import { NotFoundComponent } from './navegacion/not-found/not-found.component';
import { AuthGuard } from './services/app.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'mercaderias', 
    loadChildren: () => import("./mercaderia/mercaderia.module")
    .then(m=> m.MercaderiaModule),
    data:{
      breadcrumb: "Mercaderias"
    }
  },
  { 
    path: 'admin', 
    loadChildren: () => import("./admin/admin.module")
    .then(m=> m.AdminModule),
    canLoad:[AuthGuard],
    data:{
      breadcrumb:"Administrador"
    }
  },
  { 
    path: 'carrito', 
    component:CarritoComponent,
    data:{
      breadcrumb: "Carrito"
    }
  },
  { 
    path: 'autenticacion', 
    loadChildren: () => import("./autenticacion/autenticacion.module")
    .then(m=> m.AutenticacionModule),
    data:{
      breadcrumb: "Autenticacion"
    }
  },
  { path: '**', redirectTo: '/not-found'},
  { path: 'not-found', component: NotFoundComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
