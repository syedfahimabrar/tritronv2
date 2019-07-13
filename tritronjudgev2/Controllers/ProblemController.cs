using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tritronAPI.Model;
using tritronAPI.Persist;

namespace tritronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _uow;

        public ProblemController(IMapper mapper,IUnitOfWork uow)
        {
            this._mapper = mapper;
            this._uow = uow;
        }
        // GET: api/Problem
        [HttpGet]
        public async Task<IActionResult> Get(int? pageNumber,int? pageSize)
        {
            var problems = _uow.ProblemRepository.Find(null, 1, 5);
            return Ok(problems);
        }

        // GET: api/Problem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Problem
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Problem problem)
        {
            _uow.ProblemRepository.Add(problem);
            _uow.Save();
            return Ok(problem);
        }

        // PUT: api/Problem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
