using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var queue = new SuperMarketQueue();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "Append")
            {
                queue.Append(input[1]);
            }
            else if (input[0] == "Insert")
            {
                queue.Insert(int.Parse(input[1]), input[2]);
            }
            else if (input[0] == "Find")
            {
                queue.Find(input[1]);
            }
            else if (input[0] == "Serve")
            {
                queue.Serve(int.Parse(input[1]));
            }
            else if (input[0] == "End")
            {
                queue.End();
                break;
            }
        }
    }
}

class SuperMarketQueue
{
    public List<string> Queue { get; set; }
    private Dictionary<string, int> names = new Dictionary<string, int>();
    private StringBuilder sb = new StringBuilder();

    public SuperMarketQueue()
    {
        this.Queue = new List<string>();
    }

    public void Append(string name)
    {
        this.Queue.Add(name);
        if (names.ContainsKey(name))
        {
            names[name]++;
        }
        else
        {
            names.Add(name, 1);
        }
        sb.AppendLine("OK");
    }

    public void Insert(int possition, string name)
    {
        if (possition <= this.Queue.Count)
        {
            this.Queue.Insert(possition, name);
            if (names.ContainsKey(name))
            {
                names[name]++;
            }
            else
            {
                names.Add(name, 1);
            }
            sb.AppendLine("OK");
        }
        else
        {
            sb.AppendLine("Error");
        }
    }

    public void Find(string name)
    {
        if (names.ContainsKey(name))
        {
            sb.AppendLine(names[name].ToString());
        }
        else
        {
            sb.AppendLine(0 + " ");
        }
    }

    public void Serve(int number)
    {
        if (number <= this.Queue.Count)
        {
            var temp = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                temp.AppendFormat("{0} ", this.Queue[0]);
                names[this.Queue[0]]--;
                if (names[this.Queue[0]] == 0)
                {
                    names[this.Queue[0]] = 0;
                }
                this.Queue.RemoveAt(0);
            }

            sb.AppendLine(temp.ToString());
        }
        else
        {
            sb.AppendLine("Error");
        }
    }

    public void End()
    {
        Console.WriteLine(sb.ToString());
    }

}
