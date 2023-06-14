namespace lab3;

public class Operations
{
   public static int EuclideanAlgorithm(int n, int m)
    {
        int nod = 0;
        while(m != n)
        {
            if(m > n) m = m - n;
            else n = n - m;
        }
        nod = n;
        return nod;
    }

    public static int EuclideanAlgorithm(int a, int b, int c)
    {
        int gcd = 1;
        int min = Math.Min(Math.Min(a, b), c);
        for (int i = 1; i <= min; i++)
        {
            if (a % i == 0 && b % i == 0 && c % i == 0) gcd = i;
        }
        return gcd;
    }
    public static List<int> SieveOfEratosthenes(int start, int end)
    {
        List<int> primes = new List<int>();
        bool[] isComposite = new bool[end + 1];
        for (int i = 2; i <= end; i++)
        {
            if (!isComposite[i])
            {
                if (i >= start) primes.Add(i);
                for (int j = i * i; j <= end; j += i)
                isComposite[j] = true; 
            }
        }
        return primes;
    }
  
   



}