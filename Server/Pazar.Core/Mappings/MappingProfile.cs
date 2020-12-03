﻿using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace Pazar.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile(Assembly assembly)
            => this.ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly
                .GetExportedTypes()
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                            || i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                const string mappingMethodName = "Mapping";

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

                methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapTo`1")?.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
