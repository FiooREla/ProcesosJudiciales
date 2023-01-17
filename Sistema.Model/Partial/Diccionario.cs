using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model.Partial
{
    public static class ObjectHelper
    {
        public static T FnGetValue<T>(this Dictionary<string, object> dic, string key)
        {
            return (T)dic[key];
        }        
    }
}
