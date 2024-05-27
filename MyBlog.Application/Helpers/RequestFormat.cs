namespace MyBlog.Application.Helpers
{
    public class RequestFormat
    {

        public object? Result { get; }
        public Dictionary<string, string[]>? Errors { get; }
        public DateTime TimeGenerated { get; }

        private RequestFormat(object? result,
            Dictionary<string, string[]>? errors)
        {
            Result = result;
            Errors = errors;
            TimeGenerated = DateTime.Now;
        }

        public static RequestFormat Ok(object? result)
        {
            return new(result, null);
        }

        public static RequestFormat Error(Dictionary<string, string[]>? errors)
        {
            return new(null, errors);
        }
    }
}
