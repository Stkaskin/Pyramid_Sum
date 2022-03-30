using System;
using System.Collections.Generic;
namespace intern { 
public class Program
{
    //Select detail show  , if u select detail true it's very long lines if select detail false it's few lines
    static bool detail = false;
    public static List<List<int>> getNumbers()
    {
        String a = "215 193 124 117 237 442 218 935 347 235 320 804 522 417 345 229 601 723 835 133 124 248 202 277 433 207 263 257 359 464 504 528 516 716 871 182 461 441 426 656 863 560 380 171 923 381 348 573 533 447 632 387 176 975 449 223 711 445 645 245 543 931 532 937 541 444 330 131 333 928 377 733 017 778 839 168 197 197 131 171 522 137 217 224 291 413 528 520 227 229 928 223 626 034 683 839 053 627 310 713 999 629 817 410 121 924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
        var slpitPr = a.Split(' ');
        List<List<int>> numbers = new List<List<int>>();
        int c = 1;
        int index = 0;
        while (index < slpitPr.Length)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < c; i++)
            {
                temp.Add(Convert.ToInt32(slpitPr[index++]));

            }
            numbers.Add(temp);
            c++;
        }

        return numbers;
    }
    public static void Main(string[] args)
    {

        List<List<int>> list = new List<List<int>>();
        List<int> listRows = new List<int>();
        list = getNumbers();
        Console.WriteLine(list.Count + "");
        int spacer = list.Count;
        foreach (var item in list)
        {
            for (int i = 0; i < spacer; i++)
            {
                Console.Write(" ");
            }
            spacer--;
            foreach (var row in item)
            {
                Console.Write(row + " ");
            }
            Console.WriteLine("");

        }





        startprogram(list);

    }
    private static void wrtieListRow(List<List<int>> list, int count)
    {
        if (detail)
        {
            Console.WriteLine("\n New Tour \n\n");
            int spacer = list.Count;
            for (int index = 0; index < list.Count; index++)
            {
                var item = list[index];
                for (int i = 0; i < spacer; i++)
                {
                    Console.Write(" ");
                }
                spacer--;
                foreach (var row in item)
                {
                    Console.Write(row + " ");

                }
                if (count == index)
                    break;
                Console.WriteLine("");

            }
        }
    }
    public static void startprogram(List<List<int>> list)
    {
        //   list.
        List<int> root = new List<int>();
        List<List<int>> roots = new List<List<int>>();



        int row = 0;
        int x1 = 0;
        if (!primeControl(list[0][0]))
        {
            if (detail)
                Console.WriteLine("first root");
            root.Add(0);
            roots.Add(root);
            row++;

        }
        for (int i = 0; i < roots.Count; i++)
        {
            row = roots[i].Count;
            x1 = roots[i][row - 1];
            root = roots[i];
            int a = 0;
            for (; row < list.Count;)
            {
                wrtieListRow(list, row);
                int g = list[row][++x1];
                bool bul = false;
                var temp = new List<int>();
                temp.AddRange(root);
                if (!primeControl(g))
                {


                    root.Add(x1);
                    if (detail)
                        Console.WriteLine("\n " + (x1));
                    //  roots.Add(root);

                    bul = true;

                }
                int g1 = list[row][x1 - 1];
                if (!primeControl(g1))
                {
                    if (detail)
                        Console.WriteLine("\n " + (x1 - 1));
                    if (!bul)
                    {
                        root.Add(x1);
                        if (detail)

                            Console.WriteLine("\n " + (x1));

                    }
                    else
                    {
                        temp.Add(x1 - 1);
                        roots.Add(temp);
                        if (detail)
                            Console.WriteLine("new root left");
                    }
                    bul = true;


                }
                if (!bul)
                    break;
                row++;





            }
        }
        if (detail)
        {
            for (int y = 0; y < roots.Count; y++)
            {
                Console.WriteLine();
                var item = roots[y];
                for (int i = 0; i < item.Count; i++)
                {
                    Console.Write(" " + item[i]);
                }

            }
        }
        int maxLong = 0;
        int maxSum = 0;
        int maxSumIndex = 0;

        for (int y = 0; y < roots.Count; y++)
        {

            var item = roots[y];
            if (maxLong < item.Count)
                maxLong = item.Count;
            int tempsum = 0;
            if (detail)
                Console.WriteLine("\n Long :" + item.Count);
            for (int i = 0; i < item.Count; i++)
            {
                int temp_write = list[i][item[i]];
                if (detail)
                    Console.Write(" " + temp_write);
                tempsum += temp_write;
            }
            if (tempsum > maxSum)
            {
                maxSumIndex = y;
                maxSum = tempsum;
            }


        }
        var tempitem = roots[maxSumIndex];
        string tempRowData = "";
        for (int i = 0; i < tempitem.Count; i++)
        {

            tempRowData += list[i][tempitem[i]] + " ";
        }
        Console.WriteLine("\n Max Sum: " + maxSum + " RowCount: " + tempitem.Count + " >> Row: " + tempRowData);
        Console.WriteLine("Max Long: " + maxLong);

    }
    private static bool primeControl(int temp)
    {
        for (int i = temp / 2; i > 1; i--)
        {
            if (temp % i == 0)
                return false;
        }
        if (temp == 1)
            return false;
        else
            return true;
    }

}


}