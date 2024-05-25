namespace MyBlog.Application.Halpers
{
    public class Envelope
    {

        public object? Result { get; }
        public Dictionary<string, string[]>? Errors { get; }
        public DateTime TimeGenerated { get; }

        private Envelope(object? result,
            Dictionary<string, string[]>? errors)
        {
            Result = result;
            Errors = errors;
            TimeGenerated = DateTime.Now;
        }

        public static Envelope Ok(object? result)
        {
            return new(result, null);
        }

        public static Envelope Error(Dictionary<string, string[]>? errors)
        {
            return new(null, errors);
        }
    }
}
