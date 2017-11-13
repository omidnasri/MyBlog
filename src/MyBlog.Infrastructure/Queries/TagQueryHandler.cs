﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Queries
{
    public class TagQueryHandler :
        IAsyncRequestHandler<TagGetsQuery, IEnumerable<TagEntity>>,
        IAsyncRequestHandler<TagGetsByPostIdQuery, IEnumerable<TagEntity>>,
        IAsyncRequestHandler<TagGetQuery, TagEntity>
    {
        private readonly DataContext _context;

        public TagQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagEntity>> Handle(TagGetsQuery message)
        {
            return await _context.Tags.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TagEntity>> Handle(TagGetsByPostIdQuery message)
        {
            return await _context.PostTags
                .AsNoTracking()
                .Where(pt => pt.PostId == message.PostId)
                .Select(pt => pt.Tag)
                .ToListAsync();
        }

        public async Task<TagEntity> Handle(TagGetQuery message)
        {
            return await _context.Tags.AsNoTracking().SingleOrDefaultAsync(t => t.Id == message.TagId);
        }
    }
}