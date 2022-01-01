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
            //we can print an array from here....
        }

        private static int[] ReverseArray(int[] arr)
        {
            //here we are giving the i and j vales to iterate in the while loop.
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
    }
}
