using Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ExtensionMethods
{
    public static class DeepCloneExtension
    {
        public static T DeepClone<T>(this T input)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(stream, input);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                stream.Position = 0;
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
