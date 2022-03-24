namespace GroceryStore.Api.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsNormalized(this string value, string valueToCompare)
        {
            return value
                .ToLower()
                .Contains(valueToCompare.Trim().ToLower());
        }
    }
}
