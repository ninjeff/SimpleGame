using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public static class ItemStats
	{
		public static DGetItemStat GetStat(DGetStat statParser, string statsFile)
		{
			return (itemid, stat) => statParser(itemid, stat, statsFile);
		}
	}
}