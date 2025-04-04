using System.Text;
using System.Text.RegularExpressions;

namespace Com.Weather.Task2.Domain.Data.Extensions
{
    public static class NameConverter
    {
        private static readonly Regex _pascalCaseRegex = new(@"(?<=[a-z])([A-Z])", RegexOptions.Compiled);
        private static readonly Regex _snakeCaseRegex = new(@"_([a-z])", RegexOptions.Compiled);

        public static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return _pascalCaseRegex.Replace(input, "_$1").ToLower();
        }

        public static string ToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return _snakeCaseRegex.Replace(input, match => match.Groups[1].Value.ToUpper());
        }
    }
} 