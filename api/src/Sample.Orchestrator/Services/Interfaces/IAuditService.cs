using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Mapper.Models;

namespace Sample.Orchestrator.Services.Interfaces
{
    public interface IAuditService
    {
        /// <summary>
        /// get audit info
        /// </summary>
        /// <returns>AuditModel[]</returns>
        ValueTask<IEnumerable<AuditModel>> GetAuditsAsync();
    }
}