using BLL.ViewModel;
using System.Collections.Generic;

namespace BLL.Repository.Repository
{
    public interface IRepository
    {
        EmployeeVM Login(EmployeeVM _userinfo);
        AppDetailsVM GetApplicationDetails(int AppId);
        Result PropertySave(PropertyMasterVM _Property, int AppId);

        Result NamunaSave(NamunaMasterVM _Namuna, int AppId);

        List<PropertyMasterVM> getPropertyDetails(int AppId);

        List<NamunaMasterVM> getNamunaDetails(int AppId);

        PropertyMasterVM getPropertyDetailsByID(int q, int AppId);

        NamunaMasterVM getNamunaDetailsByID(int q, int AppId);

        PropertyMasterVM getPropertyDetailsByFamily(string q,string n, int AppId);

        PropertyMasterVM getDeleteByID(int q, int AppId);
        NamunaMasterVM getDeleteByIDNamuna(int q, int AppId);

        PropertyMasterVM SendPropertyDetails(int AppId,string SearchText, string SelectOption,string send, string Reminder,int q);

        PropertyMasterVM GetPrabhagNo(int Appid, int q);

        PropertyMasterVM GetHTNo(int Appid, int q);

        PropertyMasterVM GetWardNo(int Appid, int q);

        PropertyMasterVM GetCSDate(int Appid, int q);

        PropertyMasterVM GetCEDate(int Appid, int q);

        PropertyMasterVM GetPropertyNoList(int Appid, string pname);

        PropertyMasterVM GetOwnerNameList(int Appid, string pname);

        PropertyMasterVM GetOwnerNameFocus(int Appid,string pname);
    }
}
