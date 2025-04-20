namespace HMS.Models;
internal class LabTest
{
    public int Id { get; set; }
    public string TestType { get; set; }
    public string TestCode { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public Lab Lab { get; set; }
    public Bill Bill { get; set; }
}
