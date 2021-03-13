using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для создания новой записи введите 'Создать'");
            Console.WriteLine("Для редактирования записей введите 'Редактировать'");
            Console.WriteLine("Для удаления записей введите 'Удалить'");
            Console.WriteLine("Для просмотра всех записей целиком введите 'Просмотреть'");
            Console.WriteLine("Для просмотра всех записей с краткой информации введите 'Кратко'");
            Console.WriteLine("Для закрытия записной книжки нажмите 'Закрыть'");
            Console.WriteLine();

            string command = Console.ReadLine();
            command = command.ToLower();
            Notebook nb = new Notebook();
            while (command != "закрыть")
            {
                if (command == "создать")
                    nb.Create();
                else if (command == "редактировать")
                    nb.Change();
                else if (command == "просмотреть")
                    nb.ShowFull();
                else if (command == "кратко")
                    nb.Show();
                else if (command == "удалить")
                    nb.Delete();
                else
                    Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");

                Console.WriteLine();
                Console.WriteLine("Для создания новой записи введите 'Создать'");
                Console.WriteLine("Для редактирования записей введите 'Редактировать'");
                Console.WriteLine("Для удаления записей введите 'Удалить'");
                Console.WriteLine("Для просмотра всех записей целиком введите 'Просмотреть'");
                Console.WriteLine("Для просмотра всех записей с краткой информации введите 'Кратко'");
                Console.WriteLine("Для закрытия записной книжки нажмите 'Закрыть'");
                Console.WriteLine();

                command = Console.ReadLine().ToLower();
            }

        }
    }

    class Record
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string Organisation { get; set; }
        public string Position { get; set; }
        public string Other { get; set; }

        public Record (string surname, string name, string secondName, string number, string country,
            string dateOfBirth, string organisation, string position, string other)
        {
            Surname = surname;
            Name = name;
            SecondName = secondName;
            Number = number;
            Country = country;
            DateOfBirth = dateOfBirth;
            Organisation = organisation;
            Position = position;
            Other = other;
        }
    }

    class Notebook
    {
        public static List<Record> records = new List<Record>();

        public void Create()
        {
            Console.WriteLine("Введите фамилию: ");
            string s = Console.ReadLine();
            if (s == "")
            {
                Console.WriteLine("Поле не должно быть пустым: ");
                s = Console.ReadLine();
            }

            Console.WriteLine("Введите имя: ");
            string n = Console.ReadLine();
            if (n == "")
            {
                Console.WriteLine("Поле не должно быть пустым: ");
                n = Console.ReadLine();
            }

            Console.WriteLine("Введите отчество (необязательно): ");
            string sn = Console.ReadLine();

            Console.WriteLine("Введите номер телефона: ");
            string num = Console.ReadLine();
            if (num == "")
            {
                Console.WriteLine("Поле не должно быть пустым: ");
                num = Console.ReadLine();
            }
            int a;
            bool isNum = int.TryParse(num, out a);
            if (!isNum)
            {
                Console.WriteLine("Поле должно состоять только из цифр: ");
                num = Console.ReadLine();
            }

            Console.WriteLine("Введите страну: ");
            string c = Console.ReadLine();
            if (c == "")
            {
                Console.WriteLine("Поле не должно быть пустым: ");
                c = Console.ReadLine();
            }

            Console.WriteLine("Введите дату рождения в формате ДД.ММ.ГГГГ (необязательно): ");
            string d = Console.ReadLine();

            Console.WriteLine("Введите организацию (необязательно): ");
            string o = Console.ReadLine();

            Console.WriteLine("Введите должность (необязательно): ");
            string p = Console.ReadLine();

            Console.WriteLine("Введите прочие заметки (необязательно): ");
            string oth = Console.ReadLine();

            Record r = new Record(s, n, sn, num, c, d, o, p, oth);
            records.Add(r);
        }

        public void Delete()
        {
            records.Clear();
        }

        public void ShowFull()
        {
            string res = "";
            for (int i = 0; i < records.Count; i++)
            {
                res += records[i].Surname + " " + records[i].Name + " ";

                if (records[i].SecondName != "")
                    res += records[i].SecondName + " ";

                res += records[i].Number + " " + records[i].Country;

                if (records[i].DateOfBirth != "")
                    res += " " + records[i].DateOfBirth;

                if (records[i].Organisation != "")
                    res += " " + records[i].Organisation;

                if (records[i].Position != "")
                    res += " " + records[i].Position;

                if (records[i].Other != "")
                    res += " " + records[i].Other;

                res += "\n";
            }
            Console.WriteLine(res);
        }

        public void Show()
        {
            for (int i = 0; i < records.Count; i++)
            {
                Console.WriteLine(records[i].Surname + " " + records[i].Name + " " + records[i].Number);
            }
        }

        public void Change()
        {
            Console.WriteLine("Введите фамилию и имя того, чью запись вы хоите отредактировать: ");
            string[] fullName = Console.ReadLine().Split(' ');
            int i = 0;
            while ((records[i].Surname != fullName[0]) && (records[i].Name != fullName[1]))
            {
                i++;
            }
            Console.WriteLine("Введите название поля, которое вы хотите поменять (Фамилия|Имя|Отчество|Номер|Дата|Страна|Организация|Должность|Заметки): ");
            string c = Console.ReadLine();
            c = c.ToLower();
            Console.WriteLine("Введите измененные данные: ");
            string d = Console.ReadLine();

            if (c == "фамилия")
            {
                if (d == "")
                {
                    Console.WriteLine("Поле не должно быть пустым: ");
                    d = Console.ReadLine();
                    records[i].Surname = d;
                }
                else records[i].Surname = d;

            }
            else if (c == "имя")
            {
                if (d == "")
                {
                    Console.WriteLine("Поле не должно быть пустым: ");
                    d = Console.ReadLine();
                    records[i].Name = d;
                }
                else
                    records[i].Name = d;
            }
            else if (c == "отчество")
            {
                records[i].SecondName = d;
            }
            else if (c == "номер")
            {
                if (d == "")
                {
                    Console.WriteLine("Поле не должно быть пустым: ");
                    d = Console.ReadLine();
                    records[i].Number = d;
                }
                int a;
                bool isNum = int.TryParse(d, out a);
                if (!isNum)
                {
                    Console.WriteLine("Поле должно состоять только из цифр: ");
                    d = Console.ReadLine();
                    records[i].Number = d;
                }
                else
                    records[i].Number = d;
            }
            else if (c == "дата")
            {
                records[i].DateOfBirth = d;
            }
            else if (c == "страна")
            {
                records[i].Country = d;
            }
            else if (c == "организация")
            {
                records[i].Organisation = d;
            }
            else if (c == "должность")
            {
                records[i].Position = d;
            }
            else if (c == "заметки")
            {
                records[i].Other = d;
            }
            else Console.WriteLine("Что-то пошло не так, попробуйте заново.");
        }
    }
}
