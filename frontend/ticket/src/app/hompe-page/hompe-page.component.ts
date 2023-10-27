import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {singleTicket} from '.././singleTicket'
import { HttpClient } from '@angular/common/http';
import { TicketService } from '../services/ticket.service';
@Component({
  selector: 'app-hompe-page',
  templateUrl: './hompe-page.component.html',
  styleUrls: ['./hompe-page.component.css']
})
export class HompePageComponent {
  constructor(private router:Router,private http:HttpClient, private ticketService:TicketService){}
 
  ngOnInit(){

    this.getAllTickets();
  }
 
  pageNumber : number = 1;
   allTickets!:singleTicket[];


  goToCreateNewTicket(){
    this.router.navigate([`/createNewTicket`])
  }


  getAllTickets(){

    this.ticketService.getAllTickets(this.pageNumber)
                      .subscribe((tickets)=>
                                 this.allTickets = tickets)
  }

  handleColor(t:singleTicket){
    if(t.isHandled){
      return 'red';
    }
    else {
      if(t.numberOfMinutes<15){
        return 'black';
      }else if(t.numberOfMinutes>=15 && t.numberOfMinutes<30){
        return 'yellow';
      }else if(t.numberOfMinutes>=30 && t.numberOfMinutes<45){
        return 'green';
      }else if(t.numberOfMinutes>=45 && t.numberOfMinutes<60){
        return 'blue';
      }else{
        this.ticketService.changeHandleStatus(t.id)
       
        return 'red'
      } 
      
  }
   
  }


  goToNextPage(){
    this.pageNumber=this.pageNumber+1
    this.getAllTickets();
  }

  goToPreviousPage(){
    if(this.pageNumber>1){
      this.pageNumber=this.pageNumber-1;
      this.getAllTickets();
    }
  }

  goToFirstPage(){
    this.pageNumber=1;
    this.getAllTickets();
  }
  goToSecondPage(){
    this.pageNumber=2;
    this.getAllTickets();
  }
  


  changeHandleStatus(id:number){
    this.ticketService.changeHandleStatus(id)
    this.getAllTickets()
  }



}


