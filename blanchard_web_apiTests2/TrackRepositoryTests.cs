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
        public void GetAllAsyncTest()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("music");


            var context = new Context(builder.Options);
            context.Database.EnsureDeleted();
/*          context.Tracks.Add(new Track { Id = 343, ArtistName="aaa", Title="bbb",DurationInSecond=15 });
            context.Tracks.Add(new Track { Id = 25, ArtistName="bbb", Title="ccc",DurationInSecond=65 });
*/

            MockTrackRepository petRepository = new MockTrackRepository(context);

            // Act
            var tracks = petRepository.GetAll();
            Track track = tracks.ElementAt(0);

            // Assert
            Assert.AreEqual(track.Id, 17);
        }
    }
}