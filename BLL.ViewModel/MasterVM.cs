using System;

namespace BLL.ViewModel
{
    class MasterVM
    {
    }
    public class EmployeeVM
    {
        public int ADUM_USER_CODE { get; set; }
        public int SERVER_ID { get; set; }
        public int APP_ID { get; set; }
        public string ADUM_USER_ID { get; set; }
        public string ADUM_USER_NAME { get; set; }
        public string ADUM_LOGIN_ID { get; set; }
        public string ADUM_PASSWORD { get; set; }
        public string ADUM_EMPLOYEE_ID { get; set; }
        public string ADUM_DESIGNATION { get; set; }

        public string ADUM_MOBILE { get; set; }
        public string ADUM_EMAIL { get; set; }
        public string LOCAL_USER_NAME { get; set; }
        public string PROFILE_IMAGE { get; set; }
        public string ADUM_FRDT { get; set; }
        public string ADUM_TODT { get; set; }
        public bool ADUM_STATUS { get; set; }
        public bool UPDATE_FLAG { get; set; }
        public string LAST_UPDATE { get; set; }
        public int AD_USER_TYPE_ID { get; set; }
        public string MOBILE_ID { get; set; }
        public bool IS_ACTIVE { get; set; }

        public string IS_ACTIVETEXT { get; set; }

        public string IMO_NO { get; set; }

        public string DEVICE_ID { get; set; }
        public string status { get; set; }

        //public List<SelectListItem> UserList { get; set; }



    }

    public class AppDetailsVM
    {
        public int AppId { get; set; }
        public string AppName { get; set; }

        public string AppName_mar { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> Tehsil { get; set; }
        public Nullable<int> District { get; set; }
        public string EmailId { get; set; }
        public string website { get; set; }
        public string Android_GCM_pushNotification_Key { get; set; }
        public string AppVersion { get; set; }
        public Nullable<bool> ForceUpdate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public class AD_USER_MSTVM
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> Tehsil { get; set; }
        public Nullable<int> District { get; set; }
        public string EmailId { get; set; }
        public string website { get; set; }
        public string Android_GCM_pushNotification_Key { get; set; }
        public string AppVersion { get; set; }
        public Nullable<bool> ForceUpdate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime CreatedDate { get; set; }


    }



}
