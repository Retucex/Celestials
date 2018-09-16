using System;
using System.Collections.Generic;
using System.Text;

namespace Celestials.Generators
{
	public interface IGenerator<T>
	{
		IList<T> Generate(int qty);
	}
}