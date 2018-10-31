using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_3010
{
    /*1. Создать список чисел кол-вом 100 шт, значения любые
2. Пройтись по списку и удалить из списка все числа, которые делятся на цело на 3
3. Посчитать сумму нового списка
4. На основе полученного списка из пункта 2 Создать новый список,
состоящий из объекта (класс или структура состоящие из двух полей – index и value)
в котором index это позиции в списке из пункта 2, а value это значение.
5. Вывести список из 4 пункта на консоль через “; ” в формате:
для каждого элемента “index-value; ” ( бонус – используя агрегатную функцию)
6. Бонус!!! Все задачи выше решены с использованием linq*/
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            Console.WriteLine("Введите  пункт: ");
            k = Int32.Parse(Console.ReadLine());
            switch (k)
            {
                case 1:
                    {   List<int> num = new List<int>();
                        Random rnd = new Random();
                        int i = 100;
                        while (i > 0)
                        {
                            num.Add(rnd.Next(1000));
                            i--;
                        }
                        Console.WriteLine("1. Список");
                        foreach (int j in num)
                        {
                            Console.WriteLine(j);
                        }
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Кол-во элементов: {0}", num.Count);
                        Console.WriteLine("-----------------------------------------------------");

                        Console.WriteLine("2. Список:");
                        List<int> num1 = new List<int>();
                        foreach (int item in num)
                        {
                            if (item % 3 != 0)
                            {
                                num1.Add(item);
                            }
                        }
                        foreach (int j in num1)
                        {
                            Console.WriteLine(j);
                        }
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Кол-во элементов без чисел, которые делятся на цело на 3: {0}", num1.Count);

                        Console.WriteLine("------------------------------------------------");
                        int sum = num1.ToArray().Sum();
                        Console.WriteLine("3.Сумма элементов 2-го списка: {0}", sum);

                        Console.WriteLine("----------------------------------------------------");
                        List<NewList> newArr = new List<NewList>();
                       
                        foreach (int item in num1)
                        {                           
                            NewList tmp = new NewList();
                            tmp.index =num1.IndexOf(item);
                            tmp.value = item;
                            newArr.Add(tmp);
                        }

                        Console.WriteLine("4-5. Список");

                        foreach (NewList item in newArr)
                        {
                            Console.WriteLine("{0} - {1}; ", item.index, item.value);
                        }
                    }
                    break;

                //LINQ
                case 2:
                    {
                        int[] numbers = new int[100];
                        Random rnd = new Random();
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            numbers[i] = rnd.Next(1000);
                        }

                        Console.WriteLine("1. Список");
                        foreach (int j in numbers)
                        {
                            Console.Write("{0};",j);
                        }
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------------");
                        int count = numbers.Count();
                        Console.WriteLine("Кол-во элементов: {0}", count);
                        Console.WriteLine("-----------------------------------------------------");

                        var numQuery =
                            from num in numbers
                            where (num % 3) != 0
                            select num;

                        Console.WriteLine("2. Список");
                        foreach (int num in numQuery)
                        {
                            Console.Write("{0};", num);
                        }
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------------");
                        int count1 = numQuery.Count();
                        Console.WriteLine("3.Кол-во элементов без чисел, которые делятся на цело на 3: {0}", count1);
                        Console.WriteLine("-----------------------------------------------------");
                        /*4. На основе полученного списка из пункта 2 Создать новый список,
                        состоящий из объекта (класс или структура состоящие из двух полей – index и value)
                        в котором index это позиции в списке из пункта 2, а value это значение.*/

                        var newArr = numQuery
                            .Select((i, index) => new { index, i });

                        foreach (var item in newArr)
                            Console.Write("{0};", item);
                    }
                    break;               
            }
        }
    }
}
