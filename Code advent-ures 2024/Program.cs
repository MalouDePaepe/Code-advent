
using System.Runtime.InteropServices;

using System.Collections.Generic;

using System.IO;



List<day_runner> runners = new List<day_runner>();
runners.Add(new day1());
runners.Add(new day2());

for(int i = 0; i < (runners.Count-1); i++)
{
    runners[i].parse();
    runners[i].run();

}
abstract class day_runner
{
    public abstract void parse();
    
    public abstract void run();

    public void print(string output)
    {
        Console.WriteLine(output);
    }
}

class day1 : day_runner{

    List<int> m_firstColumn = new List<int>();
    List<int> m_secondColumn = new List<int>();
    public override void parse()
    {
        Console.WriteLine("Love u");
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay1.txt";
        

        foreach (string line in File.ReadLines(filePath))
        {
            
            string[] parts = line.Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            m_firstColumn.Add(int.Parse(parts[0]));
            m_secondColumn.Add(int.Parse(parts[1]));

        }

    }

    public override void run()
    {
        m_firstColumn.Sort();
        m_secondColumn.Sort();
        int eene = m_firstColumn[0];
        int andere = m_firstColumn[0];
        int som = 0;

        for (int i = 0; i < (m_firstColumn.Count); i++)
        {
            //distance
            som += Math.Abs(m_firstColumn[i] - m_secondColumn[i]);
            
        }
        print(som.ToString());
    }
}

class day2 : day_runner
{
    public override void parse()
    {
    
    }

    public override void run()
    {


    }

}