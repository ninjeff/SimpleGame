using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class ItemGenerator
	{
		private readonly ItemStats itemStats;

		public ItemGenerator(ItemStats itemStats)
		{
			this.itemStats = itemStats;
		}

		public Item CreateItem(int itemid)
		{
			switch (itemStats.GetStat(itemid, "type"))
			{
				case "weapon":
					return this.GetWeapon(itemid);
				case "armour":
					return this.GetArmour(itemid);
				case "consumable":
					return this.GetConsumable(itemid);
				default:
					return this.GetItem(itemid);
			}
		}

		private Armour GetArmour(int itemid)
		{
			var name = itemStats.GetStat(itemid, "name");
			var weight = int.Parse(itemStats.GetStat(itemid, "weight"));
			var value = int.Parse(itemStats.GetStat(itemid, "value"));
			var type = this.setItemType(itemid);
			var protection = int.Parse(itemStats.GetStat(itemid, "protection"));
			var picture = SimpleGame.Properties.Resources.armour_image;

			return new Armour(itemid, name, weight, value, type, protection, picture);
		}

		private Consumable GetConsumable(int itemid)
		{
			var name = itemStats.GetStat(itemid, "name");
			var weight = int.Parse(itemStats.GetStat(itemid, "weight"));
			var value = int.Parse(itemStats.GetStat(itemid, "value"));
			var type = this.setItemType(itemid);
			var picture = SimpleGame.Properties.Resources.potion_image;
			var consumabletype = this.setConsumableType(itemid);
			var effectiveness = int.Parse(itemStats.GetStat(itemid, "effectiveness"));
			var count = 1;

			return new Consumable(itemid, name, weight, value, type, picture, consumabletype, effectiveness, count);
		}

		private Item GetItem(int itemid)
		{
			var name = itemStats.GetStat(itemid, "name");
			var weight = int.Parse(itemStats.GetStat(itemid, "weight"));
			var value = int.Parse(itemStats.GetStat(itemid, "value"));
			var type = this.setItemType(itemid);

			return new Item(itemid, name, weight, value, type);
		}

		private Weapon GetWeapon(int itemid)
		{
			var name = itemStats.GetStat(itemid, "name");
			var weight = int.Parse(itemStats.GetStat(itemid, "weight"));
			var value = int.Parse(itemStats.GetStat(itemid, "value"));
			var type = this.setItemType(itemid);
			var damage = int.Parse(itemStats.GetStat(itemid, "damage"));
			var picture = SimpleGame.Properties.Resources.weapon_image;

			return new Weapon(itemid, name, weight, value, type, damage, picture);
		}

		public  ConsumableType setConsumableType(int itemid)
		{
			switch (itemStats.GetStat(itemid, "consumabletype"))
			{
				case "HealthPotion":
					return ConsumableType.HealthPotion;
				case "StrengthPotion":
					return ConsumableType.StrengthPotion;
				case "SpeedPotion":
					return ConsumableType.SpeedPotion;
				default:
					return ConsumableType.None;
			}
		}

		public  ItemType setItemType(int itemid)
		{
			switch (itemStats.GetStat(itemid, "type"))
			{
				case "weapon":
					return ItemType.Weapon;
				case "armour":
					return ItemType.Armour;
				case "consumable":
					return ItemType.Consumable;
				default:
					return ItemType.None;
			}
		}
	}
}
