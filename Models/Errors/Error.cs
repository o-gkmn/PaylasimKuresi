namespace Models.Errors
{
    public sealed class Error(int code, string Type, string description) : Exception(description)
    {
        public int Code { get; init; } = code;
        public string Description { get; init; } = description;
        public string Type { get; init; } = Type;
    }
}
