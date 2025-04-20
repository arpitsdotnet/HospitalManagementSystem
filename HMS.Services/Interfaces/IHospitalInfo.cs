using HMS.Utilities;
using HMS.ViewModels;

namespace HMS.Services.Interfaces;
public interface IHospitalInfo
{
    PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);
    HospitalInfoViewModel GetById(int hospitalId);
    void Update(HospitalInfoViewModel hospitalInfo);
    void Insert(HospitalInfoViewModel hospitalInfo);
    void Delete(int hospitalId);
}
