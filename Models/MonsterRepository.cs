using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public class MonsterRepository
	{
		private IDictionary<int, ICollection<int>> monsterLevels;
		private readonly DGetMonsterStat getMonsterStat;
		private readonly DMonsterExists monsterExists;
		private readonly System.Drawing.Image rabbit_image;

		public MonsterRepository(DGetMonsterStat getMonsterStat, DMonsterExists monsterExists, System.Drawing.Image rabbit_image)
		{
			this.getMonsterStat = getMonsterStat;
			this.monsterExists = monsterExists;
			this.rabbit_image = rabbit_image;
		}

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
			var name = getMonsterStat(monsterid, "name");
			var stats = new WarriorStats()
			{
				Level = int.Parse(getMonsterStat(monsterid, "level")),
				MaxHp = int.Parse(getMonsterStat(monsterid, "hp")),
				Hp = int.Parse(getMonsterStat(monsterid, "hp")),
				Accuracy = int.Parse(getMonsterStat(monsterid, "accuracy")),
				Strength = int.Parse(getMonsterStat(monsterid, "damage")),
				Speed = int.Parse(getMonsterStat(monsterid, "speed"))
			};
			var xp = int.Parse(getMonsterStat(monsterid, "xp"));
			var gold = int.Parse(getMonsterStat(monsterid, "gold"));
			var picture = rabbit_image;

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
				for (int i = 0; monsterExists(i); i++)
				{
					int level = int.Parse(getMonsterStat(i, "level"));
					monsterLevels[level].Add(i);
				}
			}
		}
	}
}
