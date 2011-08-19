using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class Monster : IWarrior
	{
		private WarriorStats stats;
		private int xpreward;
		private int goldreward;
		private System.Drawing.Image picture;

		public Monster(string name, WarriorStats stats, int xpreward, int goldreward, System.Drawing.Image picture)
		{
			this.Name = name;
			this.stats = stats;
			this.xpreward = xpreward;
			this.goldreward = goldreward;
			this.picture = picture;
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
