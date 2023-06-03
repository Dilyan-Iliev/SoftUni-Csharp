namespace HouseRentingSystem.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class DecimalModelBinderProvider
        : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Decimal)
                || context.Metadata.ModelType == typeof(Decimal?))
            {// проверяваме дали типа на полетата са от съответния тип, който bind-ваме

                return new DecimalModelBinder();
            }

            return null; //връщаме null, за да укажем, че не става с този model binder,
                         //да пробва със следващия подаден model binder
        }
    }
}
