using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JLRP.Domain.Dtos;
using JLRP.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JLRP.API.Controllers
{
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id">Id of customer</param>
        /// <returns>Customer information</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            return Single(await QueryAsync(new GetUserQuery(id)));
        } 
    }
}
