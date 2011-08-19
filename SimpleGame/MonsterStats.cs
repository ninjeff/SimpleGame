using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class MonsterStats
	{
		private readonly IStatParser statParser;

		public MonsterStats(IStatParser statParser)
		{
			this.statParser = statParser;
		}

		public string GetStat(int monsterid, string stat)
		{
			return statParser.GetStat(monsterid, stat, SimpleGame.Properties.Resources.monsters);
		}

		public System.Drawing.Image GetImage(int monsterid)
		{
			switch (monsterid)
			{
				case 0:
					return SimpleGame.Properties.Resources.rabbit_image;
				default:
					return SimpleGame.Properties.Resources.mystery_monster_image;
			}
		}

		public bool MonsterExists(int monsterid)
		{
			return statParser.IDExists(monsterid, SimpleGame.Properties.Resources.monsters);
		}
	}
}
