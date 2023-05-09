﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomi.Infrastructure.Settings
{
	public class JwtSettings
	{
		public string Secret { get; set; }
		public double ExpirationHours { get; set; }

		public string Audience { get; set; }

		public string Issuer { get; set; }

	}
}
