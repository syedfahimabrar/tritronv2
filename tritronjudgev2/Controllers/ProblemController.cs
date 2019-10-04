using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Models;
using tritronAPI.DTOs;
using tritronAPI.SignalRHubs;

namespace tritronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IHubContext<ProblemsHub> _problemHub;

        public ProblemController(IMapper mapper,IUnitOfWork uow,IHubContext<ProblemsHub> problemHub)
        {
            this._mapper = mapper;
            this._uow = uow;
            this._problemHub = problemHub;
        }
        // GET: api/Problem
        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber=1,int pageSize=5)
        {
            IEnumerable<Problem> problems = _uow.ProblemRepository.Find(p => p.Contest.EndTime < DateTime.Now || p.Contest_Id == null,pageNumber,pageSize);
            var cnt = _uow.ProblemRepository.GetCount(p => p.Contest.EndTime < DateTime.Now || p.Contest_Id == null);
            return Ok(new ProblemListDto(){Problem = problems,TotalCount = cnt});
        }

        [HttpGet]
        [Route("query")]
        public async Task<IActionResult> Get(string query)
        {
            IEnumerable<Problem> problems = _uow.ProblemRepository.Find(p => p.ProblemName.Contains(query));
            return Ok(problems);
        }

        // GET: api/Problem/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var problem = _uow.ProblemRepository.Find(p => p.Id == id, null,
                include: s => s.Include(a => a.ProblemLanguages)
                    .ThenInclude(a => a.Language).Include(a => a.ProblemAuthor)).FirstOrDefault();
            var res =_mapper.Map<ProblemDto>(problem);
            //_uow.ProblemRepository.Find(p => p.Id == id, null, "ProblemLanguages").FirstOrDefault();
            //_uow.ProblemRepository.Get(id);
            return Ok(res);
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
            await _problemHub.Clients.All.SendAsync("send", "hello");
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
        [HttpGet]
        [Route("language")]
        public async Task<IActionResult> LanguageType()
        {
            var Languages = _uow.LanguageRepository.GetAll();
            return Ok(Languages);
        }
    }
}
