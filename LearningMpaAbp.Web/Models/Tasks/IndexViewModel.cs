using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Abp.Localization;
using LearningMpaAbp.Tasks;
using LearningMpaAbp.Tasks.Dtos;

namespace LearningMpaAbp.Web.Models.Tasks
{
    public class IndexViewModel
    {
        /// <summary>
        /// �������а��б����״̬
        /// </summary>
        public TaskState? SelectedTaskState { get; set; }

        /// <summary>
        /// �б�չʾ
        /// </summary>
        public IReadOnlyList<TaskDto> Tasks { get; }

        /// <summary>
        /// ��������ģ��
        /// </summary>
        public CreateTaskInput CreateTaskInput { get; set; }

        /// <summary>
        /// ��������ģ��
        /// </summary>
        public UpdateTaskInput UpdateTaskInput { get; set; }

        public IndexViewModel(IReadOnlyList<TaskDto> items)
        {
            Tasks = items;
        }
        
        /// <summary>
        /// ���ڹ���������İ�
        /// </summary>
        /// <returns></returns>

        public List<SelectListItem> GetTaskStateSelectListItems()
        {
            var list=new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "AllTasks",
                    Value = "",
                    Selected = SelectedTaskState==null
                }
            };

            list.AddRange(Enum.GetValues(typeof(TaskState))
                .Cast<TaskState>()
                .Select(state=>new SelectListItem()
                {
                    Text = $"TaskState_{state}",
                    Value = state.ToString(),
                    Selected = state==SelectedTaskState
                })
            );

            return list;
        }
    }
}