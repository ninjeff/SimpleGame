using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public interface IStatParser
	{
		string GetStat(int entityid, string stat, string statsfile);
		bool IDExists(int entityid, string statsfile);
	}
}
