namespace Zelenjava.Model.Entities
{
    public class Author
    {
        public virtual int Id { get; private set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Initials { get; set; }

        public Author(){}

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = lastName + " " + firstName;
            Initials = LastName[0] + "." + FirstName[0] + ".";
        }
    }
}