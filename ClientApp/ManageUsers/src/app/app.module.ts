import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { PersonsComponent } from './persons/persons.component';

import { TranscationDetailsComponent } from './transcation-details/transcation-details.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { NavigationComponent } from './navigation/navigation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    LoginComponent,
    PersonsComponent,
    TranscationDetailsComponent,
    AccountDetailsComponent,
    PersonDetailsComponent,
    NavigationComponent,
    DashboardComponent,

 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
 
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
