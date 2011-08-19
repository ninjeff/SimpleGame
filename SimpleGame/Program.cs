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

			var monsterRepository = new MonsterRepository();
			var start = new MainMenu(monsterRepository);

			Application.Run(start);
		}
	}
}
