using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Partial
{
    public partial class Juzgado
    {
        public string this[string fieldName]
        {
            get
            {
                var pro = this.GetType().GetProperty(fieldName);
                object value = pro.GetValue(this, null);
                return value == null ? null : value.ToString();
            }
            set
            {
                var pro = this.GetType().GetProperty(fieldName);
                pro.SetValue(this, value, null);
            }
        }
    }
}
