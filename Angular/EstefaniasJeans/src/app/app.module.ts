import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavegacionModule } from './navegacion/navegacion.module';
import { MercaderiaModule } from './mercaderia/mercaderia.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from './services/app.guard';
import { AdminModule } from './admin/admin.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavegacionModule,
    MercaderiaModule,
    AdminModule,
    NgbModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({closeButton:true})
  ],
  providers: [
    AuthGuard],
  bootstrap: [AppComponent],
})
export class AppModule { }
