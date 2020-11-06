using CaWorkshop.Application.Common.Exceptions;
using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWorkshop.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class UpdateTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoList()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var command = new UpdateTodoListCommand
            {
                Id = listId,
                Title = "Updated List Title"
            };

            await SendAsync(command);

            var list = await FindAsync<TodoList>(listId);

            list.Title.Should().Be(command.Title);
            list.LastModifiedBy.Should().NotBeNull();
            list.LastModifiedBy.Should().Be(userId);
            list.LastModifiedUtc.Should().NotBeNull();
            list.LastModifiedUtc.Should().BeCloseTo(DateTime.UtcNow, 1000);
        }
    }
}
