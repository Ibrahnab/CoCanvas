using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoCanvas.Domain.Entities;
using CoCanvas.Application.DTO;

namespace CoCanvas.Application.Interfaces.Repositories
{
    public interface IPostsRepository
    {
        public Task<PostDto?> GetPost(Guid guid);
        public Task<List<Post>> GetPosts();
        public Task CreatePost(Post post);
    }
}
