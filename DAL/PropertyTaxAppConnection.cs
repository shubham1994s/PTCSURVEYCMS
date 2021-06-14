using System;
using System.Linq;
using System.Text;

namespace DAL
{
    class PropertyTaxAppConnection
    {
        public static string GetConnectionString(int AppId)
        {
            try
            {
                const string DefaultStringCon = @"metadata=res://*/ChildDatabase.ChildModel1.csdl|res://*/ChildDatabase.ChildModel1.ssdl|res://*/ChildDatabase.ChildModel1.msl;provider=System.Data.SqlClient;provider connection string='";
                const string Data_Source = "data source=";
                const string Initial_Catlog = ";initial catalog=";
                const string Security_Info = ";persist security info=True;";
                const string User_Id = "user id=";
                const string Password = ";password=";
                const string MultiSelective_Result = ";multipleactiveresultsets=True;";
                const string App = "App=EntityFramework'";
                using (var context = new DEVPTCSURVEYMAINEntities())
                {
                    var RetConnecton = context.AppConnections.Where(x => x.AppId == AppId).FirstOrDefault();
                    StringBuilder buildConnectionString = new StringBuilder();
                    buildConnectionString.Append(DefaultStringCon);
                    buildConnectionString.Append(Data_Source);
                    buildConnectionString.Append(RetConnecton.DataSource);
                    buildConnectionString.Append(Initial_Catlog);
                    buildConnectionString.Append(RetConnecton.InitialCatalog);
                    buildConnectionString.Append(Security_Info);
                    buildConnectionString.Append(User_Id);
                    buildConnectionString.Append(RetConnecton.UserId);
                    buildConnectionString.Append(Password);
                    buildConnectionString.Append(RetConnecton.Password);
                    buildConnectionString.Append(MultiSelective_Result);
                    buildConnectionString.Append(App);
                    return buildConnectionString.ToString();
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
