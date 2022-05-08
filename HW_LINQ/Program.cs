
using HW_LINQ;

#region Method Syntax

Console.WriteLine("=================Method Syntax=================");

List<int> numbers = new List<int>() { 4, 85, 32, 11, 9 };
var nums = numbers.Select(num => num);
Console.WriteLine(string.Join(",", nums));
Console.WriteLine();

List<string> names = new List<string>() { "shiran", "nir", "tikva", "noa", "rona" };
List<string> fourLetters = names.Where(name => name.Length > 4).ToList();
fourLetters.ForEach(name => Console.WriteLine(name));
Console.WriteLine();

List<int> nums2 = numbers.OrderBy(num => num).ToList();
Console.WriteLine(string.Join(",", nums2));
Console.WriteLine();
List<int> nums3 = numbers.OrderByDescending(num => num).ToList();
Console.WriteLine(string.Join(",", nums3));
Console.WriteLine();
List<string> names2 = names.OrderBy(name => name).ToList();
names2.ForEach(name => Console.WriteLine(name));
Console.WriteLine();
List<string> names3 = names.OrderByDescending(name => name).ToList();
names3.ForEach(name => Console.WriteLine(name));
Console.WriteLine();

List<int> numbers2 = new List<int> { 11, 22, 3, 4, 53 };
List<int> numbers3 = new List<int> { 8, 53, 33, 11, 22 };
List<int> joinNum = numbers2.Join(numbers3,
    num1 => num1,
    num2 => num2,
    (num1, num2) => num1).ToList();
joinNum.ForEach(num => Console.WriteLine(num));
Console.WriteLine();

List<int> exceptNum = numbers2.Except(numbers3).ToList();
exceptNum.ForEach(num => Console.WriteLine(num));
Console.WriteLine();

List<int> unionNum = numbers2.Union(numbers3).ToList();
unionNum.ForEach(num => Console.WriteLine(num));
Console.WriteLine();

var firstNum = numbers2.FirstOrDefault(num => num > 12);
Console.WriteLine(firstNum);
Console.WriteLine();
var firstNum2 = numbers3.FirstOrDefault(num => num > 12);
Console.WriteLine(firstNum2);
Console.WriteLine();

List<Client> clients = new List<Client>()
{
    new Client("yossi", "Agent1"),
    new Client("dana", "Agent2"),
    new Client("maor", "Agent1"),
    new Client("moshe", "Agent3"),
    new Client("niza", "Agent4")
};

List<Agent> agents = new List<Agent>()
{
    new Agent("Agent1"),
    new Agent("Agent2"),
    new Agent("Agent3"),
    new Agent("Agent4"),
    new Agent("Agent5")

};



var clientByAgent = clients.Join(agents,
 client => client.HandleAgent,
 agent => agent.Name,
 (client, agent) => new
 {
     Client = client.Name,
     Agent = agent.Name
 }).ToList();
foreach (var cba in clientByAgent)
{
    Console.WriteLine($"Client: {cba.Client}, Agnet: {cba.Agent}");
}
#endregion

Console.WriteLine();

#region Query Syntax

Console.WriteLine("=================Query Syntax=================");

var numsQuery = from num in numbers
                select num;
Console.WriteLine(string.Join(",", numsQuery));
Console.WriteLine();

var fourLettersQuery = from name in names
                       where name.Length > 4
                       select name;
fourLettersQuery.ToList().ForEach(name => Console.WriteLine(name));
Console.WriteLine();

var orderedNums2 = from num in numbers
                   orderby num
                   select num;
Console.WriteLine(string.Join(",", orderedNums2));
Console.WriteLine();
var orderedNums3 = from num in numbers
                   orderby num descending
                   select num;
Console.WriteLine(string.Join(",", orderedNums3));
Console.WriteLine();
var orderedNames2 = from name in names
                    orderby name
                    select name;
orderedNames2.ToList().ForEach(name => Console.WriteLine(name));
Console.WriteLine();
var orderedNames3 = from name in names
                    orderby name descending
                    select name;
orderedNames3.ToList().ForEach(name => Console.WriteLine(name));
Console.WriteLine();

var joinNumQuery = from num1 in numbers2
                   join num2 in numbers3
                   on num1 equals num2
                   where num1 == num2
                   select num1;
joinNumQuery.ToList().ForEach(joinNumQuery => Console.WriteLine(joinNumQuery));
Console.WriteLine();

var clientByAgentQuery = (from client in clients
                          join agent in agents
                          on client.HandleAgent equals agent.Name
                          select new
                          {
                              Client = client.Name,
                              Agent = agent.Name
                          }).ToList();
clientByAgentQuery.ForEach(clientByAgentQuery => Console.WriteLine($"Client: {clientByAgentQuery.Client}, Agnet: {clientByAgentQuery.Agent}"));


#endregion










