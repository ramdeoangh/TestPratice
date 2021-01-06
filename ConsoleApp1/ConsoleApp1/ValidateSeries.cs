using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum SeriesType
    {
        FIBO = 0,
        GIO = 1,
        ARITH = 2
    }
    class ValidateSeries
    {
        const int _DEFAULT_VALUE = -999;
        static void Main(string[] args)
        {
            //  Case 1 fibo series
            // int[] arr = new int[] { 0, 1, 1, 2, 3, 5 };
            //  Case 2 giometric series
            //int[] arr = new int[] { 1, 3, 9, 27, 81 };
            // arithmetic series
            //int[] arr = new int[] { 2, 4, 6, 8, 10 };

            int n;
            Console.WriteLine("enter the array length:-");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("\n Input Example Array" + "\n" +
                "FIBO SERIES==={0,1, 1, 2, 3, 5}" + "\n" +
                "GIO SERIES===={1, 3, 9, 27, 81} " + "\n" +
                "ARITHMETIC SERIES==={2, 4, 6, 8, 10} "
                );

            Console.WriteLine("\n See the above example, Enter the array elements==");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Array Length", n);

            Console.WriteLine("Input array elements are:-");

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            string resultType = string.Empty;

            Array.Sort(arr);

            int result = CheckArray(arr.Length, arr, out resultType);

            Console.WriteLine("\n" + resultType + result.ToString());

            Console.ReadLine();
        }


        static int CheckArray(int n, int[] arr, out string resultType)
        {

            resultType = "default";
            int isGIO = _DEFAULT_VALUE;
            int isArith = _DEFAULT_VALUE;

        
            int isFibo = IsFibonacci(arr.Length, arr);
           
            if (isFibo == _DEFAULT_VALUE)
                isGIO = IsGio(arr.Length, arr);

            if (isGIO == _DEFAULT_VALUE)
                isArith = IsArithmetic(arr.Length, arr);

            if (isFibo != _DEFAULT_VALUE)
            {
                resultType = "The Given array is fibonacci series and the next series value is:=";
                return isFibo;
            }
            else if (isGIO != _DEFAULT_VALUE)
            {
                resultType = "The Given array is Giometric series and the next series value is:=";

                return isGIO;

            }
            else if (isArith != _DEFAULT_VALUE)
            {
                resultType = "The Given array is arithmetic series and the next series value is:=";

                return isArith;
            }
            else
            {
                resultType = "The Given array is not matching with any of these series fibonacci,geometric,arithmetic";

                return _DEFAULT_VALUE;
            }
        }


        static int IsFibonacci(int n, int[] arr)
        {
            
            bool res = true;
            int returnValue = _DEFAULT_VALUE;


            for (int i = 2; i < n; i++)
            {
                if ((arr[i - 1] + arr[i - 2]) != arr[i])
                {
                    res = false;
                    break;
                }

            }
            if (res)
            {
                for (int j = 2; j < n; j++)
                {
                    if (j == n - 2)
                    {
                        returnValue = arr[j] + arr[j + 1];
                        break;
                    }

                }
            }
            return returnValue;
        }
        static int IsGio(int n, int[] arr)
        {
             
            bool res = true;
            int returnValue = _DEFAULT_VALUE;
            if (arr[0] == 0)
                return returnValue;
            int diffRatio = arr[1] / arr[0];

            for (int i = 2; i < n; i++)
            {
                if ((arr[i] / arr[i - 1]) != diffRatio)
                {
                    res = false;
                    break;
                }

            }
            if (res)
            {
                returnValue = arr[n - 1] * diffRatio;
            }
            return returnValue;
        }

        static int IsArithmetic(int n, int[] arr)
        {
            
            bool res = true;
            int returnValue = _DEFAULT_VALUE;
            int diff = arr[1] - arr[0];
            for (int i = 2; i < n; i++)
            {
                if ((arr[i] - arr[i - 1]) != diff)
                {
                    res = false;
                    break;
                }
            }
            if (res)
            {
                returnValue = arr[n - 1] + diff;
            }
            return returnValue;
        }
    }
}
