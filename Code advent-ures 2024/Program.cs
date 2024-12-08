
using System.Runtime.InteropServices;

using System.Collections.Generic;

using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Numerics;
using System.Net.NetworkInformation;

List<day_runner> runners = new List<day_runner>();
runners.Add(new day1());
runners.Add(new day2());
runners.Add(new day3());
runners.Add(new day4());

for (int i = 0; i < (runners.Count); i++)
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

class day4 : day_runner
{
    List<List<char>> m_matrix = new List<List<char>>();

    int get_num_rows()
    {
        return m_matrix.Count;
    }

    int get_num_cols()
    {
        return m_matrix[0].Count;
    }
    
    char get_char(int row, int col)
    {
        return m_matrix[row][col];
    }
    // if x, check surrounding (should be a function)
    // ex. x =  [5.5], check [5,4] [5,6] 
    //[4,4][4,5][4,6]
    //[5,4][5,5][5,6]
    //[6,4][6,5][6,6]

    bool isXMAS (int direction, int row, int col)
    {



    }

    string get_row(int index)
    {         
        string row = "";
        for (int col = 0; col < get_num_cols(); col++)
        {
            char character = get_char(index, col);
            row += character;
        }
        return row;
    }

    string get_col(int index)
    {
        string col = "";
        for(int r = 0; r < get_num_rows(); r++)
        {
            char character = get_char(r, index);
            col += character;

        }

        return col;


    }

    
   

    int checkRow (string pattern, int r)
    {
        string row = get_row(r);
        Regex rgx = new Regex(pattern);
        MatchCollection correct = rgx.Matches(row);
        return  correct.Count;

    }

    int checkCol(string pattern, int c)
    {
        string col = get_col(c);
        Regex rgx = new Regex(pattern);
        MatchCollection correct = rgx.Matches(col);
        return correct.Count;

    }

    int checkDiagonalFirstRow(string pattern, bool forward)
    {
        int sum = 0;
        //for each column of the first row
        for(int i = 0; i  < get_num_cols(); i++) {
            string diag = getDiagonalFirstRow(i, forward);
            Regex rgx = new Regex(pattern);
            MatchCollection correct = rgx.Matches(diag);
            sum+= correct.Count;

        }
        return sum;
    }


    string getDiagonalFirstRow(int index, bool forward)
    {

        
        string diagonal = "";
        int diagonalLength = index + 1;

        // backwards
        if (forward)
        {
            for (int i = 0; i < diagonalLength; i++)
            {

                char character = get_char(0 + i, index - i);
                diagonal += character;


            }
        }
        else
        {
            //forward
            for (int i = 0; i < diagonalLength; i++)
            {

                char character = get_char(index - i, 0 + i);
                diagonal += character;

            }
        }
        return diagonal;

    }

    //needs row nr 
    string getDiagonalLastColumn(int index, bool forward)
    {
        int diagonalLength = get_num_rows() - index;
        string diagonal = "";
        if (forward)
        {
            for (int i = 0; i < diagonalLength; i++)
            {
                char character = get_char(index + i, diagonalLength - i);
                diagonal += character;

            }
        }
        else
        {
            for (int i = 0; i < diagonalLength; i++)
            {
                char character = get_char(diagonalLength - i, index + i);
                diagonal += character;

            }

        }
        return diagonal;
    }

    
    int checkDiagonalLastColumn(string pattern, bool forward)
    {
        int sum = 0;
        //for each row of the last column

        for (int i = 1; i < get_num_rows()-1; i++)
        {
            string diag = getDiagonalLastColumn(i, forward);
            Regex rgx = new Regex(pattern);
            MatchCollection correct = rgx.Matches(diag);
            sum += correct.Count;

        }
        return sum;

    }



    public override void parse()
    {
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay4Test.txt";

        // for each line in your file
        // make a new list of characters
        // add the new list to your list of lists
        foreach (string line in File.ReadLines(filePath))
        {
            List<char> new_list = new List<char>();
            for (int i = 0; i < line.Length; i++)
            {
                new_list.Add(line[i]);
            }
            m_matrix.Add(new_list);
        }
    }

    public override void part1()
    {
        int sum = 0;
        int sum2 = 0;
        string patternForward = @"(XMAS)";
        string patternBackwards = @"(SAMX)";

        // for each row
        for (int r = 0; r < get_num_rows(); r++)
        {
           //sum += checkRow(patternForward, r);
           //sum += checkRow(patternBackwards, r);
            //Console.WriteLine(sum);
        }

        // regex on the row
        // if its found, add it to the sum

        //for each column
        for (int c = 0; c < get_num_cols(); c++)
        {
            //sum += checkCol(patternForward, c);
            //sum += checkCol(patternBackwards, c);
            //Console.WriteLine(sum);
        }
        /////////////////

        // diagonals
       
        // backward
        
        //sum += checkDiagonalFirstRow(patternForward, true);
        //sum += checkDiagonalFirstRow(patternForward, false);
        // = 1
        //Console.WriteLine(sum);
        //sum += checkDiagonalFirstRow(patternBackwards,true);
        //sum += checkDiagonalFirstRow(patternBackwards,false);
        // = +1
        //Console.WriteLine(sum);
        //sum += checkDiagonalLastColumn(patternForward, true);
        //sum += checkDiagonalLastColumn(patternForward, false);
        // = +1
        //Console.WriteLine(sum);
        //sum += checkDiagonalLastColumn(patternBackwards, true);
        // sum += checkDiagonalLastColumn(patternBackwards, false);
        // = +6
        //Console.WriteLine(sum);

        //forward

    }

    public override void part2()
    {
        //for each index in the matric
        for(int r =0;  r < get_num_rows(); r++)
        {
            for(int c = 0; c < get_num_cols(); c++)
            {
                char letter = get_char(r, c);
                if (letter == 'X')
                {


                }

            }

        }
    }




}
class day3 : day_runner
{
    string input ="";
    public override void parse()
    {
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay3.txt";
        input = File.ReadAllText(filePath);


    }

    public override void part1()
    {
        int sum = 0;
        string pattern = @"mul\((-?\d+),(-?\d+)\)";
        List<string> matches = new List<string>();
        
        Regex regex = new Regex(pattern);
        
        MatchCollection correct = regex.Matches(input);

        // for each Match called 'match' in the Match Collection 'correct'
        foreach (Match match in correct)
        {
            //add it to the list of Strings called 'matches'
            matches.Add(match.Value);
        }
        //for every index in matches (string list)
        for(int i = 0; i < matches.Count; i++)
        {
            //pattern 
            string patternIntegers = @"\d+";

            Regex numbers = new Regex(patternIntegers);

            MatchCollection pairs = numbers.Matches(matches[i].ToString());

            List<string> pairsStrings = new List<string>();

            pairsStrings.Add(pairs[0].Value);
            pairsStrings.Add(pairs[1].Value);
            
            int multiplication = int.Parse(pairsStrings[0]) * int.Parse(pairsStrings[1]);
            sum += multiplication;
            

        }
        Console.WriteLine("Day 3 Part 1 =" + sum);
    }

    public override void part2()
    {
        bool noDont = true;

        int sum = 0;
        string pattern = @"mul\((-?\d+),(-?\d+)\)|do\(\)|don't\(\)";
        List<string> matches = new List<string>();

        Regex regex = new Regex(pattern);

        MatchCollection precheck = regex.Matches(input);

        // for each Match called 'match' in the Match Collection 'precheck'
        foreach (Match match in precheck)
        {
            //add it to the list of Strings called 'matches'
            matches.Add(match.Value);
            
        }

        //for every index in matches (string list)
        for (int i = 0; i < matches.Count; i++) { 
            
           
          
            if (matches[i] == "don't()")
            {
                noDont = false;
                

            }


            if (matches[i] == "do()")
            {

                noDont = true;
                
            }

            if(matches[i] != "don't()" && matches[i] != "do()" && noDont == true)
            {
                //pattern 
                string patternIntegers = @"\d+";

                Regex numbers = new Regex(patternIntegers);

                MatchCollection pairs = numbers.Matches(matches[i].ToString());

                List<string> pairsStrings = new List<string>();

                pairsStrings.Add(pairs[0].Value);
                pairsStrings.Add(pairs[1].Value);

                int multiplication = int.Parse(pairsStrings[0]) * int.Parse(pairsStrings[1]);
                sum += multiplication;
                

            }


        }
        Console.WriteLine("Day 3 Part 1 =" + sum);
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

        //Check if safe (precheck)
        // 1: atleast one or at most three
        // ex. 1st = 1 and report is 5 long
        //      1 2 3 4 5           1 + 4
        //     last has to be 1 + count-1 
        //      at most 1 4 7 10 13 count-1*3 
        int numRemoved = 0;
        foreach(List<int> report in reports)
        {
            int first = report[0];
            int last = report[report.Count - 1];
            int listSize = report.Count();
            // if distance is smaller than size-1 ===> clear
            if (Math.Abs(last - first) < listSize - 1)
            {
                report.Clear();
                numRemoved++;
            }
            // if distance is bigger than size-1 * 3 ===> clear
            if (Math.Abs(last - first) > (listSize - 1) * 3)
            {
                report.Clear();
                numRemoved++;
            }
            // if (report[report.Count - 1] > Math.Abs((report[0] + report.Count - 1)) && report[report.Count - 1]  < Math.Abs((report[0] + (report.Count-1)*3))) ;
            // report.Clear();
        }



        // 2: all increasing or all decreasing
        foreach (List<int> report in reports)
        {
            if (report.Count == 0) continue;
            bool ascendCheck = true;

            //sets the first one, not taking into account when theyre the same
            if (report[0] >= report[1])
            {
                ascendCheck = false;
            }
            else
            {
                ascendCheck = true;
            }

            for (int i = 0; i < report.Count - 1; i++)
            {
                //if the next one is not null
                if (i + 1 >= report.Count) continue;
                //make current and next
                int current = report[i];
                int next = report[i + 1];

                //check them
                if (next > current)
                {
                    if (ascendCheck != true)
                    {
                        report.Clear();
                        numRemoved++;

                    }
                }
                else
                {
                    if (ascendCheck != false)
                    {
                        numRemoved++;
                        report.Clear();
                    }

                }

                

            }
            //3: also check the distance between the values
            for (int i = 0; i < report.Count - 1; i++)
            {
                //if the next one is not null
                if (i + 1 >= report.Count) continue;
                //make current and next
                int current = report[i];
                int next = report[i + 1];
                if (Math.Abs(current - next) > 3 || Math.Abs(current - next) < 1)
                {
                    report.Clear();
                    numRemoved++;
                }
                //if (report.Count == 0) continue;
                //Console.WriteLine(report[i] + "     " + numRemoved);
            }

            
        }
        Console.WriteLine("Day 2 Part 1 ="+ (1000-numRemoved));
    }

    public override void part2()
    {
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay2.txt";


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

        Console.WriteLine("Day 1 Part 2 ="+result);

    }

}

