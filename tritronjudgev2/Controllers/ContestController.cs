﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using tritronAPI.DTOs;
using Contracts;

namespace tritronAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public ContestController(IUnitOfWork uow,IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddContest([FromBody] CreateContestDto contest)
        {
            var con = _mapper.Map<Contest>(contest);
            var res = this._uow.ContestRepository.CreateContest(con);
            if (res.Succeeded)
            {
                _uow.Save();
                return Ok(new Contest(){Id = res.Contest.Id});
            }
            else
            {
                return BadRequest(res);
            }
            
        }
        [HttpGet]
        [Route("type")]

        public async Task<IActionResult> ContestType()
        {
            return Ok(EnumExtensions.GetValues<ContestType>());
        }
        
    }
}