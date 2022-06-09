using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkopa.Core.DTO
{
    public class SendSMSDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string SmsText { get; set; }
    }
}
