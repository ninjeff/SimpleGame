using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
			var itemStats = new ItemStats(statParser);
			var itemGenerator = new ItemGenerator(itemStats);
			var game = new Game(itemGenerator);
			var monsterStats = new MonsterStats(statParser);
			var monsterRepository = new MonsterRepository(monsterStats);
			var start = new MainMenu(game, itemGenerator, monsterRepository);

			Application.Run(start);
		}
	}
}
