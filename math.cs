using System;	

namespace MathMain
{
	using Maths1;
	class TestMath
	{
		public static void Main(String[] args)
		{
			Console.WriteLine(Math2.square(10));
			Console.WriteLine(Math2.cube(2));
			Console.WriteLine(Math2.half(64));
			Console.WriteLine(Math2.round((67.56)));
			Console.WriteLine(Math2.half((76.77)));
		}
	}

}

namespace Maths1
{
	class Math1
	{
		public static int square(int number)
		{
			return number * number;
		}
		public static int cube(int number)
		{
			return number * number * number;
		}
		public static double half(double number)
		{
			return (number/(double)2);
		}
		public static double round(double number)
		{
			return Math.Round(number);
		}
	}

	class Math2 : Math1
	{
		public static double half(int number)
		{
			return (number/(double)2);
		}
	}
}