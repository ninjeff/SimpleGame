using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public static class MonsterStats
	{
		public static DGetMonsterStat GetStat(DGetStat getStat, string statsFile)
		{
			return (monsterid, stat) => getStat(monsterid, stat, statsFile);
		}

		public static DMonsterExists Exists(DIdExists idExists, string statsFile)
		{
			return monsterid => idExists(monsterid, statsFile);
		}
	}
}
