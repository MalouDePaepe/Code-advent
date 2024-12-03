
using System.Runtime.InteropServices;

using System.Collections.Generic;

using System.IO;



List<day_runner> runners = new List<day_runner>();
runners.Add(new day1());
runners.Add(new day2());

for(int i = 0; i < (runners.Count); i++)
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
    List<List<int>> reports = new List<List<int>>();
    public override void parse()
    {
        

        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay2.txt";
        

        foreach (string line in File.ReadLines(filePath))
        {
            //make report for the line and add it to the reports list
            List<int> m_report = new List<int>();
            reports.Add(m_report);

            //Fill m_report

            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string part in parts)
            {

                m_report.Add(int.Parse(part));
            }


        }
        
    }

    public override void part1()
    {

        //Check if safe
        // 1: atleast one or at most three
        // ex. 1st = 1 and report is 5 long
        //     last has to be 1 + count-1 
        //      at most 1 4 7 10 13 count-1*3 
        foreach(List<int> report in reports)
        {
            if (report[report.Count - 1] > Math.Abs((report[0] + report.Count - 1)) && report[report.Count - 1]  < Math.Abs((report[0] + (report.Count-1)*3))) ;
            report.Clear();
        }

        // 2: all increasing or all decreasing
        foreach (List<int> report in reports)
        {
            bool valid = true;

            for (int i = 0; i < report.Count - 1; i++)
            {
                if (i + 1 >= report.Count) continue;
                int current = report[i];
                int next = report[i + 1];

                // 2 - 1 > 0 -> ascending
                bool isAscending = next - current > 0;
            }
        }
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
        Console.WriteLine("Day 1 Part 1 = "+som);


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

        Console.WriteLine("Day 1 Part 2 "+result);

    }

}

