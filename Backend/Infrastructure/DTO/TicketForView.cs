using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class TicketForView
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NumberOfMinutes { get; set; }
        public string PhoneNumber { get; set; }
        public int GovernateId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public bool IsHandled { get; set; }
    }
}
