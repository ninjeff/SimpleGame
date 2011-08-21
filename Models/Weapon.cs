using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame.Models
{
	[Serializable]
	public class Weapon : Item, ISerializable
	{
		private int damage;

		public Weapon(int itemid, string name, int weight, int value, int speed, ItemType type, int damage, System.Drawing.Image picture)
			: base(itemid, name, weight, value, speed, type)
		{
			this.damage = damage;
			this.picture = picture;
		}

		public Weapon(SerializationInfo info, StreamingContext ctxt)
			: base(info, ctxt)
		{
			this.damage = (int)info.GetValue("damage", typeof(int));
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue("damage", this.damage);
		}

		public int Damage
		{
			get { return damage; }
		}
	}
}
