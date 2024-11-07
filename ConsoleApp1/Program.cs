using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student // Студенты
    {
        // Закрытые поля
        private string lastName; // Фамилия студа
        private string firstName; // Имя студа
        private string middleName; // Отчество студа
        private DateTime birthDate; //Даты рождения студента
        private int course; //Курс
        private string group; // Группа

        // Конструктор
        public Student(string lastName, string firstName, string middleName, DateTime birthDate, int course, string group)
        {
            LastName = lastName; // Используем свойства для проверки
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate; //Дата рождения
            Course = course; //Курс
            Group = group; // Группа
        }

        // Открытые свойства с проверкой корректности
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой.");
                lastName = value;
            }
        }

        public string FirstName // Открытая 
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не пустое.");
                firstName = value;
            }
        }

        public string MiddleName //Отчество
        {
            get => middleName; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Отчество не пустое.");
                middleName = value;
            }
        }

        public DateTime BirthDate //Даты рождения
        {
            get => birthDate;
            set
            {
                if (value >= DateTime.Now)
                    throw new ArgumentException("Дата рождения не может быть в будущем времени.");
                birthDate = value;
            }
        }

        public int Course // Крусы
        {
            get => course;
            set
            {
                if (value < 1 || value > 6) // Курс от 1 до 6
                    throw new ArgumentOutOfRangeException("Курс должен быть от 1 до 6.");
                course = value;
            }
        }

        public string Group //Группа
        {
            get => group;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Группа не пустая.");
                group = value;
            }
        }

        // Метод для вывода информации о студенте
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Дата рождения: {BirthDate.ToShortDateString()}, Курс: {Course}, Группа: {Group}";
        }
        internal class Program // Месяцы
        {
            static async Task Main(string[] args) // выбор задачки
            {
                Console.OutputEncoding = Encoding.UTF8;
                while (true) // Бесконечный цикл
                {
                    Console.WriteLine("Выберите задачу для выполнения:");
                    Console.WriteLine("1 - Задача 1");
                    Console.WriteLine("2 - Задача 2");
                    Console.WriteLine("0 - Выйти");

                    string choice = Console.ReadLine();
                    Task selectedTask = null;

                    switch (choice)
                    {
                        case "1":
                            selectedTask = Task1();
                            break;
                        case "2":
                            selectedTask = Task2();
                            break;
                        case "0":
                            Console.WriteLine("Выход из программы.");
                            return;
                        default:
                            Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                            break;
                    }

                    if (selectedTask != null)
                    {
                        await selectedTask;
                        Console.WriteLine("Задача завершена.");
                    }

                    Console.WriteLine("");
                }
            }
            static async Task Task1()
            {
                {
                    // Массив месяцев
                    string[] teams = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль",
                "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

                    // Значение длины
                    int n = 4; 

                    // 1. Запрос, выбирающий месяцы с длиной строки равной n
                    var monthsWithLengthN = teams.Where(m => m.Length == n);
                    Console.WriteLine("Месяцы с длиной строки в 4 символа: ");
                    foreach (var month in monthsWithLengthN)
                    {
                        Console.WriteLine(month);
                    }
                    Console.WriteLine();

                    // 2. Запрос, возвращающий только летние и зимние месяцы
                    var LetoAndZima = teams.Where(m => m == "Июнь" || m == "Июль" || m == "Август" ||
                    m == "Декабрь" || m == "Январь" || m == "Февраль");
                    Console.WriteLine("Летние и зимние месяцы:");
                    foreach (var month in LetoAndZima)
                    {
                        Console.WriteLine(month);
                    }
                    Console.WriteLine();

                    // 3. Запрос вывода месяцев в алфавитном порядке (сортировка в алфавитном порядке)
                    var sortedMonths = teams.OrderBy(m => m);// тут работает алфавит путем сравнивания
                    Console.WriteLine("Месяцы в алфавитном порядке:");
                    foreach (var month in sortedMonths)
                    {
                        Console.WriteLine(month);
                    }
                    Console.WriteLine();

                    // 4. Запрос, подсчитывающий месяцы, содержащие букву "а,б,в...." и длиной имени не менее 4-х
                    var countMonthsWithU = teams.Count(m => m.ToLower().Contains('и') && m.Length >= 4); //ToLower-это нижний регистер проверяет заглавные буквы
                    Console.WriteLine($"Количество месяцев, содержащих букву 'и' и длиной не менее 4-х: {countMonthsWithU}");
                }
                Console.WriteLine();
                /*string[] teams = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", 
                    "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

                var selectedTeams = new List<string>();
                foreach (string s in teams)
                {
                    if (s.ToUpper().StartsWith("Б"))
                        selectedTeams.Add(s);
                }
                selectedTeams.Sort();
                var selectedTeams = from t in teams // определяем каждый объект из teams как t
                                    where t.ToUpper().StartsWith("Б") //фильтрация по критерию
                                    orderby t // упорядочиваем по возрастанию
                                    select t; // выбираем объект
                foreach (string s in selectedTeams)
                    Console.WriteLine(s);*/

                //}

            }
            static async Task Task2()
            {
                try
                {
                    // Создаем список студентов
                    List<Student> students = new List<Student>
                {
                    new Student("Зорро", "Илья", "Алексеевич", new DateTime(2000, 6, 16), 2, "Группа АВТ-313"),
                    new Student("Мантлеров", "Кристин", "Сергеевич", new DateTime(2002, 8, 20), 2, "Группа АВТ-313"),
                    new Student("Кокунов", "Андрэ", "Алексеевич", new DateTime(2000, 12, 5), 2, "Группа АВТ-313"),
                    new Student("Новохатск", "Некиш", "Серович", new DateTime(2001, 3, 10), 2, "Группа АВТ-313"),
                    new Student("Савченко", "Владос", "Эдуардович", new DateTime(1999, 11, 25), 2, "Группа АВТ-313")
                };

                    // Те самые запросы LINQ
                    // Список студентов заданного курса (например, курс 2)
                    var studKurs2 = students.Where(s => s.Course == 2).ToList();
                    Console.WriteLine();
                    Console.WriteLine("Студенты курса 2:");
                    foreach (var student in studKurs2)
                    {
                        Console.WriteLine(student);
                    }

                    // Самый молодой студент
                    var youngestStudent = students.OrderBy(s => s.BirthDate).LastOrDefault();//почему старый студент?
                    Console.WriteLine();
                    Console.WriteLine($"Самый молодой студент: {youngestStudent}");
                    Console.WriteLine();

                    // Количество студентов заданной группы (например, "Группа АВТ-313")
                    var groupCount = students.Count(s => s.Group == "Группа АВТ-313");
                    Console.WriteLine($"Количество студентов в 'Группа АВТ-313': {groupCount}");
                    Console.WriteLine();

                    // Первый студент с заданным именем (например, "Илья")
                    var firstStudentNamedPetr = students.FirstOrDefault(s => s.FirstName == "Илья");
                    Console.WriteLine($"Первый студент с именем 'Илья': {firstStudentNamedPetr}");
                    Console.WriteLine();

                    // Список студентов, упорядоченных по фамилии
                    var orderedStudents = students.OrderBy(s => s.LastName).ToList();
                    Console.WriteLine("Студенты, упорядоченные по фамилии:");
                    foreach (var student in orderedStudents)
                    {
                        Console.WriteLine(student);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
