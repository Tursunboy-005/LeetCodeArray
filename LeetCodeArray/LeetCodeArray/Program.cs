using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] ratings = { 1, 0, 2 }; // Example input, you can change it as needed
        Solution solution = new Solution();
        int result = solution.Candy(ratings);
        Console.WriteLine("Total candies needed: " + result);
    }

    public int Candy(int[] ratings)
    {
        int n = ratings.Length;
        if (n == 0) return 0;

        int[] candies = new int[n];
        // Step 1: Initialize every child with 1 candy
        for (int i = 0; i < n; i++)
        {
            candies[i] = 1;
        }

        // Step 2: Left to right pass
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                candies[i] = candies[i - 1] + 1;
            }
        }

        // Step 3: Right to left pass
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        // Step 4: Sum the candies
        int totalCandies = 0;
        for (int i = 0; i < n; i++)
        {
            totalCandies += candies[i];
        }

        return totalCandies;
    }
}
