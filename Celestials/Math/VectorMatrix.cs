using MathNet.Numerics.LinearAlgebra;

namespace Celestials
{
	public static class VectorMatrix
	{
		public static VectorBuilder<double> VBuilder = Vector<double>.Build;
		public static MatrixBuilder<double> MBuilder = Matrix<double>.Build;
	}
}