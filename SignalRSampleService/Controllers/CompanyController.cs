using Microsoft.AspNetCore.Mvc;
using SignalRSampleService.Dtos;
using SignalRSampleService.Models;
using SignalRSampleService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRSampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="CompanyController"/> WebAPI controller.
        /// </summary>
        /// <param name="companyRepository">Injectable data repository for managing  <seealso cref="CompanyModel"/> entities.</param>
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IEnumerable<CompanyItemDto>> Get()
        {
            return await _companyRepository.GetAll();
        }

        // GET: api/<CompanyController>/guid
        [HttpGet]
        [Route("/{companyId}")]
        public async Task<CompanyItemDto> GetById(Guid companyId)
        {
            return await _companyRepository.Find(companyId);
        }
    }
}
