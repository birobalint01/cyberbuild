using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using WebshopAPI.Lib.Exceptions;

namespace WebshopAPI.Lib.Services
{
    public class ObjectValidatorService<TObject> where TObject : class
    {
        TObject myObject;

        public ObjectValidatorService(TObject myObject)
        {
            this.myObject = myObject;
        }

        public void IsValid()
        {
            PropertyInfo[] props = myObject.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
                {
                    if (prop.GetValue(myObject) == null || string.IsNullOrEmpty(prop.GetValue(myObject).ToString()))
                    {
                        throw new MandatoryPropertyEmptyException(prop.Name);
                    }
                }
                if (Attribute.IsDefined(prop, typeof(EmailAddressAttribute)))
                {
                    string value = prop.GetValue(myObject).ToString();

                    if (!value.Contains("@") ||
                        value.IndexOf("@") == value.Length - 1 ||
                        value.IndexOf("@") == 0 ||
                        value.CountOf('@') > 1
                        )
                    {
                        throw new InvalidPropertyValueException(prop.Name, "e-mail cím");
                    }
                }
            }
        }
    }
}
