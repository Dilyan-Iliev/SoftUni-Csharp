namespace Stealer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            //or
            //Type classType = Type.GetType("P01_Stealer." + className);
            //Type classType = typeof(Hacker);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
                                                     BindingFlags.Static |
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Public);

            Object instance = Activator.CreateInstance(classType);
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            var classType = Type.GetType("Stealer." + className);

            var classFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            AppendPublicFields(sb, classFields);

            var classPrivateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            AppendPrivateMethods(sb, classPrivateMethods);

            var classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            AppendPublicMethods(sb, classPublicMethods);

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] privateMethods = classType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void AppendPublicFields(StringBuilder sb, FieldInfo[] classFields)
        {
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        private static void AppendPrivateMethods(StringBuilder sb, MethodInfo[] classPrivateMethods)
        {
            foreach (var method in classPrivateMethods
                .Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
        }

        private static void AppendPublicMethods(StringBuilder sb, MethodInfo[] classPublicMethods)
        {
            foreach (var method in classPublicMethods
                .Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
        }
    }
}
