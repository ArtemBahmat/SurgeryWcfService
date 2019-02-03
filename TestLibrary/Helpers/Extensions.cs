using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestLibrary.Common;

namespace TestLibrary.Helpers
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this IEnumerable<object> items)
        {
            return items == null || !items.Any();
        }

        public static string AsString(this IEnumerable<string> items)
        {
             return string.Join(", ", items);
        }

        public static string AsString(this bool input)
        {
            return input ? "TRUE" : "FALSE";
        }

        public static string Clean(this string inputString)
        {
            foreach (var symbol in Constants.HdrConstants.RemoveSymbols)
            {
                inputString = inputString.Replace(symbol, string.Empty);
            }

            return inputString;
        }

        public static bool IsNumeric(this string input)
        {
            return int.TryParse(input, out _);
        }

        public static void ThrowIfNotNumeric(this string input)
        {
            if (!input.IsNumeric())
            {
                throw new FormatException($"Variable '{input}' has incorrect Format");
            }
        }

        public static void ThrowIfNullOrEmpty(this string input, string variableName)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException($"Please select {variableName}. Value can't be empty");
        }
    }
}
