using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic |
                                                BindingFlags.Public |
                                                BindingFlags.Instance);

            string input = "";
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                string fieldAttribute = "";
                string accessModifier = "";

                if (input != "all")
                {
                    foreach (var field in fields
                        .Where(x => x.Attributes.ToString().ToLower().Replace("family", "protected") == input)
                        .ToArray())
                    {
                        Console.WriteLine(PrintFields(fieldAttribute, accessModifier, field));
                    }
                }
                else
                {
                    foreach (var field in fields)
                    {
                        Console.WriteLine(PrintFields(fieldAttribute, accessModifier, field));
                    }
                }
            }
        }

        private static string PrintFields(string fieldAttribute, string accessModifier, FieldInfo field)
        {
            fieldAttribute = field.Attributes.ToString().ToLower();
            accessModifier = fieldAttribute == "family" ? "protected" : fieldAttribute;

            return $"{accessModifier} {field.FieldType.Name} {field.Name}";
        }
    }
}
