using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Entities;
using Sample.Mapper.Models;
using Sample.Orchestrator.Repositories.Interfaces;
using Sample.Orchestrator.Services.Interfaces;

namespace Sample.Orchestrator.Services
{
    public class AuditService : IAuditService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Audit> _repository;

        public AuditService(IRepository<Audit> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Public Methods

        public async ValueTask<IEnumerable<AuditModel>> GetAuditsAsync()
        {
            var audits = await _repository.All().ToListAsync();

            return _mapper.Map<IEnumerable<AuditModel>>(audits);
        }

        #endregion
    }
}