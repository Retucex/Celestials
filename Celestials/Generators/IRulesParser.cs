using System;
using System.Collections.Generic;
using System.Text;

namespace Celestials.Generators
{
	public interface IRulesParser<T>
	{
		dynamic ParseRules();
	}
}