using System;
using System.Dynamic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Celestials.Generators
{
	public class CelestialRulesParser<T> : IRulesParser<T> where T : Celestial
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private string JSONFilename => $"{typeof(T).Name}.json";

		public dynamic ParseRules()
		{
			try
			{
				logger.Trace("Parsing file {0}", JSONFilename);
				var rulesFile = File.ReadAllText($"Generators/Rules/{JSONFilename}");
				dynamic rules = JObject.Parse(rulesFile);

				dynamic parsedRules = new ExpandoObject();
				foreach (var attrib in rules)
				{
					switch (attrib.Name)
					{
						case "Parent":
							break;

						case "Children":
							break;

						case "Position":
							break;

						case "Velocity":
							break;

						case "Mass":
							break;

						case "Radius":
							break;

						case "Influence":
							break;

						case "Temperature":
							break;

						case "Composition":
							break;

						default:
							logger.Warn("Unrecognized rule: {0}\nValue: {1}", attrib.Name, attrib.Value);
							break;
					}
				}

				return parsedRules;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}
	}
}