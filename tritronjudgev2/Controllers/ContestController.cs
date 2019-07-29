using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tritronAPI.DTOs;
using tritronAPI.Model;
using tritronAPI.Persist;

namespace tritronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private IUnitOfWork _uow;

        public ContestController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        [HttpPost]
        public async Task<IActionResult> AddContest([FromBody] CreateContestDto contest)
        {
            var con = new Contest();
            this._uow.ContestRepository.Add(con);
            return Ok();
        }
    }
}