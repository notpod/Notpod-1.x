/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 10.06.2012
 * Time: 13:08
 * 
 */
using System;
using iTunesLib;

namespace Notpod
{
	/// <summary>
	/// Description of DefaultITunesAppFactory.
	/// </summary>
	public class DefaultITunesAppFactory : ITunesAppFactory
	{
				
		public iTunesLib.iTunesApp GetNewInstance()
		{
			return new iTunesAppClass();
		}
	}
}
