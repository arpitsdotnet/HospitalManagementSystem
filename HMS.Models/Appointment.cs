namespace HMS.Models;

public class Appointment
{
    public int Id { get; set; }
    public string AppointmentNumber { get; set; }
    public string Type { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Description { get; set; }

    public ApplicationUser Doctor { get; set; }
    public ApplicationUser Patient { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

}