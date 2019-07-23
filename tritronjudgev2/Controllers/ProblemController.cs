using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tritronAPI.DTOs;
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
        public async Task<IActionResult> Get(int id)
        {
            var problem = _uow.ProblemRepository.Get(id);
            return Ok(problem);
        }

        // POST: api/Problem
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProblemCreateDto problemdto)
        {
            var problemtoCreate = _mapper.Map<Problem>(problemdto);

            _uow.ProblemRepository.Add(problemtoCreate);
            for (int i = 0; i < problemdto.InputTest.Count; i++)
            {
                var file = new TestFile();
                file.Id = Guid.NewGuid();
                file.InputData = Encoding.ASCII.GetBytes(problemdto.InputTest.ElementAt(i));
                file.OutputData = Encoding.ASCII.GetBytes(problemdto.OutputTest.ElementAt(i));
                file.Problem_Id = problemtoCreate.Id;
                file.Problem = problemtoCreate;
                problemtoCreate.TestFiles.Add(file);
            }

            _uow.Save();

            return Ok(new Problem(){Id = problemtoCreate.Id});
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
