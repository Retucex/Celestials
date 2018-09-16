namespace Celestials.Math
{
	public static class Random
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		private static System.Random rand = new System.Random();

		public static double Next() => 1.0 - rand.NextDouble();

		public static void SetSeed(int seed)
		{
			logger.Trace("Set Random Engine seed: {0}", seed);
			rand = new System.Random(seed);
		}

		public static double GenerateGaussian(double mean, double stdDev)
		{
			return _GenerateGaussian(mean, stdDev);
		}

		public static double GeneratePositiveGaussian(double mean, double stdDev)
		{
			double pos;
			do
			{
				pos = _GenerateGaussian(mean, stdDev);
			} while (pos < 0);

			return pos;
		}

		private static double _GenerateGaussian(double mean, double stdDev)
		{
			double u1 = Next(); //uniform(0,1] random doubles
			double u2 = Next();
			double randStdNormal = System.Math.Sqrt(-2.0 * System.Math.Log(u1)) *
									System.Math.Sin(2.0 * System.Math.PI * u2); //random normal(0,1)
			double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

			return randNormal;
		}
	}
}