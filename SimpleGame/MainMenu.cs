using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleGame
{
	public partial class MainMenu : Form
	{
		private readonly Game game;
		private readonly ItemGenerator itemGenerator;
		private readonly MonsterRepository monsterRepository;

		public MainMenu(Game game, ItemGenerator itemGenerator, MonsterRepository monsterRepository)
		{
			InitializeComponent();
			this.game = game;
			this.itemGenerator = itemGenerator;
			this.monsterRepository = monsterRepository;
		}

		private void NewGamePicture_Click(object sender, EventArgs e)
		{
			this.newgame();
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.newgame();
		}

		private void newgame()
		{
			NewGame window = new NewGame(game);
			if (window.ShowDialog(this) == DialogResult.OK)
			{
				var player = game.StartGame(window.CharacterNameTextBox());
				GameMenu gameMenu = new GameMenu(game, itemGenerator, player, monsterRepository);
				this.Hide();
				gameMenu.Show();
			}
		}

		private void LoadGamePicture_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				var player = game.LoadGame(openFileDialog.FileName);
				GameMenu gameMenu = new GameMenu(game, itemGenerator, player, monsterRepository);
				this.Hide();
				gameMenu.Show();
			}
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

	}
}
