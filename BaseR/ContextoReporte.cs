using System.Data.EntityClient;
using System.Data.SqlClient;

namespace BaseR
{
    public class ContextoReporte : ReporteEntities
    {
        public ContextoReporte() : base(FnConnection())
        {
        }

        public static string FnConnection()
        {
            var sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = BaseSession.BD_Server;
            sqlBuilder.InitialCatalog = "SIGPJTEST";
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.ConnectionString = "server=" + BaseSession.BD_Server + ";user id=" + BaseSession.BD_User + ";password=" +
                                          BaseSession.BD_Password + ";initial catalog=SIGPJTEST";

            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = "res://*/ModeloReporte.csdl|res://*/ModeloReporte.ssdl|res://*/ModeloReporte.msl";

            return entityBuilder.ToString();
        }
    }
}