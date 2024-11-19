using App.HRIS.Entities.Helpers;
using App.HRIS.Services.EmployeeServices.ViewModels;

namespace App.HRIS.Services.EmployeeServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<ResponseBase<Res_EmployeeDetail>> GetEmployeeById(int id)
        {
            try
            {
                var authed = await _authorizationTool.IsAuthorized(_httpContextAccessor.HttpContext.User, AuthGrantEnum.READ);

                if (!authed.Auth)
                    throw new Exception(authed.Message);

                Company company = await _GetCompanyModel(id);

                ViewModels.Res_CompanyDetailVM companyVM = new ViewModels.Res_CompanyDetailVM
                {
                    Id = (int)company.Id,
                    Name = company.Name,
                    Code = company.Code,
                    Address = company.Address,
                    Children = await _GetCompanyChildShort(id),
                    CompanyImageRefId = company.CompanyImageRefId,
                    CompanyImageUrl = company.CompanyImageRefId != null ? _baseUrlPath + company.CompanyImageRefId : null,
                    BusinessType = company.BusinessType,
                    Cifs = await _GetCompanyCif(id),
                };

                if (company.CompanyParentId != null)
                {
                    companyVM.GrandparentCompany = _CompanyToVM(await _GetCompanyModelGrandparent(id));
                    companyVM.ParentCompany = _CompanyToVM(await _GetCompanyModel((int)company.CompanyParentId));
                }

                return new ResponseBase<ViewModels.Res_CompanyDetailVM> { Status = true, Message = "OK", Data = companyVM };

            }
            catch (Exception ex)
            {
                return new ResponseBase<ViewModels.Res_CompanyDetailVM> { Status = false, Message = ex.Message };
            }
        }
    }
}
