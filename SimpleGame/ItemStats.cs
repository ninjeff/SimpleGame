using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class ItemStats
	{
		private readonly IStatParser statParser;

		public ItemStats(IStatParser statParser)
		{
			this.statParser = statParser;
		}

		public string GetStat(int itemid, string stat)
		{
			return statParser.GetStat(itemid, stat, SimpleGame.Properties.Resources.items);
		}

		public System.Drawing.Image GetImage(int itemid)
		{
			switch (itemid)
			{
				case 0:
					return SimpleGame.Properties.Resources.rabbit_image;
				default:
					return SimpleGame.Properties.Resources.mystery_monster_image;
			}
		}

	}
}
