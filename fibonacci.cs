using System;
					
public class Program
{
	public static void Main()
	{
		int last = 0;
		int next = 1;
		
		Console.WriteLine("Stop at what number? ");
		int stop = Convert.ToInt32(Console.ReadLine());
		
		Console.Write(last + ", ");
		next += last;
		
		while (next <= stop)
		{
			Console.Write(next);
			if (next <= stop)
			{
				Console.Write(", ");
			}
			int a = next;
			next += last;
			last = a;
		}
	}
}
