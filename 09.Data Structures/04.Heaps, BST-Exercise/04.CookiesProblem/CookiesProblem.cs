namespace _04.CookiesProblem
{
    using Wintellect.PowerCollections;

    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();
            
            priorityQueue.AddMany(cookies);

            int currentMinSweetness = priorityQueue[0];
            int steps = 0;

            while (currentMinSweetness < minSweetness && priorityQueue.Count > 1)
            {
                int firstSweetCookie = priorityQueue.RemoveFirst();
                int secondSweetCookie = priorityQueue.RemoveFirst();

                int newCookie = firstSweetCookie + (2 * secondSweetCookie);
                priorityQueue.Add(newCookie);
                currentMinSweetness = priorityQueue.GetFirst();
                steps++;
            }

            return currentMinSweetness < minSweetness ? -1 : steps;

        }
    }
}
