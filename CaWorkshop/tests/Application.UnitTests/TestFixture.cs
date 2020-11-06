using AutoMapper;
using CaWorkshop.Infrastructure.Persistence;
using System;
using Xunit;

namespace CaWorkshop.Application.UnitTests
{
    [CollectionDefinition(nameof(QueryCollection))]
    public class QueryCollection : ICollectionFixture<TestFixture> { }

    public class TestFixture : IDisposable
    {
        // Test set up
        public TestFixture()
        {
            Context = DbContextFactory.Create();
            Mapper = MapperFactory.Create();
        }

        public ApplicationDbContext Context { get; }
        public IMapper Mapper;

        // Test clean up
        public void Dispose()
        {
            DbContextFactory.Destroy(Context);
        }
    }
}
