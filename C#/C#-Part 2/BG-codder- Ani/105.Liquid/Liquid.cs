using System;

//70/100, but it is important to note I came up with it before looking at the solution.
//I am a bit proud of it actually, even though it is very messy! :)
class Liquid
{
    static Cube[, ,] cuboid;
    static byte width;
    static byte height;
    static byte depth;

    static void Main(string[] args)
    {
        ReadData();

        //the upper part is all filled with water as much as their capacity is;
        int d = 0;
        for (int u = 0; u < width; u++)
        {
            for (int y = 0; y < height; y++)
            {
                PassWater(u, y, d, cuboid[u, y, d].Capacity);
            }
        }

        //in the end we sum how many units the bottom layer has

        int result = 0;
        d = depth - 1;
        for (int u = 0; u < width; u++)
        {
            for (int y = 0; y < height; y++)
            {
                result += cuboid[u, y, d].UnitsHeld;
            }
        }
        Console.WriteLine(result);
    }

    static byte PassWater(int w, int h, int d, byte amount) //returns how much water *couldn't* pass through the cube
    {
        Cube[, ,] toView = cuboid;

        byte waterThatEnters;
        byte waterThatDidntEnter;
        if (cuboid[w, h, d].UnitsAvailable >= amount)
        {
            waterThatEnters = amount;
            waterThatDidntEnter = 0;
        }
        else
        {
            waterThatEnters = (byte)(cuboid[w, h, d].UnitsAvailable);
            waterThatDidntEnter = (byte)(amount - cuboid[w, h, d].UnitsAvailable);
        }

        cuboid[w, h, d].Fill(waterThatEnters);

        if (d == depth - 1)
        {
            return waterThatDidntEnter; //we've reached the end;
        }

        byte currentWaterRemaining = waterThatEnters; // should this be the water that enters?
        //try to passthe water down
        currentWaterRemaining = PassWater(w, h, d + 1, currentWaterRemaining);
        //try to pass any remains to the sides
        if (currentWaterRemaining != 0 && w < width - 1)
        {
            currentWaterRemaining = PassWater(w + 1, h, d, currentWaterRemaining);
        }
        if (currentWaterRemaining != 0 && w > 0)
        {
            currentWaterRemaining = PassWater(w - 1, h, d, currentWaterRemaining);
        }
        if (currentWaterRemaining != 0 && h > 0)
        {
            currentWaterRemaining = PassWater(w, h - 1, d, currentWaterRemaining);
        }
        if (currentWaterRemaining != 0 && h < height - 1)
        {
            currentWaterRemaining = PassWater(w, h + 1, d, currentWaterRemaining);
        }

        return (byte)(currentWaterRemaining + waterThatDidntEnter);
    }

    static void ReadData()
    {

        string whd = Console.ReadLine();
        string[] whdSplit = whd.Split();
        width = byte.Parse(whdSplit[0]);
        height = byte.Parse(whdSplit[1]);
        depth = byte.Parse(whdSplit[2]);

        cuboid = new Cube[width, height, depth];

        char[] splitHelp = { '|' };
        char[] splitHelp2 = { ' ' };

        for (int y = 0; y < height; y++)
        {
            string helpRead = Console.ReadLine();
            string[] helpRead2 = helpRead.Split(splitHelp, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < depth; i++)
            {
                string[] helpRead3 = helpRead2[i].Split(splitHelp2, StringSplitOptions.RemoveEmptyEntries);
                for (int u = 0; u < width; u++)
                {
                    cuboid[u, y, i] = new Cube(Byte.Parse(helpRead3[u]));
                }

            }
        }


    }

}

class Cube
{
    //fields
    private byte capacity = 0;
    private byte unitsHeld = 0;


    //constructor
    public Cube(byte capacity)
    {
        this.capacity = capacity;
    }

    //properties
    public byte Capacity
    {
        get { return this.capacity; }
        set { this.capacity = value; }
    }
    public byte UnitsHeld
    {
        get { return this.unitsHeld; }
        set { this.unitsHeld = value; }
    }
    public byte UnitsAvailable
    {
        get { return (byte)(this.capacity - this.unitsHeld); }
    }
    public bool Filled
    {
        get
        {
            if (this.unitsHeld == this.capacity)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    //methods
    public void Fill(byte amountOfLiquid)
    {
        this.unitsHeld += amountOfLiquid;
    }
}
