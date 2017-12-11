using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMpaAbp.Tasks
{
    public class TaskNew : Entity<long>, IHasCreationTime
    {
        [ForeignKey("AssignedPersonId")]
        public virtual Person AssignedPerson { get; set; }


        public virtual int? AssignedPersonId { get; set; }

        public virtual DateTime Description { get; set; }

        public virtual DateTime CreationTime { get; set; }


        public TaskState State { get; set; }
        public TaskNew()
        {
            CreationTime = DateTime.Now;
            State = TaskState.Open;
        }
    }


    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}
