using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.DAL.Models.Identity
{
    public class ApplicationUser :IdentityUser  //id==>string
    {
        public string? Address { get; set; }

    }
}
