using System;
using System.Collections.Generic;
using System.Reflection;

namespace Celestials.Generators
{
	public class CelestialGenerator<T> : IGenerator<T> where T : Celestial, new()
	{
		private static Assembly asm = typeof(CelestialGenerator<>).Assembly;
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		private dynamic rules;
		private Celestial parent;

		public CelestialGenerator(CelestialRulesParser<T> celestialRulesParser, Celestial parent)
		{
			rules = celestialRulesParser.ParseRules();
			this.parent = parent;
		}

		public IList<T> Generate(int qty)
		{
			try
			{
				logger.Trace("Generating {0} {1} with parent {2}", qty, typeof(T).Name, parent);

				var celestials = new List<T>();
				for (int i = 0; i < qty; i++)
				{
					var celestial = CreateCelestial();
					celestials.Add(celestial);
				}
				return celestials;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}

		private T CreateCelestial()
		{
			try
			{
				var celestial = new T();

				celestial.Parent = parent;

				foreach (var child in rules.Children)
				{
					var qty = Math.Random.GeneratePositiveGaussian((double)child.Mean, (double)child.StdDev);

					var childType = asm.GetType("Celestials." + child.Type);
					var genType = typeof(CelestialGenerator<>).MakeGenericType(childType);
					var ruleParserType = typeof(CelestialRulesParser<>).MakeGenericType(childType);

					var ruleParser = Activator.CreateInstance(ruleParserType);
					var gen = Activator.CreateInstance(genType, ruleParser, celestial);

					celestial.Children.AddRange(gen.Generate((int)qty));
				}

				return celestial;
			}
			catch (Exception ex)
			{
				logger.Error(ex);
				return null;
			}
		}
	}
}