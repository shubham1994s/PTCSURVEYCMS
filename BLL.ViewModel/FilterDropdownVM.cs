using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.ViewModel
{
    public class FilterDropdownVM
    {
        public List<SelectListItem> PrabhagNoList { get; set; }

        public List<SelectListItem> HTNoList { get; set; }

        public List<SelectListItem> WardNoList { get; set; }

        public List<SelectListItem> CSDateList { get; set; }

        public List<SelectListItem> CEDateList { get; set; }


        public List<SelectListItem> PropertyNoList { get; set; }

        public List<SelectListItem> PropertyOwnerList { get; set; }


        public List<PropertyMasterVM> PropertyOwnerListFocus { get; set; }


      
    }
}
