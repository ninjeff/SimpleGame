using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class MonsterStats
	{
		private readonly IStatParser statParser;
		private readonly string statsFile;
		private readonly System.Drawing.Image rabbit_image;
		private readonly System.Drawing.Image mystery_monster_image;

		public MonsterStats(IStatParser statParser, string statsFile, System.Drawing.Image rabbit_image, System.Drawing.Image mystery_monster_image)
		{
			this.statParser = statParser;
			this.statsFile = statsFile;
			this.rabbit_image = rabbit_image;
			this.mystery_monster_image = mystery_monster_image;
		}

		public string GetStat(int monsterid, string stat)
		{
			return statParser.GetStat(monsterid, stat, statsFile);
		}

		public System.Drawing.Image GetImage(int monsterid)
		{
			switch (monsterid)
			{
				case 0:
					return rabbit_image;
				default:
					return mystery_monster_image;
			}
		}

		public bool MonsterExists(int monsterid)
		{
			return statParser.IDExists(monsterid, statsFile);
		}
	}
}
