using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Models
{
	public delegate T DGetItem<out T>(int itemid) where T : Item;
	public delegate string DGetItemStat(int itemid, string stat);
	public delegate string DGetMonsterStat(int monsterid, string stat);
	public delegate string DGetStat(int entityid, string stat, string statsfile);
	public delegate bool DIdExists(int entityid, string statsfile);
	public delegate bool DMonsterExists(int monsterid);
}
