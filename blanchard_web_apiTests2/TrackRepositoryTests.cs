using Microsoft.VisualStudio.TestTools.UnitTesting;
using blanchard_web_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blanchard_web_api.Entities;
using blanchard_web_apiTests2.MockRepository;

namespace blanchard_web_api.Tests
{
    [TestClass()]
    public class TrackRepositoryTests
    {
        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("music");


            var context = new Context(builder.Options);
            context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            context.Artists.Add(new Artist { Id = 105, Name = "rrr" });
           
            context.SaveChanges();


            ArtistRepository artistRepo = new ArtistRepository(context);

            // Act
            var artist = await artistRepo.GetAllAsync();

            // Assert
            Assert.AreEqual(105, artist.First().Id);
        }
    }
}