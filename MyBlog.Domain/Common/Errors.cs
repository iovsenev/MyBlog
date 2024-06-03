namespace MyBlog.Domain.Common;

public static class Errors
{
    public static class General
    {
        public static Error NotFound(string? name = null)
        {
            var message = name == null
                ? ""
                : $": {name}";
            return new Error("obj.not.found", $"This {message} not found");
        }

        public static Error InValid(object? obj = null)
        {
            var message = obj == null
                ? ""
                : $": {nameof(obj)}";
            return new Error("obj.invalid", $"Object{message} has invalid value");
        }

        public static Error AlreadyExists(string? message = null)
        {
            message = message == null
                ? "Object already exist"
                : $": {message}";
            return new Error("obj.already.exist", $"{message}");
        }

        public static Error AddingFalling(string? name = null)
        {
            var message = name == null
                ? ""
                : $": {name}";
            return new Error("obj.already.exist", $"Object {message} is not added");
        }
    }
}
