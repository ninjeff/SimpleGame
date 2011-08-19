using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame.Models
{
	public enum ItemType { None, Weapon, Armour, Consumable }

	[Serializable]
	public class Item : ISerializable
	{

		protected string name;
		protected int weight;
		protected int value;
		protected int id;
		protected System.Drawing.Image picture;
		protected ItemType type;

		public Item(int itemid, string name, int weight, int value, ItemType type)
		{
			this.id = itemid;
			this.name = name;
			this.weight = weight;
			this.value = value;
			this.type = type;
		}

		public Item(SerializationInfo info, StreamingContext ctxt)
		{
			this.id = (int)info.GetValue("id", typeof(int));
			this.name = (string)info.GetValue("name", typeof(string));
			this.value = (int)info.GetValue("value", typeof(int));
			this.weight = (int)info.GetValue("weight", typeof(int));
			this.type = (ItemType)info.GetValue("type", typeof(int));
			this.picture = (System.Drawing.Image)info.GetValue("picture", typeof(System.Drawing.Image));
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("id", this.id);
			info.AddValue("name", this.name);
			info.AddValue("value", this.value);
			info.AddValue("weight", this.weight);
			info.AddValue("type", (int)this.type);
			info.AddValue("picture", this.picture);
		}

		public Item()
		{
		}

		public int ID
		{
			get { return id; }
		}

		public string UsageVerb
		{
			get
			{
				switch (this.type)
				{
					case ItemType.Weapon:
						return "wield";
					case ItemType.Armour:
						return "wear";
					default:
						return "use";
				}
			}
		}

		public virtual string Name
		{
			get { return name; }
		}

		public int Weight
		{
			get { return weight; }
		}

		public int Value
		{
			get { return value; }
		}

		public ItemType Type
		{
			get { return type; }
		}

		public System.Drawing.Image Picture
		{
			get { return picture; }
		}
	}
}
