using Microsoft.Extensions.Configuration;
using Salary.Core.Repositories.Query.Base;
using Salary.Infrastructure.Data;

namespace Salary.Infrastructure.Repository.Query.Base
{
    // Generic Query repository class
    public class QueryRepository<T> : DbConnector,  IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
