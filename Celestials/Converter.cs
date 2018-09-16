using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Celestials
{
	public static class Converter
	{
		public static T GetTfromString<T>(string mystring)
		{
			var foo = TypeDescriptor.GetConverter(typeof(T));
			return (T)(foo.ConvertFromInvariantString(mystring));
		}
	}
}