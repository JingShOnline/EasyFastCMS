﻿using EasyFast.EntityFramework;
using EntityFramework.DynamicFilters;

namespace EasyFast.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly EasyFastDbContext _context;

        public InitialHostDbBuilder(EasyFastDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
