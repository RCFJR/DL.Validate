using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DL.Validate
{
    public class Validate
    {
        public static bool Verify<T>(T entity)
        {
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            object valueOf = null;

            foreach (PropertyInfo prop in props)
            {
                var req = prop.CustomAttributes;
                if (req.Any(e => e.AttributeType.Name.Equals("RequiredAttribute")))
                {
                    valueOf = prop.GetValue(entity, null);
                    if (String.IsNullOrEmpty(valueOf.ToString()))
                        return false;
                }
            }
            return true;
        }
    }
}
