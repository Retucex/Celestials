using System;

namespace Celestials
{
	public class Star : Celestial
	{
		public StellarClass StellarClass { get; set; } = new StellarClass();

		public Star()
		{
			//TODO remove logic from constructor. Add to json. Or calculate dynamically based on mass and stuff
			var lumClasses = Enum.GetValues(typeof(StellarClass.LuminosityClass));
			var lumClass = (StellarClass.LuminosityClass)lumClasses.GetValue(Math.Random.NextInt(lumClasses.Length));

			var specTypes = Enum.GetValues(typeof(StellarClass.SpectralType));
			var specType = (StellarClass.SpectralType)specTypes.GetValue(Math.Random.NextInt(specTypes.Length));

			var specIntensity = Math.Random.NextInt(1, 9);

			StellarClass.LumClass = lumClass;
			StellarClass.SpecType = specType;
			StellarClass.SpecIntensity = specIntensity;
		}

		public override void OnGeneration()
		{
		}

		public override void SetIdentifier()
		{
			Identifier = $"{StellarClass}-{(int)(Math.Random.Next() * 1000)}";
		}
	}
}