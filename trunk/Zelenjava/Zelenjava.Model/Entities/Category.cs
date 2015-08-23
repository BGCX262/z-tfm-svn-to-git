namespace Zelenjava.Model.Entities
{
    public class Category
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public Category(){}

        public Category(string name)
        {
            Name = name;
        }
    }
}