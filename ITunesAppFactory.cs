/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 10.06.2012
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using iTunesLib;

namespace Notpod
{
	/// <summary>
	/// Description of ITunesAppFactory.
	/// </summary>
	public interface ITunesAppFactory
	{	
		iTunesApp GetNewInstance();
	}
}
