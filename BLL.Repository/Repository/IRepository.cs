﻿using BLL.ViewModel;
using System.Collections.Generic;

namespace BLL.Repository.Repository
{
    public interface IRepository
    {
        EmployeeVM Login(EmployeeVM _userinfo);
        AppDetailsVM GetApplicationDetails(int AppId);
        Result PropertySave(PropertyMasterVM _Property, int AppId);

        List<PropertyMasterVM> getPropertyDetails(int AppId);

        PropertyMasterVM getPropertyDetailsByID(int q, int AppId);


    }
}
