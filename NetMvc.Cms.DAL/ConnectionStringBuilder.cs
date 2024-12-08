using System.Configuration;

namespace NetMvc.Cms.DAL
{
    public class ConnectionStringBuilder
    {
        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ModelContext"].ToString();

            return connectionString;
        }

        public static string ConnectionString => GetConnectionString();
    }
}