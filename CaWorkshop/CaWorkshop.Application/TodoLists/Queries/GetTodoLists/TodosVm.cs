using CaWorkshop.Application.Common.Model;
using System.Collections.Generic;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodosVm
    {
        public IList<LookupDto> PriorityLevels { get; set; }

        public IList<TodoListDto> Lists { get; set; }
    }
}
