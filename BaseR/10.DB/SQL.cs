using System;
using System.Data;
using System.Data.SqlClient;
using BaseR.Ctrls;
using BaseR;

namespace BaseR.DB
{
    public class FnSQL
    {
        public DataTable FnQueryData(string query)
        {
            try
            {
                if (query != null)
                {
                    var cnn = new SqlConnection(FnConnection());
                    var cmd = new SqlCommand();
                    var reader = default(SqlDataReader);
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    cnn.Open();
                    reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }

                return null;
            }
            catch (Exception ex)
            {
                Msg.FnMessage("E", ex.Message);
                return null;
            }
        }

        public string FnConnection()
        {
            var connection = "Data Source=" + BaseSession.BD_Server + ";Initial Catalog=SIG-PJ;User ID=" +
                             BaseSession.BD_User + ";Password=" + BaseSession.BD_Password + ";";
            return connection;
        }
    }
}