using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class Monster : IWarrior
	{
		private Stats stats;
		private int xpreward;
		private int goldreward;
		private System.Drawing.Image picture;

		public static Monster GetById(int monsterid)
		{
			return new Monster(MonsterStats.GetStat(monsterid, "name"))
			{
				stats = new Stats()
				{
					Level = int.Parse(MonsterStats.GetStat(monsterid, "level")),
					MaxHp = int.Parse(MonsterStats.GetStat(monsterid, "hp")),
					Hp = int.Parse(MonsterStats.GetStat(monsterid, "hp")),
					Accuracy = int.Parse(MonsterStats.GetStat(monsterid, "accuracy")),
					Strength = int.Parse(MonsterStats.GetStat(monsterid, "damage")),
					Speed = int.Parse(MonsterStats.GetStat(monsterid, "speed"))
				},
				xpreward = int.Parse(MonsterStats.GetStat(monsterid, "xp")),
				goldreward = int.Parse(MonsterStats.GetStat(monsterid, "gold")),
				picture = SimpleGame.Properties.Resources.rabbit_image
			};
		}

		public Monster(string name)
		{
			this.Name = name;
		}

		public int XPReward
		{
			get { return xpreward; }
		}

		public int GoldReward
		{
			get { return goldreward; }
		}

		public System.Drawing.Image Picture
		{
			get { return picture; }
		}


		public bool Alive
		{
			get { return stats.Alive; }
		}

		public int Damage
		{
			get { return stats.Strength; }
		}

		public int HP
		{
			get
			{
				return stats.Hp;
			}
			set
			{
				stats.Hp = value;
			}
		}

		public int Level
		{
			get { return stats.Level; }
		}

		public string Name { get; private set; }

		public int Speed
		{
			get { return stats.Speed; }
		}

		public bool Hit()
		{
			return stats.Hit();
		}

		public int MaxHP
		{
			get { return stats.MaxHp; }
		}
	}
}
