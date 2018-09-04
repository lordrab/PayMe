using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMe.Service.Models
{
    public class ErrorLogServiceModel
    {
        public string Location { get; set; }
        public string Method { get; set; }
        public Exception error { get; set; }
        public string OtherInfo { get; set; }
    }
}
