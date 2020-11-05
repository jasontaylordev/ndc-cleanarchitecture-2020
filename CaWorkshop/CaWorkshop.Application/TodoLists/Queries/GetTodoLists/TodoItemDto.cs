using CaWorkshop.Domain.Entities;
using System.Linq.Expressions;
using System;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoItemDto
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public int Priority { get; set; }

        public string Note { get; set; }

        public static Expression<Func<TodoItem, TodoItemDto>> Projection
        {
            get
            {
                return item => new TodoItemDto
                {
                    Id = item.Id,
                    ListId = item.ListId,
                    Title = item.Title,
                    Done = item.Done,
                    Priority = (int)item.Priority,
                    Note = item.Note
                };
            }
        }
    }
}