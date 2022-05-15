using Lab5.Models;
using Lab5.Helperes;
using System.Linq;
using System.Diagnostics;
using Lab5.Interfaces;

List<int> CountWorkers = new List<int>() 
{
    100,
    1000,
    10000,
    100000,
};
List<int> CountThreads = new List<int>() {1,2,4,8};
Console.WriteLine(0);
List<List<Worker>> WorkersList = new List<List<Worker>>();
List<List<double>> time = new List<List<double>>();

var reqHelper = new RequestHelper();
var ParallelReqHelepr = new ParallelRequestHelper(1);

for(int i = 0; i<CountWorkers.Count; i++)
{
    WorkersList.Add(WorkerHelper.GenerateWorkersList(CountWorkers[i]));
    Console.WriteLine(1 + i);
}
Console.WriteLine(5);
Stopwatch sch = new Stopwatch();
IRequests req;
for (int i = 0; i < CountThreads.Count; i++)
{
    int countThread = CountThreads[i];
    ParallelReqHelepr.NumberThreads = countThread;
    req = ParallelReqHelepr;

    List<double> localTime = new();
    for (int j = 0; j < WorkersList.Count; j++)
    {
        string nameFunc = "";
        double lt = 0.0;
        nameFunc = "SW  | ";
        for(int k = 0; k < 5; k++)
        {

            sch.Restart();
            sch.Start();
            req.GetOrdersWhereFullNameStartsWith(WorkersList[j], 'a');
            sch.Stop();
            lt += sch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"{nameFunc,6}{countThread,-2} | {WorkersList[j].Count,-7} | Итерация - {k,-2} | Время - {sch.ElapsedMilliseconds / 1000.0,-5}");

        }
        lt /= 5.0;
        localTime.Add(Math.Round(lt,3));
        //localTime.Add(nameFunc +$"{countThread,-2} | {WorkersList[j].Count,-7}",lt);

        nameFunc = "BoAD| ";
        lt = 0.0;
        for (int k = 0; k < 5; k++)
        {
            sch.Restart();
            sch.Start();
            req.GetOrdersBeforeOrAfterDate(WorkersList[j], RequestHelper.BeforeOrAfter.After, new DateTime(2001, 01, 15));
            sch.Stop();
            lt += sch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"{nameFunc,6}{countThread,-2} | {WorkersList[j].Count,-7} | Итерация - {k,-2} | Время - {sch.ElapsedMilliseconds / 1000.0,-5}");

        }
        lt /= 5.0;
        localTime.Add(Math.Round(lt, 3));
        //localTime.Add(nameFunc + $"{countThread,-2} | {WorkersList[j].Count,-7}", lt);

        nameFunc = "AVG | ";
        lt = 0.0;
        for (int k = 0; k < 5; k++)
        {
            sch.Restart();
            sch.Start();
            req.GetWorkersSortedByAVGOrderPrice(WorkersList[j]);
            sch.Stop();
            lt += sch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine($"{nameFunc,6}{countThread,-2} | {WorkersList[j].Count,-7} | Итерация - {k,-2} | Время - {sch.ElapsedMilliseconds / 1000.0,-5}");

        }
        lt /= 5.0;
        //localTime.Add(nameFunc + $"{countThread,-2} | {WorkersList[j].Count,-7}", lt);
        localTime.Add(Math.Round(lt,3));
    }
    
    time.Add(localTime);
    

}
List<string> names = new List<string>()
{
    "| SW      |",
    "| BoAD    |",
    "| AVG     |"
};
for (int i = 0; i < WorkersList.Count; i++)
{
    string st = "|"+new string(' ', 9)+"|";
    for (int j = 0; j < CountThreads.Count; j++)
    {
            st += $"{CountThreads[j],2}-{CountWorkers[i],-6}|";
    }
    Console.WriteLine(st);
    
    for (int j = 0; j < 3; j++)
    {
        string sst = names[j];
        for (int k = 0; k < CountThreads.Count; k++)
        {
            sst += $"{time[k][j+3*i].ToString(),9}|";
        }
        Console.WriteLine(sst);
    }
    Console.WriteLine();
}

