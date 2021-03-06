﻿using System;
using static HelperLib.Types.EnumHelper;

namespace Celestials
{
	public class Star : Celestial
	{
		public StellarClass StellarClass { get; set; } = new StellarClass();

		public Star()
		{
			//TODO remove logic from constructor. Add to json. Or calculate dynamically based on mass and stuff

			var specIntensity = HelperLib.Math.Random.NextInt(1, 9);

			StellarClass.LumClass = (StellarClass.LuminosityClass)StellarClass.LumClass.GetRandom();
			StellarClass.SpecType = (StellarClass.SpectralType)StellarClass.SpecType.GetRandom();
			StellarClass.SpecIntensity = specIntensity;
		}

		public override void OnGeneration()
		{
		}

		public override void SetIdentifier()
		{
			Identifier = $"{StellarClass}-{(int)(HelperLib.Math.Random.Next() * 1000)}";
		}
	}
}