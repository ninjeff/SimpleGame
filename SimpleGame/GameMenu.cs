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
	public partial class GameMenu : Form
	{
		private readonly Game game;
		private readonly ItemGenerator itemGenerator;
		private readonly MonsterRepository monsterRepository;
		private Player player;

		public GameMenu(Game game, ItemGenerator itemGenerator, Player player, MonsterRepository monsterRepository)
		{
			InitializeComponent();
			this.game = game;
			this.itemGenerator = itemGenerator;
			this.player = player;
			this.monsterRepository = monsterRepository;
			this.UpdateText();
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewGame window = new NewGame(game);
			if (window.ShowDialog(this) == DialogResult.OK)
			{
				this.player = game.StartGame(window.CharacterNameTextBox());
				this.UpdateText();
			}
		}

		private void FightMonstersPicture_Click(object sender, EventArgs e)
		{
			var monster = monsterRepository.ChooseMonster(player.Level);

			BattleScreen fight = new BattleScreen(player, monster);
			fight.ShowDialog();
			this.UpdateText();
		}

		private void ShopPicture_Click(object sender, EventArgs e)
		{
			ShopMenu goshopping = new ShopMenu(player, itemGenerator);
			goshopping.ShowDialog();
			this.UpdateText();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			quitgame(sender, e);
		}

		private void QuitPicture_Click(object sender, EventArgs e)
		{
			quitgame(sender, e);
		}

		private void quitgame(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit the game?", "Really Quit?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
			{
				Environment.Exit(0);
			}
		}

		private void UpdateText()
		{
			this.NameLabel.Text = player.Name;
			this.XPLabel.Text = player.XPText;
			this.HPLabel.Text = player.FormatHpText();
			this.LevelLabel.Text = player.Level.ToString();
			this.GoldLabel.Text = player.Gold.ToString();
		}

		private void SavePicture_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				game.SaveGame(player, saveFileDialog.FileName);
			}
		}




	}
}
