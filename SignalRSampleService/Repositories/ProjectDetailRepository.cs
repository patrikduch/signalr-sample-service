using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SignalRSampleService.Contexts;
using SignalRSampleService.Dtos;
using SignalRSampleService.Models;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignalRSampleService.Repositories
{
    /// <summary>
    /// Data repository for managing <seealso cref="ProjectDetailModel"/> entities.
    /// </summary>
    public class ProjectDetailRepository : IProjectDetailRepository
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
        /// Instance of a custom  <seealso cref="DbContext"/> for accesing <seealso cref="ProjectDetailModel"/> entities. 
        /// </summary>
        private readonly ProjectDetailContext _projectdetailDbContext;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProjectDetailRepository"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="mapper"></param>
        /// <param name="projectDetailContext"></param>
        public ProjectDetailRepository(IConfiguration configuration, IMapper mapper, ProjectDetailContext projectDetailContext)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");
            _db = new NpgsqlConnection(connString);

            _mapper = mapper;
            _projectdetailDbContext = projectDetailContext;
        }

        /// <summary>
        /// Get the basic project detail information.
        /// </summary>
        /// <returns>Single ProjectDetail object with basic project information.</returns>
        public async Task<ProjectDetailDto> GetProjectDetail()
        {
            var sql = "SELECT * FROM projectdetail";
            var entity = await _db.QueryFirstOrDefaultAsync<ProjectDetailModel>(sql);

            return _mapper.Map<ProjectDetailModel, ProjectDetailDto>(entity);
        }

        /// <summary>
        /// Update some of properties of <seealso cref="ProjectDetailModel"/> entity.
        /// </summary>
        /// <param name="projectDetailUpdate">Updated projectdetail data.</param>
        public async Task UpdateProjectDetail(ProjectDetailUpdateDto projectDetailUpdate)
        {
            _projectdetailDbContext.Update(projectDetailUpdate);
            await _projectdetailDbContext.SaveChangesAsync();
        }
    }
}
