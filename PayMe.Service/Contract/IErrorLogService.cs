using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayMe.Service.Models;

namespace PayMe.Service.Contract
{
    public interface IErrorLogService
    {
        void AddError(ErrorLogServiceModel model);
    }
}
