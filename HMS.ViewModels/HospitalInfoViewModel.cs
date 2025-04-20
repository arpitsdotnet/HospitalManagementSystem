using HMS.Models;

namespace HMS.ViewModels;
public class HospitalInfoViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string City { get; set; }
    public string Pincode { get; set; }
    public string Country { get; set; }

    public HospitalInfoViewModel()
    {
            
    }
    public HospitalInfoViewModel(HospitalInfo hospitalInfo)
    {
        Id = hospitalInfo.Id;
        Name = hospitalInfo.Name;
        Type = hospitalInfo.Type;
        City = hospitalInfo.City;
        Pincode = hospitalInfo.Pincode;
        Country = hospitalInfo.Country;
    }
    public HospitalInfo ConvertViewModel(HospitalInfoViewModel hospitalInfoVM)
    {
        return new HospitalInfo
        {
            Id = hospitalInfoVM.Id,
            Name = hospitalInfoVM.Name,
            Type = hospitalInfoVM.Type,
            City = hospitalInfoVM.City,
            Pincode = hospitalInfoVM.Pincode,
            Country = hospitalInfoVM.Country
        };
    }
}
