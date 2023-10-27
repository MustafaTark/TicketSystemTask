import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HompePageComponent } from './hompe-page/hompe-page.component';
import { CreateNewTicketComponent } from './create-new-ticket/create-new-ticket.component';
import {HttpClientModule} from '@angular/common/http';
const appRoutes:Routes=[
  {path:'', component: HompePageComponent},
  {path:'createNewTicket', component: CreateNewTicketComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    HompePageComponent,
    CreateNewTicketComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
