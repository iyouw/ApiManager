﻿using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IDbContext _context;

        public CategoryService(ICategoryRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Category> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Category>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.Category> AddAsync(Core.Entities.Category project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}
