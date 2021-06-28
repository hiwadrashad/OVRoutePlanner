using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExtensionMethods
{
    public static class IsSerializableExtension
    {
        public static bool IsSerializable(this object obj)
        {
            Type t = obj.GetType();

            return Attribute.IsDefined(t, typeof(DataContractAttribute)) || t.IsSerializable || (obj is System.Xml.Serialization.IXmlSerializable);

        }
    }
}
