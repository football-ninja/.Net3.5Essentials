﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//No namespace to be accessible anywhere.


public static class EnumExtensions
{
	//.Net 3.5 version of the .Net 4.0 HasFlag http://stackoverflow.com/questions/4108828/generic-extension-method-to-see-if-an-enum-contains-a-flag
	/// <summary>
	/// Check to see if a flags enumeration has a specific flag set.
	/// </summary>
	/// <param name="variable">Flags enumeration to check</param>
	/// <param name="value">Flag to check for</param>
	/// <returns>Indicates if the flag is set.</returns>
	public static bool HasFlag(this Enum variable, Enum value)
	{
		if (variable == null)
			return false;

		if (value == null)
			throw new ArgumentNullException("value");

		// Not as good as the .NET 4 version of this function, but should be good enough
		if (!Enum.IsDefined(variable.GetType(), value))
		{
			throw new ArgumentException(string.Format(
				"Enumeration type mismatch.  The flag is of type '{0}', was expecting '{1}'.",
				value.GetType(), variable.GetType()));
		}

		ulong num = Convert.ToUInt64(value);
		return ((Convert.ToUInt64(variable) & num) == num);
	}
}
