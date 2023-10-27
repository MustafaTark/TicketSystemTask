import { Injectable } from '@angular/core';
import { singleTicket } from '../singleTicket';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TicketService {
   private apiUrl = 'https://localhost:7013'
  constructor(private router:Router,private http:HttpClient) { }



  getAllTickets(pageNumber:number) : Observable<singleTicket[]>{
    return this.http.get<singleTicket[]>(`${this.apiUrl}/api/Tickets?PageNumber=${pageNumber}&PageSize=5`)
  }

  changeHandleStatus(id:number) {
    this.http.put(`${this.apiUrl}/api/Tickets/Handle/${id}`,{}).subscribe({
      next:res=>{
        alert('Ticket Status changed Successfully')
      },
      error:err=>{
        alert(err)
      }
    })
  }



}
