﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public static class Fighting
	{
		private static Random rnd = new Random();

		private static List<List<int>> monsterLevels = new List<List<int>>();
		


		public static void generateMonsterList()
		{
			for (int i = 0; i < 20; i++)
			{
				monsterLevels.Add(new List<int>());
			}
			for (int i = 0; MonsterStats.MonsterExists(i); i++)
			{
				int level = int.Parse(MonsterStats.GetStat(i, "level"));
				monsterLevels[level].Add(i);
			}
		}

		public static int ChooseMonster(int playerlevel)
		{
			int enemylevel = RandomNumber(playerlevel - 1, playerlevel + 1);
			return monsterLevels[enemylevel][RandomNumber(monsterLevels[enemylevel].Count-1)];
		}

		public static int RandomNumber(int minimum, int maximum)
		{
			return (int)rnd.Next(minimum, maximum + 1);
		}

		public static int RandomNumber(int maximum)
		{
			return RandomNumber(0, maximum);
		}

		public static bool FirstHasInitiative(int monsterspeed, int playerspeed)
		{
			return RandomNumber(monsterspeed) > RandomNumber(playerspeed);
		}
	}
}
