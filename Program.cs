﻿using static System.Console;

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
            IEnumerable<Запись> списокБ = new List<Запись>()
            {
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 73 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 184 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 24 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 91 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 2 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 354 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 13 },
                new Запись() { ПервоеСвойство = "морковь", ВтороеСвойство = 101 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 72 },
                new Запись() { ПервоеСвойство = "тыква", ВтороеСвойство = 4 },
                new Запись() { ПервоеСвойство = "капуста", ВтороеСвойство = 88 },
            };

            // Сначала сгруппируем списокБ по первому свойству:
            IEnumerable<IGrouping<string, Запись>> группыБ
                = списокБ.GroupBy(запись => запись.ПервоеСвойство);

            // Теперь создадим словарь из групп, образованных из спискаБ:
            IDictionary<string, IGrouping<string, Запись>> словарьБ
                = группыБ.ToDictionary(группа => группа.Key);

            WriteLine(группыБ.Count());
            WriteLine(словарьБ.Count());

            // Теперь мы можем обходить списокА, обращаясь к словарюБ на каждой итерации:
            foreach(Запись запись in списокА)
            {
                // Теперь мы можем обращаться к словарю, как к списку
                // с индексом ПервоеСвойство вместо числового индекса:
                if (словарьБ.ContainsKey(запись.ПервоеСвойство))
                {
                    WriteLine($"Сумма по спискуБ: {словарьБ[запись.ПервоеСвойство].Sum(x => x.ВтороеСвойство)}");
                }
            }
        }
    }
}
