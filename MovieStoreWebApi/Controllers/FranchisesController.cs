using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
using MovieStoreWebApi.Models.DTOs.Franchise;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseRepository _repository;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = await _repository.ReadSpecificFranchiseAsync(id);

            if (franchise == null)
                return NotFound();

            var dtoFranchise = _mapper.Map<FranchiseReadDTO>(franchise);

            return dtoFranchise;
        }

        [HttpGet]
        public async Task<IEnumerable<FranchiseReadDTO>> GetFranchises()
        {
            var franchises = await _repository.ReadAllFranchisesAsync();
            var dtoFranchises = _mapper.Map<List<FranchiseReadDTO>>(franchises);

            return dtoFranchises;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            await _repository.DeleteFranchiseAsync(id);

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO dtoFranchise)
        {
            var domainFranchise = _mapper.Map<Franchise>(dtoFranchise);

            domainFranchise = await _repository.CreateFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise",
                new { id = domainFranchise.Id },
                _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseUpdateDTO dtoFranchise)
        {
            if (id != dtoFranchise.Id)
                return BadRequest();

            if (!_repository.FranchiseExists(id))
                return NotFound();

            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            await _repository.UpdateFranchiseAsync(domainFranchise);

            return NoContent();
        }
    }
}
