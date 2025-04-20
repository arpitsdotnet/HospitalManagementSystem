namespace HMS.Models;

public class Bill
{
    public int Id { get; set; }
    public string BillNumber { get; set; }
    public ApplicationUser Patient { get; set; }
    public Insurance Insurance { get; set; }
    public int NoOfDays { get; set; }
    public decimal DoctorCharge { get; set; }
    public decimal MedicineCharge { get; set; }
    public decimal RoomCharge { get; set; }
    public decimal OperationCharge { get; set; }
    public decimal NursingCharge { get; set; }
    public decimal LabCharge { get; set; }
    public decimal AdvancedAmount { get; set; }
    public decimal TotalBillAmount { get; set; }

}