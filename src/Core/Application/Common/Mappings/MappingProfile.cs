using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Portfolio.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(AppDomain.CurrentDomain.GetAssemblies());
        }

        private void ApplyMappingsFromAssembly(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies.Where(p => p.FullName.Contains("Portfolio")))
            {
                var types = assembly.GetExportedTypes()
                  .Where(t => t.GetInterfaces().Any(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                  .ToList();

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type);

                    var methodInfo = type.GetMethod("Mapping")
                        ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                    methodInfo?.Invoke(instance, new object[] { this });
                }
            }
        }
    }
}