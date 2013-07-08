using System;
using System.Collections;
using System.Collections.Generic;

//BG Codder: 100/100

class Application
{
    static void Main(string[] args)
    {
        List<int> hospitals = new List<int>();
        Dictionary<Node, List<Edge>> graph = new Dictionary<Node, List<Edge>>();
        Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var nodesCount = int.Parse(input[0]);
        var edgesCount = int.Parse(input[1]);
        var hospitalCount = int.Parse(input[2]);

        input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < hospitalCount; i++)
        {
            hospitals.Add(int.Parse(input[i]));
        }

        for (int i = 0; i < edgesCount; i++)
        {
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstNodeName = int.Parse(input[0]);
            var secondNodeName = int.Parse(input[1]);
            var nodeWeight = int.Parse(input[2]);

            if (!nodes.ContainsKey(firstNodeName))
            {
                nodes.Add(firstNodeName, new Node(firstNodeName));
            }

            if (!nodes.ContainsKey(secondNodeName))
            {
                nodes.Add(secondNodeName, new Node(secondNodeName));
            }

            var firstNode = nodes[firstNodeName];
            var secondNode = nodes[secondNodeName];

            if (!graph.ContainsKey(firstNode))
            {
                graph.Add(firstNode, new List<Edge>());
            }

            if (!graph.ContainsKey(secondNode))
            {
                graph.Add(secondNode, new List<Edge>());
            }

            graph[firstNode].Add(new Edge(secondNode, nodeWeight));
            graph[secondNode].Add(new Edge(firstNode, nodeWeight));
        }

        for (int i = 0; i < hospitals.Count; i++)
        {
            nodes[hospitals[i]].IsHospital = true;
        }

        long result = long.MaxValue;

        for (int i = 0; i < hospitals.Count; i++)
        {
            var currentHospital = nodes[hospitals[i]];

            DijkstraAlgo(graph, currentHospital);

            long tempSum = 0;

            foreach (var node in nodes)
            {
                if (node.Value.IsHospital == false)
                {
                    tempSum += node.Value.MinDistance;
                }
            }

            if (result > tempSum)
            {
                result = tempSum;
            }
        }

        Console.WriteLine(result);
    }

    static void DijkstraAlgo(Dictionary<Node, List<Edge>> graph, Node source)
    {

        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.MinDistance = long.MaxValue;
        }

        source.MinDistance = 0;

        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            var curretNode = queue.Dequeue();

            if (curretNode.MinDistance == long.MaxValue)
            {
                break;
            }

            foreach (var connection in graph[curretNode])
            {
                var possibleDistance = curretNode.MinDistance + connection.Weight;

                if (possibleDistance < connection.End.MinDistance)
                {
                    connection.End.MinDistance = possibleDistance;
                    queue.Enqueue(connection.End);
                }
            }
        }
    }
}

class Node : IComparable
{
    public int Name { get; set; }
    public long MinDistance { get; set; }
    public bool IsHospital { get; set; }

    public Node(int name)
    {
        this.Name = name;
        this.MinDistance = long.MaxValue;
        this.IsHospital = false;
    }

    public int CompareTo(object obj)
    {
        var result = this.MinDistance.CompareTo((obj as Node).MinDistance);
        return result;
    }
}

class Edge
{
    public Node End { get; set; }
    public long Weight { get; set; }

    public Edge(Node end, long weight)
    {
        this.End = end;
        this.Weight = weight;
    }
}

//public class PriorityQueue<T> where T : IComparable
//{
//    private T[] heap;
//    private int index;

//    public int Count
//    {
//        get
//        {
//            return this.index - 1;
//        }
//    }

//    public PriorityQueue()
//    {
//        this.heap = new T[16];
//        this.index = 1;
//    }

//    public void Enqueue(T element)
//    {
//        if (this.index >= this.heap.Length)
//        {
//            IncreaseArray();
//        }

//        this.heap[this.index] = element;

//        int childIndex = this.index;
//        int parentIndex = childIndex / 2;
//        this.index++;

//        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
//        {
//            T swapValue = this.heap[parentIndex];
//            this.heap[parentIndex] = this.heap[childIndex];
//            this.heap[childIndex] = swapValue;

//            childIndex = parentIndex;
//            parentIndex = childIndex / 2;
//        }
//    }

//    public T Dequeue()
//    {
//        T result = this.heap[1];

//        this.heap[1] = this.heap[this.Count];
//        this.index--;

//        int rootIndex = 1;

//        int minChild;

//        while (true)
//        {
//            int leftChildIndex = rootIndex * 2;
//            int rightChildIndex = rootIndex * 2 + 1;

//            if (leftChildIndex > this.index)
//            {
//                break;
//            }
//            else if (rightChildIndex > this.index)
//            {
//                minChild = leftChildIndex;
//            }
//            else
//            {
//                if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
//                {
//                    minChild = leftChildIndex;
//                }
//                else
//                {
//                    minChild = rightChildIndex;
//                }
//            }

//            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
//            {
//                T swapValue = this.heap[rootIndex];
//                this.heap[rootIndex] = this.heap[minChild];
//                this.heap[minChild] = swapValue;

//                rootIndex = minChild;
//            }
//            else
//            {
//                break;
//            }
//        }

//        return result;
//    }

//    public T Peek()
//    {
//        return this.heap[1];
//    }

//    private void IncreaseArray()
//    {
//        T[] copiedHeap = new T[this.heap.Length * 2];

//        for (int i = 0; i < this.heap.Length; i++)
//        {
//            copiedHeap[i] = this.heap[i];
//        }

//        this.heap = copiedHeap;
//    }
//}


//Second version of the PrioQueue just in case
public class PriorityQueue<T> : IEnumerable
   where T : IComparable
{
    private List<T> heap;

    public PriorityQueue()
    {
        heap = new List<T>();
    }

    public PriorityQueue(int size)
    {
        heap = new List<T>(size);
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return this.heap.Count == 0;
        }
    }

    public void Enqueue(T item)
    {
        this.heap.Add(item);

        int childIndex = this.heap.Count - 1;
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (this.heap[parentIndex].CompareTo(this.heap[childIndex]) <= 0)
            {
                break;
            }

            T swap = this.heap[childIndex];
            this.heap[childIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = swap;

            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        int lastIndex = this.heap.Count - 1;

        T topItem = this.heap[0];
        this.heap[0] = this.heap[lastIndex];
        this.heap.RemoveAt(lastIndex);
        lastIndex--;

        int parentIndex = 0;
        while (true)
        {
            int leftIndex = 2 * parentIndex + 1;
            if (leftIndex > lastIndex)
            {
                break;
            }

            int swapIndex = leftIndex;
            int rightIndex = leftIndex + 1;
            if (rightIndex <= lastIndex && this.heap[rightIndex].CompareTo(this.heap[leftIndex]) < 0)
            {
                swapIndex = rightIndex;
            }

            if (this.heap[parentIndex].CompareTo(this.heap[swapIndex]) <= 0)
            {
                // the parent and the child are in order
                break;
            }

            T swap = this.heap[swapIndex];
            this.heap[swapIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = swap;

            parentIndex = swapIndex;
        }

        return topItem;
    }

    public T Peek()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException("Queue empty.");
        }

        T topItem = this.heap[0];
        return topItem;
    }

    public void Clear()
    {
        this.heap.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.heap.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        return this.heap.ToArray();
    }

    public override string ToString()
    {
        return string.Join(", ", this.heap);
    }
}
