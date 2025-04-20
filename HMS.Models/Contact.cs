namespace HMS.Models;

public class Contact
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public virtual HospitalInfo Hospital { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}