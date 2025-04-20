using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;
using HMS.Repositories.Interfaces;
using HMS.Services.Interfaces;
using HMS.Utilities;
using HMS.ViewModels;

namespace HMS.Services.Implementations;
public class HospitalInfoService : IHospitalInfo
{
    private  readonly IUnitOfWork _unitOfWork;
    //private  readonly IGenericRepository<HospitalInfo> _genericRepository;

    public HospitalInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize)
    {
        int totalCount;
        HospitalInfoViewModel vm = new();
        List<HospitalInfoViewModel> hospitalInfoVMList = new();
        try
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            var modelList = _unitOfWork.GenericRepository<HospitalInfo>().GetAll()
                .Skip(excludeRecords).Take(pageSize).ToList();

            totalCount = _unitOfWork.GenericRepository<HospitalInfo>().GetAll().Count();

            hospitalInfoVMList = ConvertModelToViewModelList(modelList);

        }
        catch (Exception ex)
        {
            throw;
        }

        return new PagedResult<HospitalInfoViewModel>
        {
            Data = hospitalInfoVMList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public HospitalInfoViewModel GetById(int hospitalId)
    {
        HospitalInfo model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalId);

        HospitalInfoViewModel vm = new(model);
        return vm;
    }

    public void Insert(HospitalInfoViewModel hospitalInfoVM)
    {
        HospitalInfo model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfoVM);

        _unitOfWork.GenericRepository<HospitalInfo>().Add(model);
        _unitOfWork.Save();
    }

    public void Update(HospitalInfoViewModel hospitalInfoVM)
    {

        HospitalInfo model = new HospitalInfoViewModel().ConvertViewModel(hospitalInfoVM);

        HospitalInfo modelById = _unitOfWork.GenericRepository<HospitalInfo>().GetById(model.Id);

        modelById.Name = model.Name;
        modelById.Type = model.Type;
        modelById.City = model.City;
        modelById.Country = model.Country;
        modelById.Pincode = model.Pincode;

        _unitOfWork.GenericRepository<HospitalInfo>().Update(modelById);
        _unitOfWork.Save();
    }

    public void Delete(int hospitalId)
    {
        HospitalInfo model = _unitOfWork.GenericRepository<HospitalInfo>().GetById(hospitalId);

        _unitOfWork.GenericRepository<HospitalInfo>().Delete(model);
        _unitOfWork.Save();
    }

    private List<HospitalInfoViewModel> ConvertModelToViewModelList(List<HospitalInfo> modelList)
    {
        return modelList.Select(x => new HospitalInfoViewModel(x)).ToList();
    }
}
