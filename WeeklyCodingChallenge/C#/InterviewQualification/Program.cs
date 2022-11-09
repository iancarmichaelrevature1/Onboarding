using System;

namespace Interview {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 15, 15, 20, 20 }, 120));
            Console.WriteLine(Interview(new int[] { 2, 3, 8, 6, 5, 12, 10, 18 }, 64));
            Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 25, 15, 20, 20 }, 120));
            Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 15, 15, 20 }, 120));
            Console.WriteLine(Interview(new int[] { 5, 5, 10, 10, 15, 15, 20, 20 }, 130));
        }

        static string Interview(int[] time, int totalTime) {
            int[] timeLimits = new int[] { 5, 5, 10, 10, 15, 15, 20, 20 };
            int total = 0;
            for (int i = 0; i < time.Length; i++) {
                total += time[i];
                if (time[i] > timeLimits[i]) {
                    return "disqualified";
                }
            }
            if (total > totalTime || totalTime > 120) {
                return "disqualified";
            }
            return "qualified";
        }
    }
}