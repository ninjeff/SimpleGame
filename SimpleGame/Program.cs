using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SimpleGame.Models;

namespace SimpleGame
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var getStat = XmlStatParser.GetStat();
			var getItemStat = ItemStats.GetStat(getStat, SimpleGame.Properties.Resources.items);
			var getItemDictionary = new Dictionary<string, DGetItem<Item>>() { 
			{ "armour", ItemGenerator.GetArmour(getItemStat, SimpleGame.Properties.Resources.armour_image) },
			{ "consumable", ItemGenerator.GetConsumable(getItemStat, SimpleGame.Properties.Resources.potion_image)},
			{ "weapon", ItemGenerator.GetWeapon(getItemStat, SimpleGame.Properties.Resources.weapon_image)}
			};
			var getDefaultItem = ItemGenerator.GetDefaultItem(getItemStat);
			var getItem = ItemGenerator.GetItem(getItemStat, getItemDictionary, getDefaultItem);
			var game = new Game(getItem);
			var idExists = XmlStatParser.IDExists();
			var monsterStatsFile = SimpleGame.Properties.Resources.monsters;
			var getMonsterStat = MonsterStats.GetStat(getStat, monsterStatsFile);
			var monsterExists = MonsterStats.Exists(idExists, monsterStatsFile);
			var monsterRepository = new MonsterRepository(getMonsterStat, monsterExists, SimpleGame.Properties.Resources.rabbit_image);
			var start = new MainMenu(game, getItem, monsterRepository);

			Application.Run(start);
		}
	}
}
