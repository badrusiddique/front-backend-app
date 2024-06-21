using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Responses;
using Sample.Api.Validators;
using Sample.Mapper.DTOs.Response;
using Sample.Orchestrator.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/audits")]
    public class AuditsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuditService _service;

        public AuditsController(IMapper mapper, IAuditService auditService)
        {
            _mapper = mapper;
            _service = auditService;
        }

        /// <summary>
        /// Get all audit information by query input
        /// </summary>
        /// <remarks>
        ///
        ///     GET /api/audits?startDate={start-date} AND endDate={end-date}
        ///     startDate and endDate are of DateTime type which expects YYYY/DD/MM, MM/DD/YYYY or DD-MM-YYYY format
        ///
        /// </remarks>
        /// <param name="queryDto">audit query input</param>
        /// <returns>Audit Response Dto</returns>
        [HttpGet]
        [ValidationFilter]
        public async ValueTask<ApiResponse<IEnumerable<AuditResponseDto>>> GetByQueryAsync()
        {
            var models = await _service.GetAuditsAsync();
            var audits = _mapper.Map<IEnumerable<AuditResponseDto>>(models);
            return ApiResponse<IEnumerable<AuditResponseDto>>.ParseResponse(audits);
        }
    }
}