using Dapper;
using System.Reflection;

namespace Com.Weather.Task2.Domain.Data.Extensions
{
    public static class DapperTypeMap
    {
        private static readonly Dictionary<Type, SqlMapper.ITypeMap> _typeMaps = new();

        public static void RegisterType<T>()
        {
            var type = typeof(T);
            if (!_typeMaps.ContainsKey(type))
            {
                _typeMaps[type] = new SnakeCaseTypeMap<T>();
                SqlMapper.SetTypeMap(type, _typeMaps[type]);
            }
        }

        public static void RegisterTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                var method = typeof(DapperTypeMap).GetMethod(nameof(RegisterType));
                var generic = method.MakeGenericMethod(type);
                generic.Invoke(null, null);
            }
        }
    }
} 