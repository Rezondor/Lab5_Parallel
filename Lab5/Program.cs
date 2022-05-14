﻿using Lab5.Models;
using Lab5.Helperes;
using System.Linq;

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

//var selectedWorkers = a.Where(x => x.LastName.ToLower().StartsWith("t")&& x.FirastName.ToLower().Contains('a'));
/*var selectedWorkers = a.SelectMany(u => u.Orders,
                            (u, l) => new {Worker = u, Orders = l })
                          .Where(u => u.Orders.DateTime >new DateTime(2015,10,1))
                          .Select(u => u.Orders).OrderBy(u => u.DateTime);*/
/*var selectedWorkers = a.Select(u => new { Worker = u, AVG = u.Orders.Average(p => p.Price) }).OrderByDescending(u=>u.AVG);*/
var selectedWorkers = RequestHelper.GetOrdersWhereFullNameStartsWith(a,'a');
Console.WriteLine();
foreach (var item in selectedWorkers)
{
    Console.WriteLine(item);
}
/*foreach (var item in selectedWorkers)
{
    Console.WriteLine($"{item.Worker} | {item.AVG:f3}");
}*/
