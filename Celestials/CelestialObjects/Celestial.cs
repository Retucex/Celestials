using System;
using System.Collections.Generic;
using System.Text;
using Celestials.Generators;
using MathNet.Numerics.LinearAlgebra;

namespace Celestials
{
	public abstract class Celestial
	{
		public Celestial Parent { get; set; }
		public List<Celestial> Children { get; set; } = new List<Celestial>();
		public Vector<double> Position { get; set; } = VectorMatrix.VBuilder.Dense(3);
		public Vector<double> Velocity { get; set; } = VectorMatrix.VBuilder.Dense(3);
		public double Mass { get; set; }
		public double Radius { get; set; }
		public double Temperature { get; set; }
		public List<Tuple<Compound, double>> Composition { get; set; } = new List<Tuple<Compound, double>>();
		public double Volume => (4.0 / 3.0) * System.Math.PI * System.Math.Pow(Radius, 3);
		public double Density => Mass / Volume;

		public Celestial(Celestial parent = null,
						List<Celestial> children = null,
						Vector<double> position = null,
						Vector<double> velocity = null,
						double mass = 0.0,
						double radius = 0.0,
						double temperature = 0.0,
						List<Tuple<Compound, double>> composition = null)
		{
			Parent = parent;
			Children = children == null ? Children : children;
			Position = position == null ? Position : position;
			Velocity = velocity == null ? Velocity : velocity;
			Mass = mass;
			Radius = radius;
			Temperature = temperature;
			Composition = composition == null ? Composition : composition;
		}
	}
}