namespace HouseRentingSystem.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;
    using System.Threading.Tasks;

    public class DecimalModelBinder
        : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName); //взимаме това което bind-ваме,
                                                     //като му подаваме нещото, което искаме да валидираме

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {//ако резултатът не е празен, т.е. важно е да видим дали изобщо имаме стойност,
                //която да bind-ваме

                decimal actualVaue = 0m;
                bool success = false;

                try
                {
                    string decimalValue = valueResult.FirstValue;//това е стойността ни като стринг

                    //ще имаме или точка или запетая като разделител
                    decimalValue = decimalValue.Replace(".", CultureInfo.CurrentCulture
                        .NumberFormat.NumberDecimalSeparator);
                    decimalValue = decimalValue.Replace(",", CultureInfo.CurrentCulture
                        .NumberFormat.NumberDecimalSeparator);
                    //това ще е нещото, което нашата машина (сървърът) разбира

                    actualVaue = Convert.ToDecimal(decimalValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,
                        fe, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualVaue);
                    //това е успешната стойност вече
                }
            }

            return Task.CompletedTask;
        }
    }
}
