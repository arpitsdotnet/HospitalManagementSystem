namespace HMS.Models;

public class MedicineReport
{
    public int Id { get; set; }
    public Supplier Supplier { get; set; }
    public Medicine Medicine { get; set; }
    public string Company { get; set; }
    public string Country { get; set; }
    public int Qty { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpireDate { get; set; }


}
