using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleGame.Models
{
	public class Game
	{
		private readonly DGetItem<Item> getItem;

		public Game(DGetItem<Item> itemGenerator)
		{
			this.getItem = itemGenerator;
		}

		public bool GameInProgress = false;

		public Player StartGame(string name)
		{
			List<Item> inventory = new List<Item>();
			inventory.Add(getItem(7));
			Weapon weapon = (Weapon)getItem(-1);
			Armour armour = (Armour)getItem(-2);
			WarriorStats playerStats = new WarriorStats() { Accuracy = 80, MaxHp = 10, Hp = 10, Level = 1, Strength = 3, Speed = 7 };
			Player player = new Player(name, playerStats, inventory, weapon, armour) { Gold = 1001 };
			GameInProgress = true;
			return player;
		}

		public string RandomName()
		{
			return new string[] { "Bob", "Fred", "Jane", "Hrothgar", "Tim" }.GetRandomElement();
		}

		public void SaveGame(Player player, string path)
		{
			using (Stream stream = File.Open(path, FileMode.Create))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, player);
			}
		}

		public Player LoadGame(string path)
		{
			using (Stream stream = File.Open(path, FileMode.Open))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				Player player = (Player)formatter.Deserialize(stream);
				return player;
			}
		}
	}
}
