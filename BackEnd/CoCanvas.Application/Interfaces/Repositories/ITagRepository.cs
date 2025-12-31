using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Domain.Entities;

namespace CoCanvas.Application.Interfaces.Repositories
{
    public interface ITagRepository
    {
        public Task<Tag?> GetTagByName(string tagName);
        public Task<Tag> CreateTag(string tagName);
    }
}
