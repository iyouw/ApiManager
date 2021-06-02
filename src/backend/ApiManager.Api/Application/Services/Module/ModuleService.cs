﻿using ApiManager.Core.Repositories;
using ApiManager.Infra.Dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Api.Application.Services.Project
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _repo;
        private readonly IDbContext _context;

        public ModuleService(IModuleRepository repo, IDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public Task<Core.Entities.Module> GetByIdAsync(string id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task<IEnumerable<Core.Entities.Module>> GetListAsync()
        {
            return _repo.GetListAsync();
        }

        public async Task<Core.Entities.Module> AddAsync(Core.Entities.Module project)
        {
            _repo.Add(project);
            _ = await _context.SaveChangeAsync();
            return project;
        }
    }
}