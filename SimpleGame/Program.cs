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

			var statParser = new XmlStatParser();
			var itemStats = new ItemStats(statParser, SimpleGame.Properties.Resources.items, SimpleGame.Properties.Resources.rabbit_image, SimpleGame.Properties.Resources.mystery_monster_image);
			var itemGenerator = new ItemGenerator(itemStats, SimpleGame.Properties.Resources.armour_image, SimpleGame.Properties.Resources.potion_image, SimpleGame.Properties.Resources.weapon_image);
			var game = new Game(itemGenerator);
			var monsterStats = new MonsterStats(statParser, SimpleGame.Properties.Resources.monsters, SimpleGame.Properties.Resources.rabbit_image, SimpleGame.Properties.Resources.mystery_monster_image);
			var monsterRepository = new MonsterRepository(monsterStats, SimpleGame.Properties.Resources.rabbit_image);
			var start = new MainMenu(game, itemGenerator, monsterRepository);

			Application.Run(start);
		}
	}
}
