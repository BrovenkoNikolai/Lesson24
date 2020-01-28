using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousMethod_LambdaExpressions_Urok24
{
    class Program
    {
        #region Для анонимного метода создан делегат
        public delegate int MyHandler(int i);
        #endregion
        static void Main(string[] args)
        #region АНОНИМНЫЙ МЕТОД И ОБЫЧНЫЙ + ЛЯМБДА-ВЫРОЖЕНИЯ
        {
            #region 1 Пример практический применения Лямбда-выражения с классом Lesson24
            var lesson24 = new Lesson24("Программирование C#");
            lesson24.Started += (sender, date) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(date);
            };

            lesson24.Start();
            #endregion
            #region 2 Пример практический применения Лямбда-выражения с применением LINQ
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var res = list.Aggregate((x, y) => x + y);
            Console.WriteLine(res);
            
            // Варианты анонимных методов:
            var result1 = Agr(list, delegate (int i)        // 1 вариант анонимного метода.
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            });

            var result2 = Agr(list, Method);                // 2 вариант анонимного метода

            var result3 = Agr(list, x => x * x * x * x);    // 3 вариант анонимного метода

            #endregion

            // В Делегат мы поместили анонимный метод
            #region Анонимный метод
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyHandler handler = delegate (int i)     // delegate (тип_аргумента аргумент1, тип_аргумента аргумент2), если нет одного аргумента, то скобки не указываются.
                {                                        // Реализация анонимного метода
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };

                //handler += Method;                      // Должно быть за комментировано при строке кода с  Method(88);  

                handler(result);
                handler(88);
                

                #region Лямбда-вырождения
                // Лямбда-вырождения (Основной плюс Лямбда-вырождения они позволяет динамически менять тип, так как он будет получен из делегата MyHandler)
                MyHandler lambdaHandler = (i) =>            // "=>" - Лямбда оператор
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };

                lambdaHandler(99);

                MyHandler lambdaHandler2 = (i) => i * i;    // Когда не нужно вводить данные как в предыдущей записи "Console.WriteLine(r);"

                #endregion
            }
            #endregion
            Console.ReadLine();
            Method(88);                                 //  В не анонимном мы можем обратиться к имени
        }
        #region 2 Пример практический применения Лямбда-выражения с применением LINQ коллекции и делегат
        public static int Agr(List<int> list, MyHandler handler)
        {
            int result = 0;

            foreach (var item in list)
            {
                result += handler(item);
            }

            return result;
        }
        #endregion
        // Обычный метод более правильный и удобный подход без анонимного метода.
        public static int Method(int i)
        {
            var r = i * i *i;
            Console.WriteLine(r);
            return r;
        }
        #endregion
    }
}
