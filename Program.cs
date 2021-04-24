using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Collection_lab
{
    class Program
    {

     

        static void Main()
        {

           CollectionType<Human>[] ss = new CollectionType<Human>[2];
            try
            {
                var st1 = new Student
                {
                    Weight = 105,
                    Height = 180,
                    FirstName = "Alexandr",
                    LastName = "Nozenko",
                    University = "Business and Law"
                };
                var st2 = new Student
                {
                    Weight = 60,
                    Height = 174,
                    FirstName = "Alexandr",
                    LastName = "Kotyukov",
                    University = "Business and Law"
                };
                var st3 = new Student
                {
                    Weight = 60,
                    Height = 176,
                    FirstName = "Vladislav",
                    LastName = "Sukharevich",
                    University = "Business and Law"
                };
                var st4 = new Student
                {
                    Weight = 78,
                    Height = 184,
                    FirstName = "Ivan",
                    LastName = "Zmushko",
                    University = "Business and Law"
                };
                var st5 = new Student
                {
                    Weight = 150,
                    Height = 165,
                    FirstName = "Zahar",
                    LastName = "Semin",
                    University = "Business and Law"
                };
                var wr1 = new Worker
                {
                    Weight = 75,
                    Height = 168,
                    FirstName = "Maslova",
                    LastName = "Maslova",
                    Salary = 578.4
                };
                var wr2 = new Worker
                {
                    Weight = 70,
                    Height = 180,
                    FirstName = "Roman",
                    LastName = "Pateichuk",
                    Salary = 1000.5
                };
                var wr3 = new Worker
                {
                    Weight = 99,
                    Height = 179,
                    FirstName = "Roman",
                    LastName = "Atroshkin",
                    Salary = 100
                };
  
                ss[0] = new CollectionType<Human> { st1, st2, wr1, wr2 };

             


             
                ss[0].Remove(wr2);
                ss[0].Remove(st1);
                ss[0].Sort();
                foreach (var human in ss[0])
                {
                    Console.WriteLine(human.ToString());
                }
                ss[1] = new CollectionType<Human>();
                ss[1].Add(st3);
                ss[1].Add(st4);
                ss[1].Add(st5);
                ss[1].Add(wr3);
                ss[1].Sort();
                foreach (var human in ss[1])
                {
                    Console.WriteLine(human.ToString());
                }
                var list = new List<CollectionType<Human>>();
                list.Add(ss[0]);
                list.Add(ss[1]);


                //orderBy
                Console.WriteLine("\nLinq To objects: OrderBy, ThenBy");
                var orderRes = ss[0].OrderBy(h => h.Height).ThenBy(h => h.Weight);
                foreach (var human in orderRes)
                {
                    Console.WriteLine(human);
                }
                

                //where
                Console.WriteLine("\nLinq To objects: Where");
                var whereRes = ss[0].Where(h => (h.Height > 170 && h.Weight >= 58) ||
               h.FullName.StartsWith("L"));
                foreach (var human in whereRes)
                    Console.WriteLine(human.ToString());
                //select
                Console.WriteLine("\nLinq To objects: Select");
                var selectRes = ss[0].Select((h, i) => new {
                    Index = i + 1,
                    h.FullName
                });
                foreach (var el in selectRes)
                {
                    Console.WriteLine(el);
                }
                //selectMany
                Console.WriteLine("\nLinq To objects: SelectMany");
                var selectManyRes = ss[0].SelectMany(h => h.FullName.Split(' '));
                foreach (var el in selectManyRes)
                    Console.WriteLine(el);
                //Skip
                Console.WriteLine("\nLinq To objects: Skip");
                var skipRes = ss[0].Skip(2);
                foreach (var human in skipRes)
                {
                    Console.WriteLine(human);
                }
                //SkipWhile
                Console.WriteLine("\nLinq To objects: SkipWhile");
                var skipWhileRes = ss[0].SkipWhile(h => h.Height < 190);
                foreach (var human in skipWhileRes)
                {
                    Console.WriteLine(human);
                }
                //Take
                Console.WriteLine("\nLinq To objects: Take");
                var takeRes = ss[0].Take(2);
                foreach (var human in takeRes)
                {
                    Console.WriteLine(human);
                }
                //TakeWhile
                Console.WriteLine("\nLinq To objects: TakeWhile");
                var takeWhileRes = ss[0].TakeWhile(h => h.Height < 190);
                foreach (var human in takeWhileRes)
                {
                    Console.WriteLine(human);
                }
                //Concat
                Console.WriteLine("\nLinq To objects: Concat");
                var concatRes = ss[0].Concat(ss[1]);
                foreach (var human in concatRes)
                {
                    Console.WriteLine(human);
                }
                //GroupBy
                Console.WriteLine("\nLinq To objects: GroupBy");
                var groupByRes = concatRes.Where(h => h is Student).GroupBy(h =>
               ((Student)h).University);
                foreach (var group in groupByRes)
                {
                    Console.WriteLine($"Group: {group.Key}, Count: {group.Count()}");
                    foreach (var human in group) Console.WriteLine(human);
                }
                //First
                Console.WriteLine("\nLinq To objects: First");
                var firstRes = concatRes.First(h => h.FullName.Length > 12);
                Console.WriteLine(firstRes);
                //FirstOrDefault
                Console.WriteLine("\nLinq To objects: FirstOrDefault");
                var firstOrDefRes = concatRes.FirstOrDefault(h => h.FullName.Length > 14);
                if (firstOrDefRes != null)
                    Console.WriteLine();
                //DefaultIfEmpty
                Console.WriteLine("\nLinq To objects: DefaultIfEmpty");
                var defaultIfEmptyRes = ss[1].Where(c => c.FirstName == "Eleanor")
                .DefaultIfEmpty(new Human
                {
                    FirstName = "Eleanor",
                    LastName = "Fuller"
                })
               .First();
                Console.WriteLine(defaultIfEmptyRes);
                //Min
                Console.WriteLine("\nLinq To objects: Min");
                var minRes = ss[0].Min(h => h.Weight);
                Console.WriteLine(minRes);
                //Max
                Console.WriteLine("\nLinq To objects: Max");
                var maxRes = ss[0].Max(h => h.Height);
                Console.WriteLine(maxRes);
                //Join
                Console.WriteLine("\nLinq To objects: Join");
                var joinRes = ss[0].Join(ss[1], o => o.Height, i => i.Height,
               (o, i) => new Human
               {
                   FirstName = o.FirstName + " " + i.FirstName,
                   LastName = o.LastName + " " + i.LastName,
                   Height = o.Height,
                   Weight = (o.Weight + i.Weight) / 2
               });
                foreach (var human in joinRes)
                    Console.WriteLine(human);
                //GroupJoin
                Console.WriteLine("\nLinq To objects: GroupJoin");
                var groupJoinRes = ss[1].GroupJoin(ss[1], o => o.Height, i =>
               i.Height, (o, i) => new
               {
                   FullName = $"{o.FirstName} {o.LastName}",
                   Count = i.Count(),
                   TotalWeight = i.Sum(s => s.Weight)
               });
                foreach (var human in groupJoinRes)
                {
                    Console.WriteLine($"{human.FullName}: Count = {human.Count}, TotalWeight: { human.TotalWeight}");
                }
                //All and Any
                Console.WriteLine("\nLinq To objects: All/Any");
                var allAnyRes = list.First(c => c.All(h => h.Height > 160) && c.Any(h => h is Worker)).Select(h => h.FirstName).OrderByDescending(s => s);
                foreach (var name in allAnyRes)
                {
                    Console.WriteLine(name);
                }

                    
                //Contains
                Console.WriteLine("\nLinq To objects: Contains");
                var containsRes = list.Where(c => c.Contains(wr3)).SelectMany(c => c.SelectMany(h => h.FullName.Split(' '))).Distinct().OrderBy(s => s).ToList();
                foreach (var name in containsRes) 
                {
                    Console.WriteLine(name);
                }

               


                using (StreamWriter SW = new StreamWriter(new FileStream("ttt.txt", FileMode.OpenOrCreate)))
                {
                    foreach (var item in ss)
                    {
                       foreach( var e in item)
                        {
                            SW.WriteLine($"[{e.FirstName}{e.FullName}{e.LastName}{e.Height}\t{e.Weight}]\n");
                            SW.WriteLine("\n");
                        }
                    }
            }



                if(ss[0].Count > ss[1].Count)
                {
                    Console.WriteLine($"[1 коллекция больше второй{ss[0].Count}>{ss[1].Count}]");
                    Console.WriteLine($"Минимальная коллекция:2");
                    Console.WriteLine($"Максимальная коллекция:1");
                }
                else if(ss[1].Count > ss[0].Count)
                {
                    Console.WriteLine($"[2 коллекция больше первой{ss[1].Count}>{ss[0].Count}]");
                    Console.WriteLine($"Минимальная коллекция:1");
                    Console.WriteLine($"Максимальная коллекция:2");
                }
                else
                {
                    Console.WriteLine("Коллекции равны");
                }



                int num = 2;
                int cc = 0;



                if (ss[0].Count == num)
                {
                    cc++;
                    Console.WriteLine($"{ss[0]},{cc}");
              
                }
                else if(ss[1].Count == num)
                {
                    Console.WriteLine(ss[1]);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }

   
    
    
   
}
