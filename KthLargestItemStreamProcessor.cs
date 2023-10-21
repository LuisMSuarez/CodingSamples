/// <summary>
/// Write a stream processor which takes the input numbers one by one and print all the Kth biggest numbers starting from the Kth number.
/// 4 5 12 8 9 10 20 42 | k = 3
/// [4], [4,5], [4,5,12], [5,8,12], [8,9,12]
/// 
/// Will use a Priority Queue or "Min heap", which preserves the minimal element at the root of the queue.
/// This makes querying the minimal item as O(1), space complexity is O(k) and cost of processing a new element O(log(k))
/// In this approach, I avoid storing duplicate items, that may or may not be required, depending on the specific requirements
/// /// </summary>

using System.Linq;

var k = 3;
var numbersPriorityQueue = new PriorityQueue<int, int>(initialCapacity: k);
var endOfInput = false;
while (!endOfInput)
{
    var input = Console.ReadLine();
    if (!int.TryParse(input, out int number))
    {
        Console.WriteLine("Please enter an integer");
        continue;
    }

    if (number == 0)
    {
        endOfInput = true;
        break;
    }

    // if we have less than k items, just enqueue without having to check the root
    if (numbersPriorityQueue.Count < k)
    {
        enqueueUniqueItem(number);
    }
    else
    {
        var root = numbersPriorityQueue.Peek();
        if (number > root && !numbersPriorityQueue.UnorderedItems.Contains((number, number)))
        {
            // Pop out the root (kth largest item) and enqueue the new kth largest item
            numbersPriorityQueue.Dequeue();
            numbersPriorityQueue.Enqueue(number, number);
        }
    }

    printKLargestNumber();
}

void enqueueUniqueItem(int number)
{
    if (!numbersPriorityQueue.UnorderedItems.Contains((number, number)))
    {
        numbersPriorityQueue.Enqueue(number, number);
    }
}

void printKLargestNumber()
{
    Console.Write("[");

    // PriorityQueue uses an array as underlying storage of the heap.
    // The items will be unordered.  If the functional requirements require it to be sorted, that can easily be added
    // or consider using a sorted list as the data structure
    foreach (var n in numbersPriorityQueue.UnorderedItems)
    {
        Console.Write($"{n.Element},");
    }
    Console.WriteLine("]");
}