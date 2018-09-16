using System;
using System.Collections.Generic;
using Celestials.Generators;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Celestials.Tester
{
	internal class Program
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private static void Main(string[] args)
		{
			logger.Trace("Program Start");
			Celestials.Math.Random.SetSeed(5432);

			var galaxyGen = new CelestialGenerator<Galaxy>(new CelestialRulesParser<Galaxy>(), null);
			var galaxy = galaxyGen.Generate(1)[0] as Galaxy;

			logger.Trace("Program End");
		}
	}
}