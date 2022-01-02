using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reverse an arrary with no space.
            int[] result=ReverseArray(GetData());

            BeggarsOutsideTemple(5, DataForBeggersProblem());


        }

        private static int[] ReverseArray(int[] arr)
        {
            //here we are giving the i and j values to iterate in the while loop.
            int i = 0, j = arr.Length - 1;
            while (i < j)
            {
                //we are using swap for swaping the elements with in the array....
                //so that whith no space we are swaping the elements..
                Swap(arr,i, j);
                i++;
                j--;
            }
            return arr;
        }

        private static void Swap(int[] arr,int i,int j)
        {
            //we are using XOR for swaping because its easy and it wont comsume the time much..so
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[i] ^ arr[j];
        }

        /// <summary>
        /// There are N (N > 0) beggars sitting in a row outside a temple. Each beggar initially has an empty pot. 
        /// When the devotees come to the temple, they donate some amount of coins to these beggars. 
        /// Each devotee gives a fixed amount of coin(according to his faith and ability) to some K beggars sitting next to each other.
        /// Given the amount donated by each devotee to the beggars ranging from i to j index, where 1 <= i <= j <= N, find out the final amount of money in each beggar's 
        /// pot at the end of the day, provided they don't fill their pots by any other means.
        /// Example:
        /// Input:
        /// N = 5, D = [[1, 2, 10], [2, 3, 20], [2, 5, 25]]
        /// Return: [10, 55, 45, 25, 25]
        /// Explanation:
        /// => First devotee donated 10 coins to beggars ranging from 1 to 2. Final amount in each beggars pot after first devotee: [10, 10, 0, 0, 0]
        /// => Second devotee donated 20 coins to beggars ranging from 2 to 3. Final amount in each beggars pot after second devotee: [10, 30, 20, 0, 0]
        /// => Third devotee donated 25 coins to beggars ranging from 2 to 5. Final amount in each beggars pot after third devotee: [10, 55, 45, 25, 25]
        /// </summary>
        /// <param name="num">size of an array</param>
        /// <param name="data">List of values that we need to iterate</param>
        /// <returns></returns>
        private static List<int> BeggarsOutsideTemple(int num,List<List<int>> data)
        {
            int[] res = new int[num];
            foreach (var lst in data)
            {
                int l = lst[0];
                int r = lst[1];
                int p = lst[2];

                res[l-1] += p;
                if (r-1 < res.Length - 1)
                {
                    res[r] -= p;
                } 
            }

            var sum = res[0];
            for(int i = 1; i < res.Length; i++)
            {
                sum += res[i];
                res[i] = sum;
            }          
            return res.ToList();
        }

        private static int[] GetData()
        {
            int[] arr = new int[8];
            arr[0] = 3;
            arr[1] = 2;
            arr[2] = -1;
            arr[3] = 6;
            arr[4] = 7;
            arr[5] = 3;
            arr[6] = 1;
            arr[7] = 9;
            return arr;
        }

        private static List<List<int>> DataForBeggersProblem()
        {
            List<List<int>> res = new List<List<int>>();

            List<int> lst1 = new List<int>();
            lst1.Add(1);
            lst1.Add(2);
            lst1.Add(10);

            List<int> lst2 = new List<int>();
            lst2.Add(2);
            lst2.Add(3);
            lst2.Add(20);

            List<int> lst3 = new List<int>();
            lst3.Add(2);
            lst3.Add(5);
            lst3.Add(25);

            res.Add(lst1);
            res.Add(lst2);
            res.Add(lst3);

            return res;
        }
    }
}
