using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public static class ItemGenerator
	{
		public static DGetItem<Item> GetItem(DGetItemStat getStat, IDictionary<string, DGetItem<Item>> getItemDictionary, DGetItem<Item> getDefaultItem)
		{
			return itemid =>
			{
				var type = getStat(itemid, "type");
				DGetItem<Item> getItem;
				if (getItemDictionary.TryGetValue(type, out getItem))
				{
					return getItem(itemid);
				}
				else
				{
					return getDefaultItem(itemid);
				}
			};
		}

		public static DGetItem<Armour> GetArmour(DGetItemStat getStat, System.Drawing.Image armour_image)
		{
			return itemid =>
			{
				var name = getStat(itemid, "name");
				var weight = int.Parse(getStat(itemid, "weight"));
				var value = int.Parse(getStat(itemid, "value"));
				var type = ItemType.Armour;
				var protection = int.Parse(getStat(itemid, "protection"));
				var picture = armour_image;

				return new Armour(itemid, name, weight, value, type, protection, picture);
			};
		}

		public static DGetItem<Consumable> GetConsumable(DGetItemStat getStat, System.Drawing.Image potion_image)
		{
			Func<int, ConsumableType> setConsumableType = itemid =>
			{
				switch (getStat(itemid, "consumabletype"))
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
			};

			return itemid =>
			{
				var name = getStat(itemid, "name");
				var weight = int.Parse(getStat(itemid, "weight"));
				var value = int.Parse(getStat(itemid, "value"));
				var type = ItemType.Consumable;
				var picture = potion_image;
				var consumabletype = setConsumableType(itemid);
				var effectiveness = int.Parse(getStat(itemid, "effectiveness"));
				var count = 1;

				return new Consumable(itemid, name, weight, value, type, picture, consumabletype, effectiveness, count);
			};
		}

		public static DGetItem<Item> GetDefaultItem(DGetItemStat getStat)
		{
			return itemid =>
			{
				var name = getStat(itemid, "name");
				var weight = int.Parse(getStat(itemid, "weight"));
				var value = int.Parse(getStat(itemid, "value"));
				var type = ItemType.None;

				return new Item(itemid, name, weight, value, type);
			};
		}

		public static DGetItem<Weapon> GetWeapon(DGetItemStat getStat, System.Drawing.Image weapon_image)
		{
			return itemid =>
			{
				var name = getStat(itemid, "name");
				var weight = int.Parse(getStat(itemid, "weight"));
				var value = int.Parse(getStat(itemid, "value"));
				var type = ItemType.Weapon;
				var damage = int.Parse(getStat(itemid, "damage"));
				var picture = weapon_image;

				return new Weapon(itemid, name, weight, value, type, damage, picture);
			};
		}
	}
}
