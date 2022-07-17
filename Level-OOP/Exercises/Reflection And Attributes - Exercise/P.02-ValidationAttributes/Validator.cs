namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj) //here i will get obj = Person
        {
            PropertyInfo[] classProperties = obj.GetType().GetProperties(); //go through person's properties

            foreach (var property in classProperties)
            {
                var propertyAttributes = property.GetCustomAttributes() //take the created custom attributes
                    .Where(x => x.GetType() //which are inherited from MyValidationAttribte
                    .IsSubclassOf(typeof(MyValidationAttribute)))
                    .ToArray();

                foreach (MyValidationAttribute attribute in propertyAttributes) //cast them to MyValidationAttribute
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj)); //check if for example Person's FullName is valid

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
