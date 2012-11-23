using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using TweakToolkit.MVVM.Model;

namespace TweakToolkit.MVVM.Gateway
{
    public class EntityMappingGateway<TDbContext> : ObservableGateway<TDbContext> where TDbContext : DbContext
    {
        private readonly Dictionary<Type, Type> _modelTypeMap;

        public EntityMappingGateway(Dictionary<Type,Type> typeMap)
        {
            _modelTypeMap = typeMap;
            CreateMap();
        }

        protected void CreateMap()
        {
            foreach (var pair in _modelTypeMap)
            {
                Mapper.CreateMap(pair.Key, pair.Value);
                Mapper.CreateMap(pair.Value, pair.Key);
            }
        }
    }
}