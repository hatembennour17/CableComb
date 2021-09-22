using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        private static int numberofCombos;
        private static int n;
        private static int k;
        private static int[] storageArr;
        private static double[] FinalListResults;
        private static String str = "";
        public static void Main()
        {
            for (int i = 2; i < 13; i++)
            {
                n = 9;
   
                storageArr = new int[i];
                FinalListResults = new double[i];
                GenCombinationsWithRep();
            }
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Test.txt");
                //Write a line of text
                sw.WriteLine(str);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void GenCombinationsWithRep(int index = 0, int element = 0)
        {
            if (index >= storageArr.Length)
            {
                PrintCombo();
                return;
            }
            //List<double> sizesList = new List<double>
            //{
            //    0.13,
            //    0.35,
            //    0.5,
            //    0.75,
            //    1,
            //    1.5,
            //    2,
            //    2.5,
            //    6
            //};
            for (int i = element; i < n; i++)
            {
                double s = 0;
                switch (i)
                {
                    case 0:
                        s=0.13;
                        break;
                    case 1:
                       s=0.35;
                        break;
                    case 2:
                        s = 0.5;
                        break;
                    case 3:
                        s = 0.75;
                        break;
                    case 4:
                        s = 1;
                        break;
                    case 5:
                        s = 1.5;
                        break;
                    case 6:
                        s = 2;
                        break;
                    case 7:
                        s = 2.5;
                        break;
                    case 8:
                        s = 6;
                        break;
                    default:
                        break;
                }

                FinalListResults[index] =  s;
                GenCombinationsWithRep(index + 1, i);
            }
        }

        private static void PrintCombo()
        {

            double sumSizes = 0;
            foreach (var item in FinalListResults)
            {
                //Array FinalListResults = Array();
                //FinalListResults.Add(item);
                sumSizes = sumSizes + item;
               
            }
            if (sumSizes < 18)
            {
                Console.WriteLine(
                    "{0,3}: {1} Sum= {2}",
                    ++numberofCombos,
                    string.Join(", ", FinalListResults), sumSizes);


                str = str  + ++numberofCombos + " : " + string.Join(", ", FinalListResults) +"Sum: " +  sumSizes + @"\n";
               
            }

        }
    }
}
