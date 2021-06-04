﻿using ApiManager.Core.Entities;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parameter = ApiManager.Core.Entities.Parameter;

namespace ApiManager.Infra.EntityMapper
{
    public class ParameterMapper : ClassMapper<Core.Entities.Parameter>
    {
        public ParameterMapper()
        {
            Table(nameof(Parameter).ToLower());

            Map(p => p.Id).Column("id").Key(KeyType.Assigned);

            Map(p => p.Name).Column("name");

            Map(p => p.Description).Column("description");

            Map(p => p.Comment).Column("comment");

            Map(p => p.Type).Column("type");

            Map(p => p.Category).Column("category");

            Map(p => p.ApiId).Column("api_id");

            Map(p => p.ParentId).Column("parent_id");
        }
    }
}
