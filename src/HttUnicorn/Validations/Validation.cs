using HttUnicorn.Exceptions;

namespace HttUnicorn.Validations
{
    public static class Validation
    {
        public static void ValidateEmptyKey(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyKeyUnicornException($"{key} shouldn't be empty", key);
        }
    }
}
