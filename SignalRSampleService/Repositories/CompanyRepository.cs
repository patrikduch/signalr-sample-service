using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SignalRSampleService.Data;
using SignalRSampleService.Dtos;
using SignalRSampleService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SignalRSampleService.Repositories
{
    /// <summary>
    /// Dapper repository for managing <seealso cref="CompanyModel"/> entities.
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        /// <summary>
        /// Instance of a <seealso cref="IDbConnection"/> for db access. 
        /// </summary>
        private readonly IDbConnection _db;

        /// <summary>
        /// Instance of a <seealso cref="IMapper"/> that enables automapping functionality between objects. 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Instance of a Custom  <seealso cref="CompanyContext"/> for accesing company entities. 
        /// </summary>
        private readonly CompanyContext _companyDbContext;


        /// <summary>
        /// Initializes a new instance of the <seealso cref="CompanyRepository"/> Dapper repository class.
        /// </summary>
        /// <param name="configuration"></param>
        public CompanyRepository(IConfiguration configuration, CompanyContext companyContext, IMapper mapper)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");
            _db = new NpgsqlConnection(connString);

            _companyDbContext = companyContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public Task<CompanyModel> Add(CompanyModel company)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find company object by it's id.
        /// </summary>
        /// <param name="id">Primary key of <seealso cref="CompanyModel"/> entity.</param>
        /// <returns>Searched company entity.</returns>
        public async Task<CompanyItemDto> Find(Guid id)
        {
            var sql = "SELECT * FROM Company WHERE id = @companyId";
            var entity = await _db.QueryFirstOrDefaultAsync<CompanyModel>(sql, new { @companyId = id });

            return _mapper.Map<CompanyModel, CompanyItemDto>(entity);
        }


        /// <summary>
        /// Get the list of companies.
        /// </summary>
        /// <returns>Collection of companies.</returns>
        public async Task<IEnumerable<CompanyItemDto>> GetAll()
        {
            var sql = "SELECT name, address, city, state, postalcode FROM company";
            var entity = await _db.QueryAsync<CompanyModel>(sql);

            return _mapper.Map<List<CompanyModel>, List<CompanyItemDto>>(entity as List<CompanyModel>);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public Task<CompanyModel> Update(CompanyModel company)
        {
            throw new NotImplementedException();
        }
    }
}
