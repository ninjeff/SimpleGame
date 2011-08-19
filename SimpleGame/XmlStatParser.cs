using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public class XmlStatParser : IStatParser
	{
		public string GetStat(int entityid, string stat, string statsfile)
		{
			using (var entitystats = new System.IO.StringReader(statsfile))
			using (var xmlReader = System.Xml.XmlReader.Create(entitystats))
			{
				string idtag = "id" + entityid.ToString();
				while (xmlReader.Read())
				{
					if (xmlReader.NodeType == System.Xml.XmlNodeType.Element && xmlReader.Name == idtag)
					{
						if (xmlReader.HasAttributes)
						{
							return xmlReader.GetAttribute(stat);
						}
					}
				}
				return "0";
			}
		}

		public bool IDExists(int entityid, string statsfile)
		{
			using (var entitystats = new System.IO.StringReader(statsfile))
			using (var xmlReader = System.Xml.XmlReader.Create(entitystats))
			{
				string idtag = "id" + entityid.ToString();
				while (xmlReader.Read())
				{
					if (xmlReader.NodeType == System.Xml.XmlNodeType.Element && xmlReader.Name == idtag)
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
