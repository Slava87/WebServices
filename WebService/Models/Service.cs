using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json; 

namespace WebService.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Service is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The length must be between 3 and 30 symbols")]
        [Display(Name = "Service")]
        public string ServiceName { get; set; }

        [Display(Name = "Type")]
        public ServiceType ServiceType { get; set; }

        public int PersonId { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Person is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The length must be between 3 and 30 symbols")]
        [Display(Name = "Responsible Person")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Phone Number Field is required")]
        [RegularExpression(@"^([+]\d{1,2}-? *)?\(?\d{3}\)?-? *\d{3}-? *-?\d{2} *-?\d{2}$", ErrorMessage = "Try using following examples: 0991231212, 099-123-12-12, +380991231212, +38-099-123-12-12")]
        [Display(Name = "Phone Number")] 
        public string PhoneNumber { get; set; }

    }


    public class Serialization
    {
        public List<Service> Services { get; set; }
        public List<Person> Persons { get; set; }
    }

    
}