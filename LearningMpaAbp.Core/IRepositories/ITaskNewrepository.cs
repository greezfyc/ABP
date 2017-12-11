using Abp.Domain.Repositories;
using LearningMpaAbp.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMpaAbp.IRepositories
{
    public interface ITaskNewRepository : IRepository<TaskNew,long>
    {
        List<TaskNew> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
