import { Component, OnInit } from '@angular/core';
import { PersonService } from '../Services/person.service';
import { Subscription } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { IPerson } from 'src/export-Interface/IPerson';



@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss']
})
export class PersonsComponent implements OnInit {

  persons: any;
 
  constructor(private personService: PersonService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getPerson();

  }

  getPerson(): void {
    this.personService.getPerson()
    .subscribe(persons => this.persons = persons)

  }

}







