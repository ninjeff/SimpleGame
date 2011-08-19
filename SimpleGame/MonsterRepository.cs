using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class MonsterRepository
	{
		private IDictionary<int, ICollection<int>> monsterLevels;

		public int ChooseMonster(int playerlevel)
		{
			this.EnsureMonsterListGenerated();

			int enemylevel = Randomness.RandomNumber(playerlevel - 1, playerlevel + 1);
			var availableMonsterIds = monsterLevels[enemylevel];
			return availableMonsterIds.GetRandomElement();
		}

		private void EnsureMonsterListGenerated()
		{
			if (monsterLevels == null)
			{
				monsterLevels = new Dictionary<int, ICollection<int>>();
				for (int i = 0; i < 20; i++)
				{
					monsterLevels[i] = new List<int>();
				}
				for (int i = 0; MonsterStats.MonsterExists(i); i++)
				{
					int level = int.Parse(MonsterStats.GetStat(i, "level"));
					monsterLevels[level].Add(i);
				}
			}
		}
	}
}
