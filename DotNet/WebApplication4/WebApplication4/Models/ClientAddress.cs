using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ClientAddress

    { [Key]
        public int Id { get; set; }
        //FK
        public int ClientId { get; set; }
        public string CityName { get; set; }

       // public ClientDetails ClientDetails { get; set; }
    }
}