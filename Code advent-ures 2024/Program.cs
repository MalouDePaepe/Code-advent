
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
runners.Add(new day5());

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

class day5 : day_runner
{
    string input = "";
    List<string> rules = new List<string>();
    List<string> reports = new List<string>();
    
    public override void parse()
    {
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay5Test.txt";
        // split at \n
        input = File.ReadAllText(filePath);
        string[] parts = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {

            if (parts[i].Contains("|") && parts[i] != "")
            {

                rules.Add(parts[i]);

            }

            if (parts[i].Contains(",") && parts[i] != "")
            {

                reports.Add(parts[i]);

            }



        }

    }

    bool doesRuleApply(List<string> report, string rule)
    {

        //rule has 2 integers, list of strings has to contain both numbers
        // regex on rule to get the 2 ints, then check if report contains index 0 and index 1
        string pattern = @"^-?\d{2}$";
        Regex regex = new Regex(pattern);
        MatchCollection splitRules = regex.Matches(rule);
        
        return false;


    }

    List<string> splitUpReport(string report)
    {
        string pattern = @"^-?\d{2}$";
        Regex regex = new Regex(pattern);
        MatchCollection splitReport = regex.Matches(report);
        List <string> result = new List<string>();

        foreach(string index in splitReport) 
        { 
            result.Add(index);
        }
        return result;

    }
    List<string> splitRules(string rule)
    {
        string pattern = @"^-?\d{2}$";
        Regex regex = new Regex(pattern);
        MatchCollection splitReport = regex.Matches(rule);
        List<string> result = new List<string>();

        foreach (string index in splitReport)
        {
            result.Add(index);
        }
        return result;

    }

    public override void part1()
    {
        List<string> splitReport = new List<string>();
        
        //for each full report 
        for (int i = 0; i < reports.Count; i++)
        {
            bool correct = true;
            splitReport = splitUpReport(reports[i]);
            //for each 
            foreach (string rule in rules)
            {
                correct = doesRuleApply(splitReport, rule);
            }



        }

        Console.WriteLine(rules.Count() + "-----------");
        Console.WriteLine(reports.Count() + "-----------");



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

    int isXMAS (int row, int col)
    {
        int sum = 0;
        for(int i =0; i < 8; i++) 
        { 
            if(fullWord(row,col,i) == true) 
                {
                    sum++;
                }
        
        }
        return sum;
        // 8 directions 

    }

    bool isInBounds(int row, int col)
    {
        if(row >= 0 && col >= 0 && row < get_num_rows() && col < get_num_cols()) return true;
        return false;
    }

    int getDirectionColumn(int direction)
    {
        switch (direction)
        {
            case 0:
                return -1;
                break;
            case 1:
                return -1;
                break;
            case 2:
                return 0;
                break;
            case 3:
                return +1;
                break;
            case 4:
                return +1;
                break;
            case 5:
                return +1;
                break;
            case 6:
                return 0;
                break;
            case 7:
                return -1;
                break;

        }
        return 0;
    }
    int getDirectionRow(int direction)
    {
        switch (direction)
        {
            case 0:
                return 0;
                break;
            case 1:
                return -1;
                break;
            case 2:
                return -1;
                break;
            case 3:
                return 0;
                break;
            case 4:
                return +1;
                break;
            case 5:
                return -1;
                break;
            case 6:
                return +1;
                break;
            case 7:
                return +1;
                break;

        }
        return 0;
    }


    bool fullWord(int row, int col, int direction)
    {
        int directionRow = getDirectionRow(direction);
        int directionCol = getDirectionColumn(direction);

        if (get_char(row, col) == 'X')
        {
            // 0, backward, 1 left up, 2 up, 3  right up, 4 right, 5 right down, 6 down, 7 left down
            bool secondLetter = checkDirection('M', direction, row + directionRow, col + directionCol);
            if (secondLetter == true)
            {
                bool thirdLetter = checkDirection('A', direction, row + (directionRow*2), col + (directionCol *2));
                if (thirdLetter == true)
                {
                    bool fourthLetter = checkDirection('S', direction, row + (directionRow*3), col + (directionCol * 3));
                    if (fourthLetter == true) { return true; }
                }
                else return false;
            }
            else return false;
        }
        return false;

    }

    bool checkDirection(char letter, int direction, int row, int col)
    {

        // 0, backward, 1 left up, 2 up, 3  right up, 4 right, 5 right down, 6 down, 7 left down
        //x >= 0 && x < list.Count && y >= 0 && y < list[x].Count
        if (isInBounds(row, col))
        {
            char resultChar = get_char(row, col);
            if (resultChar == letter) return true;
        }
        

        /*switch (direction)
            {
                case 0:
                if (col < 0 || col > get_num_cols() - 1 || row < 0 || row > get_num_rows() - 1)
                {
                    return false;
                }
                    if (get_char(row, col - 1) == letter) return true;
                    break;

                case 1:
                    if (col-1 < 0 || col-1 > get_num_cols() - 1 || row-1 < 0 || row-1 > get_num_rows() -1) return false;
                    if (get_char(row - 1, col - 1) == letter) return true;
                    break;

                case 2:
                    if (row - 1 < 0 || row - 1 > get_num_rows() - 1 || col < 0 || col > get_num_cols() -1) return false;
                    if (get_char(row - 1, col) == letter) return true;
                    break;

                case 3:
                    if (col + 1 < 0 || col + 1> get_num_cols() - 1 || row - 1 < 0 || row - 1 > get_num_rows() - 1) return false;
                    if (get_char(row - 1, col + 1) == letter) return true;
                    break;

                case 4:
                    if (col + 1 < 0 || col + 1 > get_num_cols() - 1 || row < 0 || row > get_num_rows() -1) return false;
                    if (get_char(row, col + 1) == letter) return true;
                    break;

                case 5:
                    if (col + 1 < 0 || col + 1 > get_num_cols() - 1 || row +11 < 0 || row + 1 > get_num_rows() - 1) return false;
                    if (get_char(row + 1, col+ 1) == letter) return true;
                    break;

                case 6:
                    if (row + 1 < 0 || row + 1 > get_num_rows() - 1 || col <0 || col > get_num_cols() -1) return false;
                    if (get_char(row + 1, col) == letter) return true;
                    break;

                case 7:
                    if (col - 1 < 0 || col - 1 > get_num_cols() - 1 || row + 1 < 0 || row + 1 > get_num_rows() - 1) return false;
                    if (get_char(row + 1, col -1) == letter) return true;
                    break;

            }
        */
        
        return false;

    }




    public override void parse()
    {
        string filePath = "C:\\Git\\Code-advent\\resources\\inputDay4.txt";

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

    void arnebox()
    {
        for (int i = 0; i < 8; ++i)
        {
            Console.WriteLine("direction:" + getDirectionColumn(i) + ", " + getDirectionRow(i));    
        }
    }
    public override void part1()
    {

        int result = 0;
        //for each index in the matric
        for (int r = 0; r < get_num_rows(); r++)
        {
            for (int c = 0; c < get_num_cols(); c++)
            {
                char letter = get_char(r, c);
                if (letter == 'X')
                {
                    int amount = isXMAS(r,c);
                    result += amount;

                }

            }

        }

        Console.WriteLine("Day 4 Part 1 =" + result);



    }

    public override void part2()
    {

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

