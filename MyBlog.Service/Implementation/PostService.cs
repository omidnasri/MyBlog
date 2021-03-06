﻿using MyBlog.Common.Helpers;
using MyBlog.Data;
using MyBlog.Data.Contracts;
using MyBlog.Domain;
using MyBlog.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBlog.Service.Implementation
{
    public class PostService : BaseService<PostEntity>, IPostService
    {
        private readonly DataContext _dataContext;
        private readonly Lazy<ITagService> _tagService;

        public PostService(IQueryableContext queryableContext, Lazy<ITagService> tagService)
            : base(queryableContext)
        {
            _dataContext = queryableContext.EfContext;
            _tagService = tagService;
        }

        #region IPostService Members

        public void AddPost(PostEntity post, string tagsId)
        {
            var idList = tagsId.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var tags = _tagService.Value.GetTags(idList);

            if (tags.Count() < idList.Count())
                return;

            post.CreateDate = DateTime.Now;
            post.Slug = UrlHelper.GenerateSlug(post.Title);
            post.Tags = new Collection<TagEntity>();
            post.Tags = tags.ToList();

            AddItem(post);

            CacheHelper.ClearItem(ApplicationKey.Posts);
        }

        public void EditPost(PostEntity editedPost, string tagsId)
        {
            var postInDb = GetPost(p => p.Id == editedPost.Id, p => p.Tags);
            if (postInDb == null)
                return;

            var idList = tagsId.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var tags = _tagService.Value.GetTags(idList);

            if (tags.Count() < idList.Count())
                return;

            postInDb.Content = editedPost.Content;
            postInDb.IsEnabled = editedPost.IsEnabled;
            postInDb.Slug = UrlHelper.GenerateSlug(editedPost.Title);
            postInDb.Tags.Clear();
            postInDb.Tags = tags.ToList();
            postInDb.Title = editedPost.Title;
            postInDb.UpdateDte = DateTime.Now;

            EditItem(postInDb);
            CacheHelper.ClearItem(ApplicationKey.Post + postInDb.Id);
            CacheHelper.ClearItem(ApplicationKey.Posts);
        }

        public void DeletePost(Expression<Func<PostEntity, bool>> predicate)
        {
            var post = GetPost(predicate, p => p.Tags);
            if (post == null)
                return;

            post.Tags.Clear();
            DeleteItem(post);
            CacheHelper.ClearItem(ApplicationKey.Post + post.Id);
            CacheHelper.ClearItem(ApplicationKey.Posts);
        }

        public PostEntity GetPost(int postId)
        {
            var post = FindItem(postId);
            return post;
        }

        public PostEntity GetPost(Expression<Func<PostEntity, bool>> predicate, params Expression<Func<PostEntity, object>>[] includes)
        {
            var post = GetItem(predicate, includes);
            return post;
        }

        public IEnumerable<PostEntity> GetPosts(Expression<Func<PostEntity, bool>> predicate = null, params Expression<Func<PostEntity, object>>[] includes)
        {
            var posts = CacheHelper.GetItem(ApplicationKey.Posts) as IEnumerable<PostEntity>;
            if (posts != null)
                return posts;

            posts = GetItems(predicate, includes);
            CacheHelper.AddItem(ApplicationKey.Posts, posts, new TimeSpan(1, 0, 0, 0));

            return posts;
        }

        public IEnumerable<PostEntity> GetPosts<TKey>(Expression<Func<PostEntity, bool>> predicate,
            Expression<Func<PostEntity, TKey>> selector, SortOrder sortOrder, params Expression<Func<PostEntity, object>>[] includes)
        {
            var posts = CacheHelper.GetItem(ApplicationKey.Posts) as IEnumerable<PostEntity>;
            if (posts != null)
                return posts;

            posts = GetItems(predicate, selector, sortOrder, includes);
            CacheHelper.AddItem(ApplicationKey.Posts, posts, new TimeSpan(1, 0, 0, 0));

            return posts;
        }

        public async Task<IEnumerable<PostEntity>> GetPostsAsync<TKey>(Expression<Func<PostEntity, bool>> predicate,
          Expression<Func<PostEntity, TKey>> selector, SortOrder sortOrder, params Expression<Func<PostEntity, object>>[] includes)
        {
            var posts = CacheHelper.GetItem(ApplicationKey.Posts) as IEnumerable<PostEntity>;
            if (posts != null)
                return posts;

            posts = await GetItemsAsync(predicate, selector, sortOrder, includes);
            CacheHelper.AddItem(ApplicationKey.Posts, posts, new TimeSpan(1, 0, 0, 0));

            return posts;
        }

        #endregion IPostService Members
    }
}