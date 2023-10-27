using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class TicketForCreate
    {
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number must contain only numbers")]
        public string PhoneNumber { get; set; }
        public int GovernateId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
    }
}
