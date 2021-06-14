using System.Web;

namespace BLL.ViewModel
{
    public class SessionHandler
    {
        public string DB_Name { get; set; }
        public string Property1 { get; set; }
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public int RoleID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int AppId { get; set; }
        public string AppName { get; set; }

        public string AppName_mar { get; set; }
        public bool IsLoggedIn { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public string Type { get; set; }
        public string sessionType { get; set; }
        public int ShopID { get; set; }

        public SessionHandler()
        {
            Property1 = "default value";
        }

        // Gets the current session.
        public static SessionHandler Current
        {
            get
            {
                SessionHandler session =
                (SessionHandler)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new SessionHandler();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

    }
}
