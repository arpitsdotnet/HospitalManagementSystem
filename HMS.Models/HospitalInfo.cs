﻿namespace HMS.Models;

public class HospitalInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string Country { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}
