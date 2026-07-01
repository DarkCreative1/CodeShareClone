namespace CodeShareClone.Models
{
    public class Code
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Content { get; set; } = string.Empty;
    }
}