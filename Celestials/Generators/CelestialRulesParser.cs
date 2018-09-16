using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Celestials.Generators
{
	public class CelestialRulesParser<T> : IRulesParser<T> where T : Celestial
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private string JSONFilename => $"Rules/{typeof(T).Name}.json";

		public dynamic ParseRules()
		{
			try
			{
				logger.Trace("Parsing file {0}", JSONFilename);
				var rulesFile = File.ReadAllText($"Generators/{JSONFilename}");
				dynamic rules = JObject.Parse(rulesFile);

				return rules;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}
	}
}