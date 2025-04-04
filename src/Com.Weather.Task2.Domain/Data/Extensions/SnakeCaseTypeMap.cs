using Dapper;
using System.Reflection;

namespace Com.Weather.Task2.Domain.Data.Extensions
{
    public class SnakeCaseTypeMap<T> : SqlMapper.ITypeMap
    {
        private readonly SqlMapper.ITypeMap _defaultMap;

        public SnakeCaseTypeMap()
        {
            _defaultMap = new DefaultTypeMap(typeof(T));
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            return _defaultMap.FindConstructor(names, types);
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return _defaultMap.FindExplicitConstructor();
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            return _defaultMap.GetConstructorParameter(constructor, columnName);
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            var propertyName = NameConverter.ToPascalCase(columnName);
            return _defaultMap.GetMember(propertyName);
        }
    }
} 