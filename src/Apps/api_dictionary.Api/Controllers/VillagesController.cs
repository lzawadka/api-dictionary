using System.Threading;
using System.Threading.Tasks;
using api_dictionary.Application.Common.Models;
using api_dictionary.Application.Dto;
using api_dictionary.Application.Villages.Queries.GetVillagesWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_dictionary.Api.Controllers
{
    /// <summary>
    /// Villages
    /// </summary>
    [Authorize]
    public class VillagesController : BaseApiController
    {
        /// <summary>
        /// Get all villages with pagination
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PaginatedList<VillageDto>>>> GetAllVillagesWithPagination(GetAllVillagesWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
