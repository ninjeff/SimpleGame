using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public class MonsterStats
	{
		private readonly string statsFile;

		public MonsterStats(string statsFile)
		{
			this.statsFile = statsFile;
		}

		public DGetMonsterStat GetStat(DGetStat getStat)
		{
			return (monsterid, stat) => getStat(monsterid, stat, statsFile);
		}

		public DMonsterExists Exists(DIdExists idExists)
		{
			return monsterid => idExists(monsterid, statsFile);
		}
	}
}