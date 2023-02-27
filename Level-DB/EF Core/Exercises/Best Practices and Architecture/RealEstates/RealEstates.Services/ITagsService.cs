namespace RealEstates.Services
{
    public interface ITagsService
    {
        void Add(string name, int? importance = null);

        void BulkTagToProperties(); //този метод ще трябва да мине през всеки имот и да му сложи таг
    }
}
