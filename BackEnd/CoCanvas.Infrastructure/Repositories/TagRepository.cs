using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCanvas.Application.Interfaces.Repositories;
using CoCanvas.Domain.Entities;
using CoCanvas.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CoCanvas.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {

        private CCDbContext _dbContext;
        public TagRepository(CCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tag?> GetTagByName(string tagName)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
        }

        public async Task<Tag> CreateTag(string tagName)
        {
            var tag = await GetTagByName(tagName);

            if (tag == null)
            {
                tag = new Tag
                {
                    Id = Guid.NewGuid(),
                    Name = tagName,
                };

                await _dbContext.Tags.AddAsync(tag);
                await _dbContext.SaveChangesAsync();
            }
            return tag;
        }
    }
}
