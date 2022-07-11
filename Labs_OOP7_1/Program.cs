using System.Collections;

abstract class phoneBook:IComparable<phoneBook>
{
    public string phoneNumber { get; set; }
    public string address { get; set; }
    public string surname { get; set; }
    public string name { get; set; }
    public string fax { get; set; }
    public string birhtdayDate { get; set; }



    public int CompareTo(phoneBook other)
    {
        return surname.CompareTo(other.surname);
    }

    public abstract void ShowInfo();

}
public interface IComparable
{
    public int CompareTo(object o);
}
class person : phoneBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: " + surname);
        Console.WriteLine("Адресс: " + address);
        Console.WriteLine("Номер телефона: " + phoneNumber);
    }
}

class organization : phoneBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: " + name);
        Console.WriteLine("Адресс: " + address);
        Console.WriteLine("Номер телефона: " + phoneNumber);
        Console.WriteLine("Факс: " + fax);
        Console.WriteLine("Контактное лицо: " + surname);

    }

}

class friend : phoneBook
{

    public void setBirtdayDate(string birtdayDate)
    {
        this.birhtdayDate = birtdayDate;
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: " + surname);
        Console.WriteLine("Адресс: " + address);
        Console.WriteLine("Номер телефона: " + phoneNumber);
        Console.WriteLine("Дата рождения: " + birhtdayDate);
    }

}



class Program
{

    static void printPhoneBook(phoneBook[] pb)
    {
        Console.WriteLine("Телефонная книга\n--------------------\n");
        foreach (var phonebook in pb)
        {
            phonebook.ShowInfo();
            Console.WriteLine("--------------------\n");
        }
        return;
    }

    static void printPhoneBook(phoneBook[] pb, string surname)
    {
        Console.WriteLine("Телефонная книга\n--------------------\n");
        foreach (var phonebook in pb)
        {
            if (phonebook.surname == surname)
            {
                phonebook.ShowInfo();
                Console.WriteLine("--------------------\n");
            }
        }
        return;
    }

    public static void Main(string[] args)
    {
        string[] surnames = new string[] { "Грибоедов", "Пушкин", "Заболоцкий", "Булгаков", "Платонов", "Лермонтов", "Уэлс", "Васильев", "Андреев" };
        string[] names = new string[] { "Стальплав", "Кафе мороженное", "МойкаАвто", "Salon svyazi", "Отелье мотелье", "Нефтянка", "Гудронстрой" };
        string[] streetNames = new string[] { "Советская", "Карла Маркса", "Комсомольская", "Чичерина", "Мичуринская" };
        Random rnd = new Random();
        List<phoneBook> pbook = new List<phoneBook>();
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 5; j++, i++)
            {
                phoneBook p = new person();
                p.surname = surnames[rnd.Next(surnames.Length)];
                p.address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                p.phoneNumber = rnd.Next(100000, 999999).ToString();
                pbook.Add(p);
            }

            for (int j = 0; j < 5; j++, i++)
            {
                phoneBook p = new organization();
                p.name = names[rnd.Next(0, names.Length)];
                p.address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                p.phoneNumber = rnd.Next(100000, 999999).ToString();
                p.fax = rnd.Next(999999).ToString();
                p.surname = surnames[rnd.Next(surnames.Length)];
                pbook.Add(p);
            }

            for (int j = 0; j < 5; j++, i++)
            {
                phoneBook p = new friend();
                p.surname = surnames[rnd.Next(surnames.Length)];
                p.address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                p.phoneNumber = rnd.Next(100000, 999999).ToString();
                p.birhtdayDate = rnd.Next(30).ToString() + "." + rnd.Next(12).ToString() + "." + rnd.Next(1950, 2000).ToString();
                pbook.Add(p);
            }
        }
        //string c = "";
        //printPhoneBook(pbook);
        //while (true)
        //{
        //    Console.WriteLine("Введите фамилию для поиска:\nДля выхода введите 'ex'\nЧтобы вывести всё — 'all'");
        //    c = Console.ReadLine();
        //    if (c == "ex")
        //    {
        //        return;
        //    }
        //    if (c == "all")
        //    {
        //        printPhoneBook(pbook);
        //        continue;
        //    }
        //    Console.Clear();
        //    printPhoneBook(pbook, c);
        //}
        pbook.Sort();
        foreach (var p in pbook)
        {
            Console.WriteLine(p.surname);
        }
    }
}

