import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { PersonsComponent } from './persons/persons.component';

const routes: Routes = [
  { path: '', redirectTo: 'app-home', pathMatch: 'full' },
  { path: 'app-home', component: HomeComponent },
  { path: 'app-about', component: AboutComponent },
  { path: 'app-contact', component: ContactComponent },
  {path:'app-persons', component:PersonsComponent},
  { path: 'app-login', component: LoginComponent , 
     children: [{path:'app-persons', component: PersonsComponent}],}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
