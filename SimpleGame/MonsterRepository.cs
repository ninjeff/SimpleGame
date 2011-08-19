using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class MonsterRepository
	{
		private IDictionary<int, ICollection<int>> monsterLevels;

		public Monster ChooseMonster(int playerlevel)
		{
			this.EnsureMonsterListGenerated();

			int enemylevel = Randomness.RandomNumber(playerlevel - 1, playerlevel + 1);
			var availableMonsterIds = monsterLevels[enemylevel];
			var monsterId = availableMonsterIds.GetRandomElement();
			return this.GetMonsterById(monsterId);
		}

		private Monster GetMonsterById(int monsterid)
		{
			var name = MonsterStats.GetStat(monsterid, "name");
			var stats = new Stats()
			{
				Level = int.Parse(MonsterStats.GetStat(monsterid, "level")),
				MaxHp = int.Parse(MonsterStats.GetStat(monsterid, "hp")),
				Hp = int.Parse(MonsterStats.GetStat(monsterid, "hp")),
				Accuracy = int.Parse(MonsterStats.GetStat(monsterid, "accuracy")),
				Strength = int.Parse(MonsterStats.GetStat(monsterid, "damage")),
				Speed = int.Parse(MonsterStats.GetStat(monsterid, "speed"))
			};
			var xp = int.Parse(MonsterStats.GetStat(monsterid, "xp"));
			var gold = int.Parse(MonsterStats.GetStat(monsterid, "gold"));
			var picture = SimpleGame.Properties.Resources.rabbit_image;

			return new Monster(name, stats, xp, gold, picture);
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
