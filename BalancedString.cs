using System;
					
public class Program
{
	/*
	Given a string containing only the characters x and y, find whether there are the same number of xs and ys.
	*/
	public static void Main()
	{
		Console.WriteLine("String? ");
		string count = Console.ReadLine();
		Console.WriteLine(Balanced(count));
	}
	
	public static bool Balanced(string count)
	{
		int xs = 0;
		int ys = 0;
		
		foreach (char c in count.ToCharArray())
		{
			if (c == 'x')
			{
				xs++;
			}
			else if (c == 'y')
			{
				ys++;
			}
		}
		
		return xs == ys;
	}
}
