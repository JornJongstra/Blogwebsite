using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsiteCore
{
	public static class ServiceHandler
	{
		internal static IDAL Service { get; set; } = null!;

		public static void SetService(IDAL service) => Service = service;
	}
}
