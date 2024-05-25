namespace MyBlog.Domain.Common
{
    public static class Errors
    {
        public static class General
        {
            public static Error NotFound(object? obj = null)
            {
                var message = obj == null
                    ? ""
                    : $": {nameof(obj)}";
                return new Error("obj.not.found", $"Object{message} not found");
            }

            public static Error InValid(object? obj = null)
            {
                var message = obj == null
                    ? ""
                    : $": {nameof(obj)}";
                return new Error("obj.invalid", $"Object{message} has invalid value");
            }
        }
    }
}
