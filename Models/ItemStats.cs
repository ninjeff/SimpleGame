using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public class ItemStats
	{
		private readonly IStatParser statParser;
		private readonly string statsFile;
		private readonly System.Drawing.Image rabbit_image;
		private readonly System.Drawing.Image mystery_monster_image;

		public ItemStats(IStatParser statParser, string statsFile, System.Drawing.Image rabbit_image, System.Drawing.Image mystery_monster_image)
		{
			this.statParser = statParser;
			this.statsFile = statsFile;
			this.rabbit_image = rabbit_image;
			this.mystery_monster_image = mystery_monster_image;
		}

		public string GetStat(int itemid, string stat)
		{
			return statParser.GetStat(itemid, stat, statsFile);
		}

		public System.Drawing.Image GetImage(int itemid)
		{
			switch (itemid)
			{
				case 0:
					return rabbit_image;
				default:
					return mystery_monster_image;
			}
		}

	}
}
