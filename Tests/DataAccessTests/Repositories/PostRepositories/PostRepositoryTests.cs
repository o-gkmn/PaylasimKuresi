using DataAccess.DbContext;
using DataAccess.Repositories.PostRepositories;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Moq;

namespace DataAccessTests.Repositories.PostRepositories;

public class PostRepositoryTests
{
    private readonly DbContextOptions<EFContext> _options;

    public PostRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public async Task CreateAsync_SavesPostToDatabaseAsync()
    {
        // Arrange
        var mockEntity = new Mock<Post>();
        var post = mockEntity.Object;
        post.Status = "Created";

        using (var context = new EFContext(_options))
        {
            var service = new PostRepository(context);

            // Act 
            var result = await service.CreateAsync(mockEntity.Object);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(default, result.ID); // Ensure Id is set
            Assert.Equal(post.ID, result.ID);
        }
    }

    [Fact]
    public async Task DeleteAsync_DeletesPostToDatabaseAsync()
    {
        //Arrange
        var mockEntity = new Mock<Post>();
        var entity = mockEntity.Object;
        entity.Status = "Created";

        using (var context = new EFContext(_options))
        {
            context.Posts.Add(entity);
            await context.SaveChangesAsync();
        }

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var isDeleted = await repository.DeleteAsync(entity);

            //Assert
            Assert.True(isDeleted);
        }

        using (var context = new EFContext(_options))
        {
            var deletedPost = await context.Posts.FindAsync(entity.ID);
            Assert.Null(deletedPost);
        }
    }

    [Fact]
    public async Task GetAsync_GetPostSuccessfully()
    {
        //Arrange
        var mockEntity = new Mock<Post>();
        var entity = mockEntity.Object;
        entity.Status = "Created";

        using (var context = new EFContext(_options))
        {
            context.Posts.Add(entity);
            await context.SaveChangesAsync();
        }

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var result = await repository.GetAsync(p => p.ID == entity.ID);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(entity.ID, result.ID);
        }
    }

    [Fact]
    public async Task GetAsync_GetPostFailed()
    {
        //Arrange
        var mockEntity = new Mock<Post>();
        var entity = mockEntity.Object;
        entity.Status = "Created";

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var result = await repository.GetAsync(p => p.ID == entity.ID);

            //Assert
            Assert.Null(result);
        }
    }

    [Fact]
    public async Task GetListAsync_GetPostListSuccessfully()
    {
        //Arrange
        var entities = new List<Post>();
        using (var context = new EFContext(_options))
        {
            for (int i = 0; i < 10; ++i)
            {
                var mockEntity = new Mock<Post>();
                var entity = mockEntity.Object;
                entity.Status = "Created";
                entities.Add(entity);
                context.Posts.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var result = await repository.GetListAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count);
        }
    }

    [Fact]
    public async Task GetListAsync_GetPostListFailed()
    {
        //Arrange
        var entities = new List<Post>();

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var result = await repository.GetListAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count);
        }
    }

    [Fact]
    public async Task GetListAsync_GetPostListWithFilter()
    {
        //Arrange
        var entities = new List<Post>();

        var mockFilteredEntity = new Mock<Post>();
        var filteredEntity = mockFilteredEntity.Object;
        filteredEntity.Status = "Deleted";
        entities.Add(filteredEntity);

        using (var context = new EFContext(_options))
        {
            for (int i = 0; i < 10; ++i)
            {
                var mockEntity = new Mock<Post>();
                var entity = mockEntity.Object;
                entity.Status = "Created";
                entities.Add(entity);
                context.Posts.Add(entity);
                await context.SaveChangesAsync();
            }
        }

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);

            //Act
            var result = await repository.GetListAsync(p => p.Status == "Deleted");

            //Assert
            Assert.NotNull(result);
            Assert.NotEqual(entities.Count, result.Count);
            foreach (var entity in result)
            {
                Assert.Equal(filteredEntity.Status, entity.Status);
            }
        }
    }

    [Fact]
    public async Task UpdateAsync_UpdatePostToDatabaseAsync()
    {
        //Arrange
        var mockEntity = new Mock<Post>();
        var entity = mockEntity.Object;
        entity.Status = "Created";

        using (var context = new EFContext(_options))
        {
            context.Posts.Add(entity);
            await context.SaveChangesAsync();
        }

        using (var context = new EFContext(_options))
        {
            var repository = new PostRepository(context);
            entity.Status = "Updated";

            //Act
            var result = await repository.UpdateAsync(entity);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Updated", result.Status);
        }
    }
}
