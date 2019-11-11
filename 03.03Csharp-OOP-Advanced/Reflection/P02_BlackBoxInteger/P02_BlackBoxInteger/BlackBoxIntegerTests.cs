

namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            var instance = Activator.CreateInstance(type, true);

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitInput = input.Split("_", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = splitInput[0];
                var value = int.Parse(splitInput[1]);

                foreach (var method in methods)
                {
                    if (method.Name == command)
                    {
                        method.Invoke(instance, new object[] { value });

                        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                        foreach (var field in fields)
                        {
                            if (field.Name == "innerValue")
                            {
                                Console.WriteLine(field.GetValue(instance));
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
