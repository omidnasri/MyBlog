﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core;
using MyBlog.Core.Commands;
using MyBlog.Core.Entities;
using MyBlog.Core.Queries;
using MyBlog.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IMapper mapper, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Tags
        public async Task<ActionResult> Index()
        {
            var entities = await _mediator.Send(new PostGetsQuery());
            var viewModels = _mapper.Map<IEnumerable<PostSummaryViewModel>>(entities);

            return View(viewModels);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Post/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var entity = _mapper.Map<PostEntity>(viewModel);
            var tagIds = string.IsNullOrEmpty(viewModel.Tags)
                ? new int[] { }
                : viewModel.Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var command = new PostAddCommand { Post = entity, TagIds = tagIds.ToArray() };

            await _mediator.Send(command);
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }

        // GET: Admin/Tags/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var entity = await _mediator.Send(new PostGetQuery { PostId = id.Value });
            if (entity == null)
                return NotFound();

            var viewModel = _mapper.Map<PostViewModel>(entity);
            ViewBag.Tags = entity.PostTags.Select(t => new KeyValuePair<int, string>(t.Tag.Id, t.Tag.Name));

            return View(viewModel);
        }

        // POST: Admin/Post/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id", "Name")]PostViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var entity = _mapper.Map<TagEntity>(viewModel);
            await _mediator.Send(new TagEditCommand { Tag = entity });
            await _unitOfWork.CommitAsync();

            return RedirectToAction("Index");
        }

        // DELETE: Admin/Tags/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            await _mediator.Send(new PostRemoveCommand { PostId = id.Value });
            await _unitOfWork.CommitAsync();

            return Json(new { });
        }
    }
}