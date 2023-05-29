namespace MvcLibraryApp.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Language { get; set; }//checkboxlist ya da dropdownlist yapılacak
        public int Number { get; set; }
    }
}
