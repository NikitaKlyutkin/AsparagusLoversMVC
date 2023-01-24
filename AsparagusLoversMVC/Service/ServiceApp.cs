using AsparagusLoversMVC.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using AsparagusLoversMVC.Database.Entityes;
using System.Linq;

namespace AsparagusLoversMVC.Service
{
	
	public class ServiceApp
	{
		private readonly MyDBContext _dbContext;

		public ServiceApp(MyDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task Create(Asparagus entity)
		{
			entity.id = Guid.NewGuid();
			entity.DateTime = DateTime.Now;
			await _dbContext.Asparaguss.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}
		public IQueryable<Asparagus> GetAll()
		{
			return _dbContext.Asparaguss;
		}

        public List<string> GetAsparagus()
        {
            var asparg = _dbContext.Asparaguss.GroupBy(e => e.Email)
                .Select(e =>
                    $"{e.Max(e => e.DateTime)} - {e.OrderByDescending(e => e.DateTime).First().Name} съел спаржу {e.Count()} раз(а)").ToList();

            return asparg;
        }
	}
}
