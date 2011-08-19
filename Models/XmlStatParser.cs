using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public static class XmlStatParser
	{
		public static DGetStat GetStat()
		{
			return (entityid, stat, statsfile) =>
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
			};
		}

		public static DIdExists IDExists()
		{
			return (entityid, statsfile) =>
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
			};
		}
	}
}