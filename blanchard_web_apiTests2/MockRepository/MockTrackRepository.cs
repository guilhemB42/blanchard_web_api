using blanchard_web_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blanchard_web_api;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;

namespace blanchard_web_apiTests2.MockRepository
{
    internal class MockTrackRepository : ITrackRepository
    {
        Context context;
        public MockTrackRepository(Context context)
        {
            this.context = context;
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Track>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<Track> GetAll()
        {
            return new List<Track>() { new Track { Id = 17 } };
        }

        public Task<Track> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Track> PatchArtist(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> PatchDuration(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> PatchTitle(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> Post(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<Track> Put(Track track)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
