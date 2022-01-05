namespace StateManagementMVC.Models
{
    public class Person
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; } = default!;
        public string Email { get; set; } = default!;

        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }
}
