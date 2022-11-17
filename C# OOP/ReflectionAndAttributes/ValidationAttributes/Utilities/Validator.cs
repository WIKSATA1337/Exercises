using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] objProperties = objectType
                .GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(attr => typeof(MyValidationAttribute).IsAssignableFrom(attr.AttributeType)))
                .ToArray();

            foreach (var validationProperty in objProperties)
            {
                object[] customAttributes = validationProperty
                    .GetCustomAttributes()
                    .Where(ca => 
                        typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray();
                object propValue = validationProperty.GetValue(obj);

                foreach (var customAttribute in customAttributes)
                {
                    MethodInfo isValidMethod = customAttribute.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(method => method.Name == "IsValid");

                    if (isValidMethod is null)
                    {
                        throw new InvalidOperationException("Custom attribute doesn't have IsValid method.");
                    }

                    bool result = (bool)isValidMethod
                        .Invoke(customAttribute, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
