using System;
					
public class Program
{
	/*
Inspired by this tweet, today's challenge is to calculate the additive persistence of a number, 
defined as how many loops you have to do summing its digits until you get a single digit number. 
Take an integer N:

Add its digits

Repeat until the result has 1 digit

The total number of iterations is the additive persistence of N.

Your challenge today is to implement a function that calculates the additive persistence of a number.

Examples
13 -> 1
1234 -> 2
9876 -> 2
199 -> 3
	*/
	public static void Main()
	{
		Console.Write("Integer? ");
		var number = Console.ReadLine();
		
		var digits = number.ToCharArray();
		int iterations = 0;
		while (digits.Length > 1)
		{
			iterations++;
			int total = 0;
			foreach (var digit in digits)
			{
				total += int.Parse(digit.ToString());
			}
			Console.WriteLine();
			digits = total.ToString().ToCharArray();
		}
		Console.WriteLine("Additive persistence: "+iterations);
	}
}
