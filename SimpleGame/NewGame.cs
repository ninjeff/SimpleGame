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
	public partial class NewGame : Form
	{
		private readonly Game game;

		public NewGame(Game game)
		{
			InitializeComponent();
			this.game = game;
			CharacterNameInput.Text = game.RandomName();
		}

		public string CharacterNameTextBox()
		{
			return CharacterNameInput.Text;
		}

		private void StartGameButton_Click(object sender, EventArgs e)
		{
			if (CharacterNameInput.Text != "")
			{
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				CharacterNameInput.Text = game.RandomName();
			}
		}

		private void CancelStartGameButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
