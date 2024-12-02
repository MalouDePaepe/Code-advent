
using System.Runtime.InteropServices;

using System.Collections.Generic;

using System.IO;



List<day_runner> runners = new List<day_runner>();
runners.Add(new day1());
runners.Add(new day2());

for(int i = 0; i < (runners.Count-1); i++)
{
    runners[i].parse();
    runners[i].part1();
    runners[i].part2();

}
abstract class day_runner
{
    public abstract void parse();
    
    public abstract void part1();
    public virtual void part2()
    {

    }
    
}



class day2 : day_runner
{
    public override void parse()
    {

    }

    public override void part1()
    {


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

    public override void part1()
    {
        m_firstColumn.Sort();
        m_secondColumn.Sort();
        int som = 0;

        for (int i = 0; i < (m_firstColumn.Count); i++)
        {
            //distance
            som += Math.Abs(m_firstColumn[i] - m_secondColumn[i]);
            
        }


        //print(som.ToString());

    }
    public override void part2()
    {
        int result = 0;
        foreach(int nr in m_firstColumn)
        {
            //first col nr          secondColumn.find count
            // first col nr * found count
            // result += int

            List<int> list = m_secondColumn.FindAll(x => x == nr);
            result += (nr*list.Count);
            

        }

        Console.WriteLine(result);

    }

}

