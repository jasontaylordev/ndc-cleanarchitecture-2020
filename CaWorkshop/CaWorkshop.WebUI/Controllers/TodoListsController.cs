using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.DeleteTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;
using CaWorkshop.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CaWorkshop.WebUI.Controllers
{
    public class TodoListsController : ApiControllerBase
    {
        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<TodosVm>> GetTodoLists()
        {
            return await Mediator.Send(new GetTodoListsQuery());
        }

        // PUT: api/TodoLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(int id, UpdateTodoListCommand command)
        {
            if (id != command.Id) 
                return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        // POST: api/TodoLists
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoList(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
