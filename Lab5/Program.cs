using Lab5.Models;
using Lab5.Helperes;
using System.Linq;
using System.Diagnostics;

List<int> CountWorkers = new List<int>() 
{
    100,
    1000,
    10000,
    100000,
};
List<int> CountThreads = new List<int>() { 2,4,8,16};
Console.WriteLine(0);
List<List<Worker>> WorkersList = new List<List<Worker>>();
for (int i = 0; i < CountWorkers.Count; i++)
{
    WorkersList.Add(WorkerHelper.GenerateWorkersList(CountWorkers[i]));
    Console.WriteLine(1+i);
}
Console.WriteLine(5);
Stopwatch sch = new Stopwatch();
for (int i = 0; i < CountThreads.Count; i++)
{
    int countThread = CountThreads[i];

   /* for (int i = 0; i < length; i++)
    {

    }*/

}

//var selectedWorkers = RequestHelper.GetWorkersSortedByAVGOrderPrice();
//var selectedWorkers = RequestHelper.GetOrdersWhereFullNameStartsWith(a,'a');
//var selectedWorkers= RequestHelper.GetOrdersBeforeOrAfterDate(a,RequestHelper.BeforeOrAfter.After,new DateTime(2001,01,15));
