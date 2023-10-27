import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-create-new-ticket',
  templateUrl: './create-new-ticket.component.html',
  styleUrls: ['./create-new-ticket.component.css'],
})
export class CreateNewTicketComponent {

  constructor(private httpClient: HttpClient,private router:Router) {}

  onSubmit(ticketData: NgForm) {

    const el = document.getElementById('errorMessage');

    console.log(ticketData);
  
    const ticketToSend = {
      phoneNumber: ticketData.value.phoneNumber,
      governateId: ticketData.value.governateId*1,
      cityId: ticketData.value.cityId*1,
      districtId:ticketData.value.districtId*1,
    };
    

    this.httpClient.post(`https://localhost:7013/api/Tickets`,ticketToSend).subscribe({
      next:res=>{
        console.log('success',res)
        this.router.navigate([`/`])
      },
      error:err=>{      
        if(el!==null){
          el.style.opacity="1";
          if(err['error']['errors']['PhoneNumber']!==undefined){
            el.innerHTML=err['error']['errors']['PhoneNumber'][0]
          }
        }
      }
    })

    
  }
}
