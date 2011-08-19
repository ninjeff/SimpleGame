using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SimpleGame.Models
{
	public static class XmlStatParser
	{
		public static string GetStat(int entityid, string stat, string statsfile)
		{
			using (var entitystats = new System.IO.StringReader(statsfile))
			using (var xmlReader = XmlReader.Create(entitystats))
			{
				return GetStatFromXml(entityid, stat, xmlReader);
			}
		}

		private static string GetStatFromXml(int entityid, string stat, XmlReader xmlReader)
		{
			string idtag = "id" + entityid.ToString();
			while (xmlReader.Read())
			{
				if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == idtag)
				{
					if (xmlReader.HasAttributes)
					{
						return xmlReader.GetAttribute(stat);
					}
				}
			}
			return "0";
		}

		public static bool IDExists(int entityid, string statsfile)
		{
			using (var entitystats = new System.IO.StringReader(statsfile))
			using (var xmlReader = XmlReader.Create(entitystats))
			{
				return GetEntityExists(entityid, xmlReader);
			}
		}

		private static bool GetEntityExists(int entityid, XmlReader xmlReader)
		{
			string idtag = "id" + entityid.ToString();
			while (xmlReader.Read())
			{
				if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == idtag)
				{
					return true;
				}
			}
			return false;
		}
	}
}