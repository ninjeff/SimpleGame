using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public class ItemGenerator
	{
		private readonly ItemStats itemStats;
		private readonly System.Drawing.Image armour_image;
		private readonly System.Drawing.Image potion_image;
		private readonly System.Drawing.Image weapon_image;

		public ItemGenerator(ItemStats itemStats, System.Drawing.Image armour_image, System.Drawing.Image potion_image, System.Drawing.Image weapon_image)
		{
			this.itemStats = itemStats;
			this.armour_image = armour_image;
			this.potion_image = potion_image;
			this.weapon_image = weapon_image;
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
			var picture = armour_image;

			return new Armour(itemid, name, weight, value, type, protection, picture);
		}

		private Consumable GetConsumable(int itemid)
		{
			var name = itemStats.GetStat(itemid, "name");
			var weight = int.Parse(itemStats.GetStat(itemid, "weight"));
			var value = int.Parse(itemStats.GetStat(itemid, "value"));
			var type = this.setItemType(itemid);
			var picture = potion_image;
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
			var picture = weapon_image;

			return new Weapon(itemid, name, weight, value, type, damage, picture);
		}

		private ConsumableType setConsumableType(int itemid)
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

		private ItemType setItemType(int itemid)
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
