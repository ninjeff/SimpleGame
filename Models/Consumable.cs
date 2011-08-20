using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame.Models
{
	public enum ConsumableType { HealthPotion, StrengthPotion, SpeedPotion, None };

	[Serializable]
	public class Consumable : Item, ISerializable
	{
		private int count;
		private ConsumableType consumabletype;
		private int effectiveness;

		public Consumable(int itemid, string name, int weight, int value, ItemType type, System.Drawing.Image picture, ConsumableType consumabletype, int effectiveness, int count)
			: base(itemid, name, weight, value, type)
		{
			this.picture = picture;
			this.consumabletype = consumabletype;
			this.effectiveness = effectiveness;
			this.count = count;
		}

		public Consumable(SerializationInfo info, StreamingContext ctxt)
			: base(info, ctxt)
		{
			this.consumabletype = (ConsumableType)info.GetValue("consumabletype", typeof(int));
			this.effectiveness = (int)info.GetValue("effectiveness", typeof(int));
			this.count = (int)info.GetValue("count", typeof(int));
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			base.GetObjectData(info, ctxt);

			info.AddValue("consumabletype", (int)this.consumabletype);
			info.AddValue("effectiveness", this.effectiveness);
			info.AddValue("count", this.count);
		}

		public int Count
		{
			get { return count; }
			set { count = value; }
		}

		public ConsumableType ConsumableType
		{
			get { return consumabletype; }
		}

		public int Effectiveness
		{
			get { return effectiveness; }
		}

		public override string Name
		{
			get
			{
				if (count == 1)
				{
					return name;
				}
				else
				{
					return name + " x" + count.ToString();
				}
			}
		}

	}
}
