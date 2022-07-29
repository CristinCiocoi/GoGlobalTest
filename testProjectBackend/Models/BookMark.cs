namespace testProjectBackend.Models
{
    public class BookMark : BaseEntity
    {
        public string NameRepository { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
    }
}