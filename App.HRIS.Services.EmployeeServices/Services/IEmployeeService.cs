using App.HRIS.Entities.Helpers;

namespace App.HRIS.Services.EmployeeServices.Services
{
    public interface IEmployeeService
    {
        public Task<ResponseBase<ViewModels.Res_EmployeeDetail>> GetEmployeeById(int id);
    }
}
