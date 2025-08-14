using System.Configuration;

namespace ESMS.Settings
{
    public class AppliationSettings
    {
        public static string ConnectionString()
        {
            return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ESMS;Integrated Security=True;TrustServerCertificate=True";
        }
    }
}
