using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMpaAbp.Tasks.Dtos;
using LearningMpaAbp.IRepositories;
using Abp.Domain.Repositories;
using LearningMpaAbp.Tasks;
using AutoMapper;

namespace LearningMpaAbp.TaskNews
{
    public class TaskNewAppService : ApplicationService, ITaskNewAppService
    {
        private readonly ITaskNewRepository _tasknewRepository;
        private readonly IRepository<Person, int> _personReposioty;

        public TaskNewAppService(ITaskNewRepository taskRepository, IRepository<Person> personRepository)
        {
            _tasknewRepository = taskRepository;
            _personReposioty = personRepository;
        }

        public void CreateTask(CreateTaskInput input)
        {
            Logger.Info("Creating a task for input: " + input);
            var task = new TaskNew();
            //if (input.AssignedPersonId.HasValue)
            //{
            //    task.AssignedPersonId = input.AssignedPersonId.Value;
            //}
            _tasknewRepository.Insert(task);
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            //调用Task仓储的特定方法GetAllWithPeople
            var tasks = _tasknewRepository.GetAllWithPeople(input.AssignedPersonId, input.State);

            //用AutoMapper自动将List<Task>转换成List<TaskDto>
            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(tasks)
            };
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            throw new NotImplementedException();
        }
    }
}
