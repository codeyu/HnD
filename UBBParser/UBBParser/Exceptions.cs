/*
	This file is part of HnD.
	HnD is (c) 2002-2006 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;

namespace SD.HnD.UBBParser
{
	/// <summary>
	/// Exception which is thrown when the Tokenize process is started without any Token definitions present
	/// </summary>
	public class NoTokenDefinitionsSpecifiedException : ApplicationException
	{
		/// <summary>
		/// Creates a new <see cref="NoTokenDefinitionsSpecifiedException"/> instance.
		/// </summary>
		/// <param name="sMessage">S message.</param>
		public NoTokenDefinitionsSpecifiedException(string sMessage): base(sMessage)
		{
		}
	}
}