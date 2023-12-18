import { HttpClient , HttpHeaders , HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { IPerson } from 'src/export-Interface/IPerson';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private apiUrl = "https://localhost:7292/api";

  constructor(private http: HttpClient) {}


  getPerson(): Observable<IPerson[]> {
    return this.http.get<IPerson[]>(`${this.apiUrl}/Person`)
    
  }

}




