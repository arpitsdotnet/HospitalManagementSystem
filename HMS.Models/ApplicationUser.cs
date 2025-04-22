﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HMS.Models;
public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Nationality { get; set; }
    public string Address { get; set; }
    public DateTime DOB { get; set; }
    public string Specialist { get; set; }
    public Department Department { get; set; }
    [NotMapped]
    public ICollection<Appointment> Appointments { get; set; }
    [NotMapped]
    public ICollection<Payroll> Payrolls { get; set; }

}

public enum Gender
{
    Male, Female, Other
}