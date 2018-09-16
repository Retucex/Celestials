using System;

namespace Celestials
{
	public class StellarClass
	{
		private int specIntensity;

		public enum LuminosityClass
		{
			Iap,
			Ia,
			Iab,
			Ib,
			II,
			III,
			IV,
			V,
			VI,
			VII
		}

		public enum SpectralType
		{
			O,
			B,
			A,
			F,
			G,
			K,
			M,
			L,
			T,
			Y
		}

		public LuminosityClass LumClass { get; set; }

		public int SpecIntensity
		{
			get => specIntensity;
			set
			{
				if (value > 0 && value < 10)
				{
					specIntensity = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("SpecIntensity", "Value has to be between 1 and 9 inclusively");
				}
			}
		}

		public SpectralType SpecType { get; set; }

		public static StellarClass FromString(string stellarClass)
		{
			var stellar = new StellarClass();

			if (SpectralType.TryParse(stellarClass[0].ToString(), true, out SpectralType type))
			{
				stellar.SpecType = type;
			}
			else
			{
				throw new ArgumentException("Unable to parse SpectralType", "stellarClass");
			}

			if (int.TryParse(stellarClass[1].ToString(), out int intensity))
			{
				stellar.SpecIntensity = intensity;
			}
			else
			{
				throw new ArgumentException("Unable to parse SpectralIntensity", "stellarClass");
			}

			if (LuminosityClass.TryParse(stellarClass.Substring(2), true, out LuminosityClass luminosity))
			{
				stellar.LumClass = luminosity;
			}
			else
			{
				throw new ArgumentException("Unable to parse LuminosityClass", "stellarClass");
			}

			return stellar;
		}

		public override string ToString()
		{
			return $"{SpecType}{SpecIntensity}{LumClass}";
		}
	}
}