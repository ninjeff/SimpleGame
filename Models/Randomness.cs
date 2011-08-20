using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public static class Randomness
	{
		private static Random rnd = new Random();

		public static int RandomNumber(int minimum, int maximum)
		{
			return (int)rnd.Next(minimum, maximum + 1);
		}

		public static int RandomNumber(int maximum)
		{
			return RandomNumber(0, maximum);
		}

		public static T GetRandomElement<T>(this ICollection<T> source)
		{
			var count = source.Count;
			if (count < 1) throw new ArgumentException("Value must not be empty.", "source");

			var index = RandomNumber(count - 1);
			return source.ElementAt(index);
		}
	}
}
