using dws.models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services.Interfaces
{
    public interface ILoggingStore
    {
        Task<HttpResponseMessage> WriteErrorAsync(ErrorModel error);
        void WriteError(ErrorModel error);
        Task<HttpResponseMessage> WriteTraceAsync(TraceModel trace);
        void WriteTrace(TraceModel trace);
    }
}
