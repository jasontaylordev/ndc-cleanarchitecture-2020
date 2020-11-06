using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using static CaWorkshop.Application.IntegrationTests.Testing;

namespace CaWorkshop.Application.IntegrationTests.TodoLists.Queries
{
    public class GetTodoListsTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllListsAndAssociatedItems()
        {
            // Arrange
            await AddAsync(new TodoList
            {
                Title = "Shopping",
                Items =
                {
                    new TodoItem { Title = "Fresh fruit", Done = true },
                    new TodoItem { Title = "Bread", Done = true },
                    new TodoItem { Title = "Milk", Done = true },
                    new TodoItem { Title = "Toilet paper" },
                    new TodoItem { Title = "Tuna" },
                    new TodoItem { Title = "Pasta" }
                }
            });

            var query = new GetTodoListsQuery();

            // Act
            TodosVm result = await SendAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Lists.Should().HaveCount(1);
            result.Lists.First().Items.Should().HaveCount(6);
        }
    }
}
