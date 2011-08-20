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

			var bootstrapper = new Bootstrapper();
			bootstrapper.Register();
			var start = bootstrapper.ResolveForm();
			Application.ApplicationExit += (s, e) => bootstrapper.Release(start);

			Application.Run(start);
		}
	}
}
