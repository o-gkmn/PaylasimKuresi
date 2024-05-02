using System.Linq.Expressions;
using Bogus;
using DataAccess.DbContext;
using DataAccess.Repositories.UserRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Moq;

namespace DataAccessTests.Repositories.UserRepositories;

public class UserRepositoryTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly EFContext _context;
    private readonly Faker<User> _faker;

    public UserRepositoryTests()
    {
        var _options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;
        _userManagerMock = new Mock<UserManager<User>>(
            Mock.Of<IUserStore<User>>(),
            null, null, null, null, null, null, null, null);
        _context = new EFContext(_options);
        _faker = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.FullName, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email);
    }

    private void AddDummyDataToDatabase()
    {
        for (var i = 0; i < 10; i++)
        {
            var entity = _faker.Generate();
            _context.Set<User>().Add(entity);
        }
        _context.SaveChanges();
    }

    [Fact]
    public async Task DeleteAsync_Remove_Entity_To_Database()
    {
        //Arrange
        AddDummyDataToDatabase();
        _userManagerMock.Setup(u => u.DeleteAsync(It.IsAny<User>())).Returns(Task.FromResult(IdentityResult.Success));
        var entityToBeRemoved = _faker.Generate();
        _context.Set<User>().Add(entityToBeRemoved);
        _context.SaveChanges();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

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
        _userManagerMock.Setup(u => u.DeleteAsync(It.IsAny<User>())).Returns(Task.FromResult(IdentityResult.Failed()));
        var entityToBeRemoved = _faker.Generate();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

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
        _context.Set<User>().Add(entityToBeFetched);
        _context.SaveChanges();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        var result = await repositories.GetAsync(p => p.Id == entityToBeFetched.Id);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(entityToBeFetched.Id, result.Id);
    }

    [Fact]
    public async Task GetAsync_Fetch_NonExistent_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeFetched = _faker.Generate();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        var result = await repositories.GetAsync(p => p.Id == entityToBeFetched.Id);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetListAsync_Fetch_Entities_With_Filter()
    {
        //Arrange
        AddDummyDataToDatabase();
        var entityToBeFetched = _faker.Generate();
        _context.Set<User>().Add(entityToBeFetched);
        _context.SaveChanges();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        var result = await repositories.GetListAsync(p => p.Id == entityToBeFetched.Id);

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

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        var result = await repositories.GetListAsync();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(_context.Set<User>().Count(), result.Count);
    }

    [Fact]
    public async Task GetListAsync_Fetch_Empty_Entities()
    {
        //Arrange
        AddDummyDataToDatabase();
        _context.Users.RemoveRange(_context.Users);
        _context.SaveChanges();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

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
        _userManagerMock.Setup(u => u.UpdateAsync(It.IsAny<User>())).Returns(Task.FromResult(IdentityResult.Success));
        var entityToBeUpdated = _faker.Generate();
        _context.Set<User>().Add(entityToBeUpdated);
        _context.SaveChanges();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        entityToBeUpdated.FullName = "Enzo Ferrari";
        var result = await repositories.UpdateAsync(entityToBeUpdated);
        var updatedEntity = await repositories.GetAsync(p => p.Id == entityToBeUpdated.Id);

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Succeeded);
        Assert.NotNull(updatedEntity);
        Assert.Equal(entityToBeUpdated.FullName, updatedEntity.FullName);
    }

    [Fact]
    public async Task UpdateAsync_Update_NonExistent_Entity()
    {
        //Arrange
        AddDummyDataToDatabase();
        _userManagerMock.Setup(u => u.UpdateAsync(It.IsAny<User>())).Returns(Task.FromResult(IdentityResult.Failed()));
        var entityToBeUpdated = _faker.Generate();

        var repositories = new UserRepository(_userManagerMock.Object, _context);

        //Act
        entityToBeUpdated.FullName = "Enzo Ferrari";
        var result = await repositories.UpdateAsync(entityToBeUpdated);
        var updatedEntity = await repositories.GetAsync(p => p.Id == entityToBeUpdated.Id);

        //Assert
        Assert.False(result.Succeeded);
        Assert.Null(updatedEntity);
    }
}
