
using System.Text;

namespace Data1
{
    class Program
    {
        static void Main(string[] args)
        {
            string myFilePath = @"C:\Users\Akvile\Documents\Datatry.csv";
            string myFile = File.ReadAllText(myFilePath);
            //Console.WriteLine(myFile); //reading

            string[] fileLines = myFile.Split(Environment.NewLine);

            LinkedList<Person> personList = new LinkedList<Person>();

            for (int i= 1; i < fileLines.Length; i++) // start from 1 to skip the header
            {
                string[] lineFields = fileLines[i].Split(";");
                
                Person person = new Person();

                person.Id = Int32.Parse(lineFields[0]);
                person.Name = lineFields[1];
                person.Surname = lineFields[2];

                personList.AddLast(person);
            }

            //foreach (var person in personList)
            //{
            //    Console.WriteLine(person);
            //}

            Person newPerson = new Person();

            Console.WriteLine("Enter new Id:");
            newPerson.Id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter name:");
            newPerson.Name = Console.ReadLine();

            Console.WriteLine("Enter surname:");
            newPerson.Surname = Console.ReadLine();

            personList.AddLast(newPerson); // adding newperson to the existing collection

            string modifiedFile = Person.GenerateCsvFile(personList);
            //Console.WriteLine(modifiedFile);

            File.WriteAllText(myFilePath, modifiedFile);

            Console.WriteLine("File is modified");

        }


    }


    struct Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person (int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return "ID: " + this.Id + "; Name: "+ this.Name + "; Surname:" + this.Surname;
        }

        public static string GenerateCsvFile (LinkedList<Person> list)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Id;Name;Surname");

            foreach (var person in list)
            {
                stringBuilder.AppendLine(person.Id + ";" + person.Name + ";" + person.Surname);
            }

            return stringBuilder.ToString(); // generated the file content
        }
    }

    //class Person
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }

    //    public Person(string name, string surname)
    //    {
    //        this.Name = name;
    //        this.Surname = surname;
    //    }


}
