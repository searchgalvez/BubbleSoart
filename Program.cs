using System;

namespace levi
{
    class Program
    {
        static void SwapValues(string[] T, int index1, int index2)
        {
            string temp = T[index1];
            T[index1] = T[index2];
            T[index2] = temp;
        }
        static string[] bubbleSort(string[] arr)
        {
            string temp;
            string[] a = (string[])arr.Clone();
            int l = arr.Length;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    if (a[j].CompareTo(a[j + 1]) > 0)
                    {
                        SwapValues(a, i, j);
                    }
                }
            }
            return a;
        }
        static int binarySearch(String[] a, String x)
        {
            string[] arr = (string[])a.Clone();
            arr = bubbleSort(arr);
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                int res = x.CompareTo(arr[m]);

                // Check if x is present at mid  
                if (res == 0)
                    return m;

                // If x greater, ignore left half  
                if (res > 0)
                    l = m + 1;

                // If x is smaller, ignore right half  
                else
                    r = m - 1;
            }

            return -1;
        }
        /* Prints the array */
        static void printArray(string[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + "\n");
            Console.WriteLine();
        }
        static void merge(string[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            string[] L = new string[n1];
            string[] R = new string[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarry array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (R[j].CompareTo(L[i]) >= 0)
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        static void Mergesort(string[] a, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = (l + r) / 2;

                // Sort first and
                // second halves
                Mergesort(a, l, m);
                Mergesort(a, m + 1, r);

                // Merge the sorted halves
                merge(a, l, m, r);
            }
        }
        static string tab(string s, int w)
        {
            //w is the desired width
            int stringwidth = s.Length;
            int i;
            string resultstring = s;

            for (i = 0; i <= (w - stringwidth) / 8; i++)
            {
                resultstring = resultstring + "\t";
            }
            return resultstring;
        }
        static string[] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file = System.IO.File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;

            // Allocate the data array.
            string[] values = new string[num_cols];

            // Load the array.
            string[] line_r = lines[0].Split(',');
            for (int c = 0; c < num_cols; c++)
            {
                values[c] = line_r[c];
            }


            // Return the values.
            return values;
        }
        static string[] mergeSort(string[] a)
        {
            string[] arr = (string[])a.Clone();
            Mergesort(arr, 0, arr.Length - 1);
            return arr;
        }
        static string[] reverseSort(string[] a)
        {
            string[] arr = (string[])a.Clone();
            Mergesort(arr, 0, arr.Length - 1);
            Array.Reverse(arr);
            return arr;
        }
        // Driver method 
        public static void Main()
        {
            string[] arr = LoadCsv("inputFile.csv");

            Console.WriteLine("Enter Choice:\n1 for Merge Sort\n2 for Binary Search\n3 for Bubble Sort\n4 for Reverse Sort");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                string[] sorted = mergeSort(arr);
                Console.WriteLine("Merge Sort");
                Console.WriteLine("--------------------------------------------------------------------------------");
                for (int i=0; i < arr.Length; i++)
                {
                    string left = String.Format("{0,-50:D}", arr[i]);
                    Console.WriteLine(left+sorted[i]);
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Binary Search");
                string[] sorted = mergeSort(arr);
                Console.WriteLine("--------------------------------------------------------------------------------");
                for (int i=0; i <arr.Length; i++)
                {
                    int idx = binarySearch(sorted, sorted[i]);
                    string left = String.Format("{0,-50:D}", sorted[i]);
                    string left2 = String.Format("{0,-10:D}", i);
                    Console.WriteLine(left + "Index: " + left2 + "Found Index: " + idx);
                }
            }
            if (choice == "3")
            {
                string[] sorted = mergeSort(arr);
                Console.WriteLine("Bubble Sort");
                Console.WriteLine("--------------------------------------------------------------------------------");
                for (int i = 0; i < arr.Length; i++)
                {
                    string left = String.Format("{0,-50:D}", arr[i]);
                    Console.WriteLine(left + sorted[i]);
                }
            }
            if (choice == "4")
            {
                string[] sorted = reverseSort(arr);
                Console.WriteLine("Reverse Sort");
                Console.WriteLine("--------------------------------------------------------------------------------");
                for (int i = 0; i < arr.Length; i++)
                {
                    string left = String.Format("{0,-50:D}", arr[i]);
                    Console.WriteLine(left + sorted[i]);
                }
            }
            
        }
    }
}
