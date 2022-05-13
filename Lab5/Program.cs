using Lab5.Models;
using Lab5.Helperes;

List<int> countWorkers = new List<int>() 
{
    100,
    1000,
    10000,
    100000,
    1000000
};

var a = WorkerHelper.GenerateWorkersList(10);
foreach (var item in a)
{
    Console.WriteLine(item);
}

