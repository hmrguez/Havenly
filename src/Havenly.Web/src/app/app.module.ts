import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import { LoginComponent } from './auth/login/login.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { GraphQLModule } from './graphql.module';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TenantsComponent } from './tenants/tenants.component';
import {TableModule} from "primeng/table";
import { PropertiesComponent } from './properties/properties.component';
import {DataViewModule} from "primeng/dataview";
import {ButtonModule} from "primeng/button";
import {JwtHelperService, JwtModule} from "@auth0/angular-jwt";
import {environment} from "../environment/environment";
import {DropdownModule} from "primeng/dropdown";
import {DialogModule} from "primeng/dialog";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {InputTextModule} from "primeng/inputtext";
import {PaginatorModule} from "primeng/paginator";
import {CalendarModule} from "primeng/calendar";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    DashboardComponent,
    TenantsComponent,
    PropertiesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    GraphQLModule,
    TableModule,
    DataViewModule,
    ButtonModule,
    BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: [environment.backendUrl], // replace with your API domain
        disallowedRoutes: [], // add routes that should not attach the token
      },
    }),
    DropdownModule,
    DialogModule,
    ReactiveFormsModule,
    InputTextModule,
    PaginatorModule,
    CalendarModule,
  ],
  providers: [
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}

export function tokenGetter() {
  return localStorage.getItem('access_token');
}
