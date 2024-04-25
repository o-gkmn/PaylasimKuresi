using Bogus;
using DataAccess.DbContext;
using DataAccess.Repositories.CommonOperations;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccessTests.Repositories.CommonOperations;

public class CommonOperationsTests
{
    private readonly Faker<Post> _faker;
    private readonly EFContext _context;

    public CommonOperationsTests()
    {
        _faker = new Faker<Post>()
            .RuleFor(p => p.ID, f => Guid.NewGuid())
            .RuleFor(p => p.Status, f => "Created")
            .RuleFor(p => p.CreatedAt, f => DateTime.Now);
        var _options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
        _context = new EFContext(_options);
    }

    private void AddDummyDataToDatabase()
    {
        for (var i = 0; i < 10; i++)
        {
            var entity = _faker.Generate();
            _context.Set<Post>().Add(entity);
        }
        _context.SaveChanges();
    }

    [Fact]
    public async Task CreateAsync_Save_Entity_To_Database()
    {
        //Arrange
        var entity = _faker.Generate();
        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.CreateAsync(entity);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task DeleteAsync_Remove_Entity_To_Database()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeRemoved = _faker.Generate();
        _context.Set<Post>().Add(entityToBeRemoved);
        _context.SaveChanges();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.DeleteAsync(entityToBeRemoved);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_Remove_NonExistent_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeRemoved = _faker.Generate();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.DeleteAsync(entityToBeRemoved);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetAsync_Fetch_Entity_From_Database()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeFetched = _faker.Generate();
        _context.Set<Post>().Add(entityToBeFetched);
        _context.SaveChanges();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.GetAsync(p => p.ID == entityToBeFetched.ID);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(entityToBeFetched.ID, result.ID);
    }

    [Fact]
    public async Task GetAsync_Fetch_NonExistent_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeFetched = _faker.Generate();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.GetAsync(p => p.ID == entityToBeFetched.ID);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetListAsync_Fetch_Entities_With_Filter()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeFetched = _faker.Generate();
        _context.Set<Post>().Add(entityToBeFetched);
        _context.SaveChanges();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.GetListAsync(p => p.ID == entityToBeFetched.ID);

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetListAsync_Fetch_Entities_Without_Filter()
    {
        //Arrange
        AddDummyDataToDatabase();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.GetListAsync();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(_context.Set<Post>().Count(), result.Count);
    }

    [Fact]
    public async Task GetListAsync_Fetch_Empty_Entities()
    {
        //Arrange
        AddDummyDataToDatabase();
        _context.Posts.RemoveRange(_context.Posts);
        _context.SaveChanges();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        var result = await repositories.GetListAsync();

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task UpdateAsync_Update_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeUpdated = _faker.Generate();
        _context.Set<Post>().Add(entityToBeUpdated);
        _context.SaveChanges();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        entityToBeUpdated.Status = "Changed";
        var result = await repositories.UpdateAsync(entityToBeUpdated);
        var updatedEntity = await repositories.GetAsync(p => p.ID == entityToBeUpdated.ID);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(entityToBeUpdated.Status, result.Status);
        Assert.NotNull(updatedEntity);
        Assert.Equal(entityToBeUpdated.Status, updatedEntity.Status);
    }

    [Fact]
    public async Task UpdateAsync_Update_NonExistent_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeUpdated = _faker.Generate();

        var repositories = new CommonOperations<Post>(_context);

        //Act
        entityToBeUpdated.Status = "Changed";
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await repositories.UpdateAsync(entityToBeUpdated));
        var updatedEntity = await repositories.GetAsync(p => p.ID == entityToBeUpdated.ID);

        //Assert
        Assert.Null(updatedEntity);
    }
}
