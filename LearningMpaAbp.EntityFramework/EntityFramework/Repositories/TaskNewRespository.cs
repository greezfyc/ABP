using Abp.EntityFramework;
using LearningMpaAbp.IRepositories;
using LearningMpaAbp.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMpaAbp.EntityFramework.Repositories
{
    public class TaskNewRespository : LearningMpaAbpRepositoryBase<TaskNew,long>,ITaskNewRepository
    {
        public TaskNewRespository(IDbContextProvider<LearningMpaAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<TaskNew> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = GetAll();

            if (assignedPersonId.HasValue)
            {
                query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
            }

            return query.OrderByDescending(task => task.CreationTime)
      .ToList();
        }
    }
}
