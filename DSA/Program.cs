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

            var subarraySum =SubArraySum(DataForSubArray());
            var oneLoopSubArraySum= SubArraySum(DataForSubArray(),3);

            //sorting
            var sortedArray=SelectionSort(GetData());
            var bubbleSort = BubbleSort(GetData());
            var insertionSort = InsertionSort(GetData());
            var mergeTwoArrays = MergeTwoSortedArrays(A(), B());
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

        /// <summary>
        /// You are given an integer array A of length N.
        /// You have to find the sum of all subarray sums of A.
        /// Example:
        /// A = [1, 2, 3]
        /// [1],[1,2],[1,2,3] --10
        /// [2],[2,3] --7
        /// [3] --3
        /// Total its 20
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static long SubArraySum(List<int> arr)
        {
            long result = 0;
            //there are so many ways to find the sub array sum, we have brut force.
            //we will iterate all the elements and then we will try to find the sum....where we need to use two loops to find the sum...            
            for(int i = 0; i < arr.Count; i++)
            {
                for(int j = 0; j < arr.Count; j++)
                {
                    result = result + arr[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Here is the sub array sum problem with one loop.
        /// Ex:A=[1,2,3]
        /// subArrays:
        /// 1
        /// 12
        /// 123
        /// 2
        /// 23
        /// 3
        /// consider the elements that appears at first if (n-i)
        /// ex: 1 appers 3 times
        /// (3-0)==> 3 here 1 is at 0; so it is appeared 3 times.
        /// (3-1)==> 2 here 2 is at 1; so it is appeared 2 times.
        /// (3-2)==> 1 here 3 is at 2; so it is appeared 1 time.
        /// 
        /// now we need to check is there any element that is appeared at middle or anywhere in the subarray.
        /// for that we have (n-i)*i;
        /// (3-0)*0 ==> 0; 1 appears only at the first no where it is appeared.
        /// (3-1)*1 ==> 2; 2 appears at 2 places other than the first place Ex:12 & 123
        /// (3-2)*2 ==> 2; 3 appears at 2 places other than the first palce Ex:123 & 23
        /// 
        /// By this we can conclude that if we can multiply the things with how many times the element appears then we can calulate the sum.
        /// x=(n-i) + (n-i)*i
        /// x/(n-i)=(n-i)/(n-i)+(n-i)*i/(n-i)
        /// x=(n-i)(i+i)
        /// if we multiply with (n-i)(i+1) we will get all the sum of the sub arrays.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long SubArraySum(List<int> arr,int n)
        {
            long result = 0;
            for(int i = 0; i < n; i++)
            {
                result = result + (arr[i] * (i + 1) * (n - i));
            }
            return result;
        }

        /// <summary>
        /// Selection sort: selecting the minimum value and swaping with the same.
        /// </summary>
        /// <param name="arr">Interger array</param>
        /// <returns></returns>
        private static int[] SelectionSort(int[] arr)
        {            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = arr[i];
                int index = -1;
                for(int j = i; j < arr.Length - 1; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        index = j;
                    }
                }

                if(index != -1)
                {
                    Swap(arr, i, index);
                }                
            }
            return arr;

        }

        /// <summary>
        /// BubbleSort: we are swapping the adjucent elments and moving the larger one to top.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int[] BubbleSort(int[] arr)
        {
            int swapCount = 0;
            for(int i = 0; i < arr.Length-1; i++)
            {
                for(int j = 0; j < arr.Length - 1-i; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        Swap(arr, j, j+1);
                        swapCount++;
                    }
                }  
                
                if(swapCount == 0)
                {
                    break;
                }
            }
            return arr;
        }

        /// <summary>
        /// insertion sort is best if the array is already sorted.the time complexity is only O(n).
        /// Array is sorted based on the adjacent element.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int[] InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length - 1; i++)
            {
                int j = i;
                while(j != 0 && arr[j] < arr[j-1])
                {
                    Swap(arr, j, j - 1);
                    j--;
                }
            }
            return arr;
        }

        private static int[] MergeTwoSortedArrays(int[] A,int[] B)
        {
            int n = A.Length;
            int m = B.Length;
            int[] C = new int[n + m];
            //these are the starting points for the all three arrays.
            //here we will be updating these values for the comparision and insertion.
            int a=0, b=0, c=0;
            for(int i = 0; i < C.Length; i++)
            {
                while(a<n && b < m)
                {
                    if(A[a] <= B[b])
                    {
                        C[c] = A[a];
                        a++;
                        c++;
                    }
                    else
                    {
                        C[c] = B[b];
                        c++;
                        b++;
                    }
                }

                while (a < n)
                {
                    C[c] = A[a];
                    c++;
                    a++;
                }
                while (b < n)
                {
                    C[c] = B[b];
                    c++;
                    b++;
                }
            }
            return C;
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

        private  static List<int> DataForSubArray()
        {
            List<int> res = new List<int>();
            res.Add(1);
            res.Add(2);
            res.Add(3);

            return res;
        }

        private static int[] A()
        {
            int[] A = new int[6];
            A[0] = 1;
            A[1] = 2;
            A[2] = 4;
            A[3] = 6;
            A[4] = 8;
            A[5] = 10;

            return A;
        }

        private static int[] B()
        {
            int[] B = new int[6];
            B[0] = 3;
            B[1] = 5;
            B[2] = 7;
            B[3] = 11;
            B[4] = 12;
            B[5] = 15;

            return B;
        }
    }
}
