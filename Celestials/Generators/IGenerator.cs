using System.Collections.Generic;

namespace Celestials.Generators
{
	public interface IGenerator<T>
	{
		IList<T> Generate(int qty);
	}
}