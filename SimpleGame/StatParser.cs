using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public abstract class StatParser
	{
		private static StatParser current = new XmlStatParser();
		public static StatParser Current
		{
			get { return current; }
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				current = value;
			}
		}

		public abstract string GetStat(int entityid, string stat, string statsfile);
		public abstract bool IDExists(int entityid, string statsfile);
	}
}