using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of           squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
            
        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///   *******
        ///  *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>
        private static void printTriangle(int n)
        {
            try
            {
                // write your code here
                int i, j, k, st;
                // Number of stars in a particular line is the Nth odd number. N being the line number. Nth odd number is calculated as below:
                int allst = 2 * n - 1; // Number of starts in the last line
                for (i = 1; i <= n; i++)   //loop to print the line
                {
                    st = 2 * i - 1;  // Calculate the number of stars in this line
                    k = ((allst - st) / 2); //Calculate the blank space before the first star in the line. It is the difference between the stars in the last line and the current line divide by 2. 
                    for (j = 1; j <= k; j++) // loop to print the blank spaces.
                    {
                        Console.Write(" ");
                    }

                    for (j = 1; j <= st; j++) //loop to print the stars
                    {
                        Console.Write("*");
                    }



                    Console.WriteLine("");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
         * Self Reflection:
         * *******************************************
         * In this problem, there were 2 main things. 
         * 1. To calculate the number of stars to be printed on the line (the nth odd number) and 
         * 2. To calculate the blank space before the 1st star
         * To get logic took me around 30 mins and coding took around an hour. 
         * 
         */



        /// <summary>
        ///<para>
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series
        /// Returns : N/A
        /// Return type: void
        ///</para>
        /// </summary>
        /// <param name="n2"></param>
        private static void printPellSeries(int n2)
        {
            try
            {
                // write your code here.
                // these are the edge cases when the user enters 1 or 2
                if (n2 == 1)
                    Console.Write("0");  // Prints the 1st Pell number
                if (n2 == 2)
                    Console.Write("0, 1"); // Prints the first 2 Pell numbers

                // When the user asks for more than 2 Pell numbers
                if (n2 > 2)
                {
                    Console.Write("0, 1"); // Prints the first 2 Pell numbers

                    int a = 0;  // the first Pell number (stores the (n-2)th Pell number)
                    int b = 1;  //the second Pell number (stores the (n-1)th Pell number)
                    int c; //n
                    for (int i = 3; i <= n2; i++)
                    {
                        c = 2 * b + a; //calculating the Pell number
                        a = b;         // storing the n-2 Pell number for next loop
                        b = c;           // storing the n-1 Pell number for next loop
                        Console.Write(", " + c);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
         * Self Reflection:
         * *********************************************************************
         * The main reflection in this problem was the corner case.
         * The first 2 Pell numbers are not calculated but need to be shown. 
         * The problem  took 25 mins to get the logic and 1 hr 15 mins to code it. 
         * 
         */


        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: A = 3 will return the output : false
        ///Input: A = 4 will return the output: true
        ///Input: A = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>

        private static bool squareSums(int n3)
        {
            try
            {
                // write your code here
                for (long i = 0; i * i <= n3; i++) // First loop to calculate i*
                    for (long j = 0; j * j <= n3; j++) // Second loop to calculate j*
                    {
                        if (i * i + j * j == n3)  // If found return
                            return true;
                        if (i * i + j * j > n3)  // Contion to stop 
                            break;
                    }



                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         * Self Reflection:
         * *********************************************************************
         * The main reflection on this was the "Time Complexity". 
         * I was able to do the problem in O(n^2), this works well for small numbers. But take very long with big numbers.
         * The first run of the problem took an hour, but I invested a few more hours trying to reduce the time complexity. 
         */

        /// <summary>
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns>Number of pairs in the array with the given number as difference</returns>
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                Dictionary<int, int> numbed = new Dictionary<int, int>();  // Data Dictionary to store pairs
                // write your code here.
                int p, q;
                for (int i = 0; i < nums.Length; i++) // Looping through the array
                    for (int j = i + 1; j < nums.Length; j++) // Staggered loop starting from i+1
                        if (nums[i] - nums[j] == k || nums[j] - nums[i] == k) // Checking the 2 combination
                        {

                            /* To make it simple the
                            * lower number is the key in the dictionary
                            * higher number is the value
                            */
                            if (nums[i] < nums[j])
                            {
                                p = nums[i];
                                q = nums[j];
                            }
                            else
                            {
                                p = nums[j];
                                q = nums[i];
                            }

                            // If key (lower number) does not exist, add it to the dictionary
                            if (!numbed.ContainsKey(p))
                                numbed.Add(p, q);
                        }

                return numbed.Count; // Return the size of the dictionary
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }


        /*
         * Self Reflection:
         * *********************************************************************
         * The challenge in this question was to make sure that duplicates are not counted. 
         * The solution was that if that there will only be one number from which a number can be substraacted. 
         * Example: A - B = C, so if A and C are known there will only be 1 B. 
         * It took around an hour to figure out the logic and another hour to code it.
         * 
         */



        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@usf.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            try
            {


                HashSet<string> hass = new HashSet<string>(); // Hash datastructure to store the email IDs. 
                // write your code here.
                foreach (string em in emails) //go through all the email IDs
                {
                    String[] fg = em.Split('@'); // Split the email on '@'
                    string emid = fg[0]; // local name
                    string dom = fg[1]; // domain name
                    String[] spem = emid.Split('+'); //Split the local name on '+'

                    /* create the correct local name by replacing '.' and just keep the localname before '+'
                     * and attach it to the domain name. 
                     */
                    string fullID = spem[0].Replace(".", "").Trim() + "@" + dom;
                    hass.Add(fullID); // add the full email ID to the Hash datastructure



                }

                return hass.Count; // Return the number of elements in the Hashset
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
         * Self Reflection:
         * *********************************************************************
         * For this Question, it was important to select the correct Data Structure. 
         * I used the Hash Set as it keeps only the unique enteries. 
         * 
         * It took an hour to get the logic and data structure. It took 1.5 hours to code. 
         * In coding it took long to Split and connect strings correctly.
         * 
         */


        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>
        private static string DestCity(string[,] paths)
        {
            try
            {
                HashSet<string> all_origins = new HashSet<string>(); // Hash set to store the Origins
                HashSet<string> all_dest = new HashSet<string>(); // Hash set to store the Destinations
                // write your code here.
                for (int i = 0; i < paths.GetLength(0); i++) // Go through all the origin, Dest pairs
                {

                    all_origins.Add(paths[i, 0]); // Add origin to Hash Set
                    all_dest.Add(paths[i, 1]); // Add Dest to Hash Set 
                }

                IEnumerable<string> destination = from city in all_dest.Except(all_origins) select city; // Subtract the Origins hash set from the Destination hash set

                foreach (var dest in destination)
                    return dest; // return the first remaining destination. 




                return "";

            }
            catch (Exception)
            {

                throw;
            }


        }

        /*
         * Self Reflection:
         * *********************************************************************
         * Figuring out the logic and data structures was the most difficult in the Assignment. 
         * This can be coded many ways, this was the first working attempt. 
         * 
         * Figuring out the logic took around 2 hours and coding took an hour. 
         * 
         */


    }
}



