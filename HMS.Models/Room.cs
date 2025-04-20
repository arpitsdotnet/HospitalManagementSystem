namespace HMS.Models;

public class Room
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public virtual HospitalInfo Hospital { get; set; }
    public string RoomNumber { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
}