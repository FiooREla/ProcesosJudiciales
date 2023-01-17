using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BaseR.Fns
{
    #region Classes

    public class ClsFilterVB
    {
        public string Column { get; set; }
        public string QInicio { get; set; }
        public string NameCtrl { get; set; }
        public string Value { get; set; }
        public string QFin { get; set; }
    }

    #endregion

    public class FnFiltroVB
    {
        public List<ClsFilterVB> LF_Ctrls = new List<ClsFilterVB>();
        public List<ClsFilterVB> LF_Dates = new List<ClsFilterVB>();

        public FnFiltroVB()
        {
        }

        public FnFiltroVB(string connection, string query)
        {
            ConnetionString = connection;
            Query = query;
        }

        private string Query { get; }
        private string ConnetionString { get; }

        public void FnClearCtrls()
        {
            LF_Ctrls.Clear();
        }

        public void FnClearDates()
        {
            LF_Dates.Clear();
        }

        public void FnSetFilter(string column, string qInicio, string nameCtrl, object value, string qFin,
            string tipo = "C")
        {
            ClsFilterVB item = null;
            if (tipo == "C") item = LF_Ctrls.FirstOrDefault(x => x.NameCtrl == nameCtrl);
            else item = LF_Dates.FirstOrDefault(x => x.NameCtrl == nameCtrl);
            if (item == null)
            {
                item = new ClsFilterVB();
                if (tipo == "C") LF_Ctrls.Add(item);
                else LF_Dates.Add(item);
            }

            item.Column = column;
            item.QInicio = qInicio;
            item.NameCtrl = nameCtrl;
            item.QFin = qFin;
            item.Value = value.ToString();
        }

        public DataTable FnExecQuery()
        {
            var tbl = new DataTable();
            var cnn = new SqlConnection(ConnetionString);
            var cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandTimeout = 1000 * 5;
            cmd.CommandText = FnUpdateFilter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cnn.Open();
            reader = cmd.ExecuteReader();
            tbl.Load(reader);
            return tbl;
        }

        private string FnUpdateFilter()
        {
            var qAux = Query;
            var cls = LF_Dates.Union(LF_Ctrls).ToList();
            if (cls.Count > 0)
                if (Query.ToUpper().IndexOf("[*]") != -1)
                {
                    var sqlQ = "";
                    foreach (var ctrl in cls)
                    {
                        var qItem = ctrl.Column + " " + ctrl.QInicio + ctrl.Value + ctrl.QFin;
                        sqlQ = sqlQ + qItem;
                    }

                    sqlQ = (sqlQ + " ").ToUpper();
                    qAux = qAux.Replace("[*]", sqlQ);
                }
                else
                {
                    var sqlQ = " where ";
                    foreach (var ctrl in cls)
                    {
                        var qItem = ctrl.Column + " " + ctrl.QInicio + ctrl.Value + ctrl.QFin;
                        sqlQ = sqlQ + qItem;
                    }

                    sqlQ = (sqlQ + " ").ToUpper();

                    int indexGroup = Query.ToUpper().IndexOf("GROUP BY"),
                        indexOrder = Query.ToUpper().IndexOf("ORDER BY");
                    if (indexGroup != -1) qAux = Query.Insert(indexGroup, sqlQ);
                    else if (indexOrder != -1) qAux = Query.Insert(indexOrder, sqlQ);
                    else qAux = qAux + "" + sqlQ;
                }

            return qAux;
        }
    }
}