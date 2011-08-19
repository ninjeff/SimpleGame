using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame
{
	[Serializable]
	public class Player : ISerializable, IWarrior
	{
		private Stats stats;
		private Weapon equippedweapon;
		private Armour equippedarmour;

		private List<Item> inventory = new List<Item>();

		public Player(string name, Stats stats, List<Item> inventory, Weapon weapon, Armour armour)
		{
			this.Name = name;
			this.stats = stats;
			this.inventory = inventory;
			this.equippedweapon = weapon;
			this.equippedarmour = armour;
		}

		public Player(SerializationInfo info, StreamingContext ctxt)
		{
			this.stats = (Stats)info.GetValue("stats", typeof(Stats));
			this.inventory = (List<Item>)info.GetValue("inventory", typeof(List<Item>));
			this.equippedweapon = (Weapon)info.GetValue("weapon", typeof(Weapon));
			this.equippedarmour = (Armour)info.GetValue("armour", typeof(Armour));

			this.Name = (string)info.GetValue("Name", typeof(string));
			this.XP = (int)info.GetValue("XP", typeof(int));
			this.Gold = (int)info.GetValue("Gold", typeof(int));
		}

		public Player()
		{
		}

		public string Name { get; private set; }

		public int Gold { get; set; }

		private int xp;
		public int XP
		{
			get { return xp; }
			set
			{
				xp = value;
				while (this.XP >= this.NextLevel)
				{
					levelup();
				}
			}
		}

		public int MaxHP { get { return stats.MaxHp; } }

		public bool PlayerHasItem(int itemid)
		{
			foreach (Item item in inventory)
			{
				if (item.ID == itemid)
				{
					return true;
				}
			}
			return false;
		}

		public void EquipWeapon(Weapon weapon)
		{
			equippedweapon = weapon;
		}

		public void EquipArmour(Armour armour)
		{
			equippedarmour = armour;
		}

		public Weapon EquippedWeapon
		{
			get { return equippedweapon; }
		}

		public Armour EquippedArmour
		{
			get { return equippedarmour; }
		}

		public int ArmourProtection
		{
			get { return Randomness.RandomNumber(this.equippedarmour.Protection); }
		}

		public List<Item> Inventory
		{
			get { return inventory; }
		}

		public int Level
		{
			get { return stats.Level; }
		}

		public int NextLevel
		{
			get { return 100 * (1 << (stats.Level - 1)); }
		}


		public string XPText
		{
			get { return String.Format("{0}/{1}", this.XP, this.NextLevel); }
		}

		public bool Alive
		{
			get { return stats.Alive; }
		}

		public int Damage
		{
			get { return stats.Strength + this.EquippedWeapon.Damage + this.TemporaryDamageBonus; }
		}

		public int HP
		{
			get { return stats.Hp; }
			set { stats.Hp = value; }
		}

		public int Speed
		{
			get { return stats.Speed; }
		}

		public int TemporaryDamageBonus { get; set; }

		public bool Hit()
		{
			return stats.Hit();
		}

		private void levelup()
		{
			stats.Level++;
			stats.MaxHp += stats.Level * 5;
		}

		public void Resurrect(int cost)
		{
			stats.Hp = stats.MaxHp;
			this.Gold = Math.Max(this.Gold - cost, 0);
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("stats", this.stats);
			info.AddValue("inventory", this.inventory);
			info.AddValue("weapon", this.equippedweapon);
			info.AddValue("armour", this.equippedarmour);

			info.AddValue("Name", this.Name);
			info.AddValue("XP", this.XP);
			info.AddValue("Gold", this.Gold);
		}
	}
}
