using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PethanyApplication.Models
{
	public interface IPieRepository
	{
		IEnumerable<Pie> AllPies();
		IEnumerable<Pie> PiesOfTheWeek();
		Pie GetPieById(int pieId);
	}
}
