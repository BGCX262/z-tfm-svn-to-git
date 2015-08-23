namespace Zelenjava.Model.Entities
{
    public class Photo
    {
        public virtual int Id { get; private set; }

        public virtual PhotoType Type { get; set; }

        public virtual string Description { get; set; }

        public virtual byte[] Content { get; set; }

        public virtual Article Article { get; set; }

        public Photo(){}

        public Photo(PhotoType type, string description, byte[] content)
        {
            Type = type;
            Description = description; 
            Content = content;
        }
    }
}