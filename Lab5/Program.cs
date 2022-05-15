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
List<int> CountThreads = new List<int>() {1,2,4,8,16};
Console.WriteLine(0);
List<List<Worker>> WorkersList = new List<List<Worker>>();
List<List<double>> time = new List<List<double>>();

var reqHelper = new RequestHelper();
var ParallelReqHelepr = new ParallelRequestHelper(1);

Parallel.For(0, CountWorkers.Count, i =>
{
    WorkersList.Add(WorkerHelper.GenerateWorkersList(CountWorkers[i]));
    Console.WriteLine(1 + i);
});
Console.WriteLine(5);
Stopwatch sch = new Stopwatch();
IRequests req;
for (int i = 0; i < CountThreads.Count; i++)
{
    int countThread = CountThreads[i];
    req = reqHelper;
    if (countThread != 1)
    {
        ParallelReqHelepr.NumberThreads = countThread;
        req = ParallelReqHelepr;
    }
    
    List<double> localTime = new();
    for (int j = 0; j < WorkersList.Count; i++)
    {

        double lt = 0.0;
        for(int k = 0; k < 5; k++)
        {
            sch.Start();
            var a = req.GetOrdersWhereFullNameStartsWith(WorkersList[i], 'a');
            sch.Stop();
            lt += sch.ElapsedMilliseconds / 1000.0;
            //tm.Add(sch.ElapsedMilliseconds / 1000.0);
        }
        lt /= 5.0;
        localTime.Add(lt);
       
    }
    time.Add(localTime);
    

}

//var selectedWorkers = RequestHelper.GetWorkersSortedByAVGOrderPrice();
//var selectedWorkers = RequestHelper.GetOrdersWhereFullNameStartsWith(a,'a');
//var selectedWorkers= RequestHelper.GetOrdersBeforeOrAfterDate(a,RequestHelper.BeforeOrAfter.After,new DateTime(2001,01,15));
