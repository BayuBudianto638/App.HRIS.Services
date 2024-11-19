using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationLibs.ViewModels
{
    public class AuthorizationVM
    {
        public bool Auth { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserNik { get; set; }
        public string? Message { get; set; }
    }
}
