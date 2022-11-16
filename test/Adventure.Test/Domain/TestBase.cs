using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Test.Domain
{
    public class TestBase
    {
        protected void ValidateObjects<T>(T objA, T objB)
        {
            if (objA is null)
            {
                Assert.Null(objB);
            }
            else
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.PropertyType != typeof(string) && prop.PropertyType.IsClass)
                    {
                        continue;
                    }
                    Assert.Equal(prop.GetValue(objA), prop.GetValue(objB));
                }
            }
        }
    }
}
