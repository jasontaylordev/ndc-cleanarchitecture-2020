using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists
{
    [Collection(nameof(QueryCollection))]
    public class GetTodoListsTests
    {
        private readonly TestFixture _fixture;

        public GetTodoListsTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            // Arrange
            var query = new GetTodoListsQuery();

            var handler = new GetTodoListsQueryHandler(_fixture.Context, _fixture.Mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeOfType<TodosVm>();
            result.Lists.Should().HaveCount(1);
            result.Lists[0].Items.Should().HaveCount(4);
        }
    }
}