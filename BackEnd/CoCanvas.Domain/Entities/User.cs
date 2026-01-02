using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoCanvas.Domain.Entities;

// UserId is a string from IdentityUser, by design. 
// TODO: Add more properties here
public class User : IdentityUser { 

    public string? Initials { get; set; }
    public List<Post> Posts { get; set; } = null!;

}