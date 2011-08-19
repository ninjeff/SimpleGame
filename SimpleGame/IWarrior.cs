using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public interface IWarrior
	{
		bool Alive { get; }
		int Damage { get; }
		int HP { get; set; }
		int MaxHP { get; }
		int Level { get; }
		string Name { get; }
		int Speed { get; }

		bool Hit();
	}

	public static class WarriorExtensions
	{
		public static string FormatHpText(this IWarrior warrior)
		{
			return String.Format("{0}/{1}", warrior.HP, warrior.MaxHP);
		}
	}
}
