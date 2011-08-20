using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame.Models
{
	[Serializable]
	public class Armour : Item, ISerializable
	{
		private int protection;

		public Armour(SerializationInfo info, StreamingContext ctxt)
			: base(info, ctxt)
		{
			this.protection = (int)info.GetValue("protection", typeof(int));
		}

		public Armour(int itemid, string name, int weight, int value, ItemType type, int protection, System.Drawing.Image picture)
			: base(itemid, name, weight, value, type)
		{
			this.protection = protection;
			this.picture = picture;
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);
			info.AddValue("protection", this.protection);
		}

		public int Protection
		{
			get { return protection; }
		}
	}
}