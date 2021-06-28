using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class RegisterViewModel
    {
        public DriverDTO UserInfo { get; set; }

        public string EncryptionKey { get; set; }
    }
}
