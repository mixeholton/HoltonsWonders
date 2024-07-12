namespace MixeWonders.Values
{
    public class DomainException : Exception
    {
        public string Title { get; }

        public string Description { get; }

        public DomainException(string title, string description)
            : base(title + ": " + description)
        {
            Title = title;
            Description = description;
        }
    }
}
