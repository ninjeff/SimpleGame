using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	[Serializable]
	public class WarriorStats
	{
		private int hp;
		public int Hp
		{
			get { return this.hp; }
			set { this.hp = Math.Min(value, this.MaxHp); }
		}
		public int MaxHp { get; set; }
		public int Level { get; set; }
		public int Accuracy { get; set; }
		public int Strength { get; set; }
		public int Speed { get; set; }

		public bool Hit()
		{
			return Randomness.RandomNumber(100) <= this.Accuracy;
		}

		public bool Alive { get { return this.hp >= 0; } }
	}
}
