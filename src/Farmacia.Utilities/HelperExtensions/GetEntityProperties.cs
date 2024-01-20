using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Utilities.HelperExtensions
{
    public static class GetEntityProperties
    {
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity) 
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            var entityParans = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(entity)!;

                if (value != null)
                {
                    entityParans[property.Name] = value;
                }
            }

            return entityParans;
        }
    }
}
