using System.Text;
using static System.Console;

namespace Assembly
{
    public class Запись
    {
        private string первоеСвойство = String.Empty;
        public string ПервоеСвойство
        {
            get => первоеСвойство;
            set => первоеСвойство = value;
        }
        private int второеСвойство = 0;
        public int ВтороеСвойство
        {
            get => второеСвойство;
            set => второеСвойство = value;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Запись> списокА = new List<Запись>()
            {
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 73 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 184 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 24 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 91 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 2 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 354 },
                new Запись() { ПервоеСвойство = "кабачок", ВтороеСвойство = 199 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 13 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 101 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 72 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 4 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 88 },
                new Запись() { ПервоеСвойство = "кабачок", ВтороеСвойство = 724 },
                new Запись() { ПервоеСвойство = "кабачок", ВтороеСвойство = 45 },
            };

            // СписокБ меньше, чем списокА. В списке списокБ нет кабачка:
            // Значения Второго свойства также отличаются от списка А:
            IEnumerable<Запись> списокБ = new List<Запись>()
            {
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 95 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 546 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 24 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 97 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 2 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 376 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 11 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 34 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 72 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 14 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 83 },
            };

            // Сначала сгруппируем списокБ по первому свойству:
            // Первый тип у IGrouping - это тип ключа (в данном случае string)
            IEnumerable<IGrouping<string, Запись>> группыБ
                = списокБ.GroupBy(запись => запись.ПервоеСвойство);

            // Теперь создадим словарь из групп, образованных из спискаБ:
            // Ключами для словаря станут ключи групп:
            IDictionary<string, IGrouping<string, Запись>> словарьБ
                = группыБ.ToDictionary(группа => группа.Key);

            // Поддержка кириллицы в консили:
            Console.OutputEncoding = Encoding.UTF8;
            
            // Теперь мы можем обходить списокА, обращаясь к словарюБ на каждой итерации:
            foreach(Запись запись in списокА)
            {
                // Теперь мы можем обращаться к словарю, как к списку
                // с индексом ПервоеСвойство вместо числового индекса:
                if (словарьБ.ContainsKey(запись.ПервоеСвойство))
                {
                    WriteLine($"Сумма по спискуБ: {запись.ПервоеСвойство} = {словарьБ[запись.ПервоеСвойство].Sum(x => x.ВтороеСвойство)}");
                }
                // Если в словареБ нет конкретного ПервогоСвойства, то вместо
                // суммы выводим текстовое сообщение:
                else
                {
                    WriteLine($"Сумма по спискуБ: {запись.ПервоеСвойство} = свойства нет в списке Б");
                }
            }

            // Вывод:
            // Сумма по спискуБ: капуста = 554
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: тыква = 110
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: капуста = 554
            // Сумма по спискуБ: кабачок = свойства нет в списке Б
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: тыква = 110
            // Сумма по спискуБ: тыква = 110
            // Сумма по спискуБ: капуста = 554
            // Сумма по спискуБ: кабачок = свойства нет в списке Б
            // Сумма по спискуБ: кабачок = свойства нет в списке Б

            WriteLine("\nСравнение списков:\n");

            // Если нам не нужно обходить весь список А,
            // а только сравнить список А и список Б,
            // и затем по совпадающим позициям (только по первомуСвойству) взять суммы
            // по значениям первогоСвойства из Б:
            // Мы проходимся только по тем первымСвойствам,
            // которые есть и в списке А, и в списке Б
            foreach (string первоеСвойство in списокА
                .Select(x => x.ПервоеСвойство)
                .Intersect(словарьБ.Select(элемент => элемент.Key)))
            {
                // Затем также выводим сумму:
                WriteLine($"Сумма по спискуБ: {первоеСвойство} = {словарьБ[первоеСвойство].Sum(x => x.ВтороеСвойство)}");
            }

            // Вывод:
            // Сумма по спискуБ: капуста = 554
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: тыква = 110

            // Способ 3:
            WriteLine("\nСпосов 3:\n");
            foreach (string первоеСвойство in списокБ
                // сначала группируем списокБ по первомуСвойству
                .GroupBy(запись => запись.ПервоеСвойство)
                // делаем из него список первыхСвойств (теперь это ключи)
                .Select(x => x.Key)
                // выводим список совпадений первогоСвойства по А и по Б:
                .Intersect(списокА.Select(элемент => элемент.ПервоеСвойство)))
            {
                // Затем также выводим сумму по значениям первогоСвойства из спискаБ:
                WriteLine($"Сумма по спискуБ: {первоеСвойство} = {словарьБ[первоеСвойство].Sum(x => x.ВтороеСвойство)}");
            }

            // Вывод:
            // Сумма по спискуБ: капуста = 554
            // Сумма по спискуБ: морковь = 690
            // Сумма по спискуБ: тыква = 110
        }
    }
}
