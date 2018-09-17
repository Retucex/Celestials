using Celestials.Generators;

namespace Celestials.Tester
{
	internal class Program
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private static void Main(string[] args)
		{
			HelperLib.Log.InitializeNLogConfig();

			logger.Trace("Program Start");
			HelperLib.Math.Random.SetSeed(5432);

			//TODO find a better way to handle first generation. This ugly
			var galaxyGen = new CelestialGenerator<Galaxy>(new CelestialRulesParser<Galaxy>(), null);
			var galaxy = galaxyGen.Generate(1)[0] as Galaxy;

			logger.Trace("Program End");
		}
	}
}