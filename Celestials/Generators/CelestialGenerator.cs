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
				//TODO Use reflection to assign properties. https://stackoverflow.com/questions/1089123/setting-a-property-by-reflection-with-a-string-value
				//Should be able to do without class-specific generation method ie. remove OnGeneration() call. Deal with that in json

				var celestial = new T();

				celestial.Parent = parent;

				celestial.Mass = Math.Random.GeneratePositiveGaussian((double)rules.Mass.Mean, (double)rules.Mass.StdDev);
				celestial.Radius = Math.Random.GeneratePositiveGaussian((double)rules.Radius.Mean, (double)rules.Radius.StdDev);
				celestial.Influence = Math.Random.GeneratePositiveGaussian((double)rules.Influence.Mean, (double)rules.Influence.StdDev);
				celestial.Temperature = Math.Random.GeneratePositiveGaussian((double)rules.Temperature.Mean, (double)rules.Temperature.StdDev);

				foreach (var compound in rules.Composition)
				{
					string type = compound.Compound;
					var concentration = Math.Random.GeneratePositiveGaussian((double)rules.Temperature.Mean, (double)rules.Temperature.StdDev);
					celestial.Composition.Add(new Tuple<Compound, double>(new Compound() { Name = type }, concentration));
				}

				celestial.OnGeneration();
				celestial.SetIdentifier();

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