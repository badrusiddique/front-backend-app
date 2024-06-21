using System;
using System.Data;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sample.Api.Middlewares.Extensions
{
    public static class AutoMapperExtensions
    {
        private static readonly IContractResolver DefaultResolver = new JsonSerializer().ContractResolver;

        public static void CreateJsonDataReaderMap<TDestination>(this IMapperConfigurationExpression cfg, IContractResolver resolver = null)
        {
            resolver ??= DefaultResolver;
            var contract = resolver.ResolveContract(typeof(TDestination)) as JsonObjectContract ?? throw new ArgumentException($"{typeof(TDestination)} is not a JSON object.");

            var map = cfg.CreateMap<IDataRecord, TDestination>();

            foreach (var p in contract.Properties.Where(p => !p.Ignored && p.Writable))
            {
                // Map PropertyName in reader to UnderlyingName in TDestination
                map.ForMember(p.UnderlyingName, opt => opt.MapFrom(r => r[p.PropertyName]));
            }
        }
    }
}