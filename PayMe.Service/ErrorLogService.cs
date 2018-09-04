using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayMe.Service.Contract;
using PayMe.Service;
using PayMe.Service.Models;
using PayMe.Repository.Contract;
using PayMe.Repository;
using PayMe.Model;

namespace PayMe.Service
{
    public class ErrorLogService : IErrorLogService
    {
        private IRepository<ErrorLog> _errorLogRepository;

        public ErrorLogService(IRepository<ErrorLog> errorRepository)
        {
            _errorLogRepository = errorRepository;
        }

        public void AddError(ErrorLogServiceModel model)
        {
            ErrorLog addLog = new ErrorLog()
            {
                Error = model.error.Message,
                Location = model.Location,
                Method = model.Method,
                OtherInfo = model.OtherInfo
            };
            _errorLogRepository.Add(addLog);
        }
    }
}
