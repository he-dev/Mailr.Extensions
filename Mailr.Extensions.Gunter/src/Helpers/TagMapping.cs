namespace Mailr.Extensions.Gunter.Helpers
{
    public static class TagMapping
    {
        public static string GetClass(string tag)
        {
            return tag.ToLower() switch
            {
                "level" => "test-case-level",
                "trace" => "log-level-trace",
                "debug" => "log-level-debug",
                "information" => "log-level-information",
                "warning" => "log-level-warning",
                "error" => "log-level-error",
                "fatal" => "log-level-fatal",
                _ => string.Empty
            };
        }
    }
}