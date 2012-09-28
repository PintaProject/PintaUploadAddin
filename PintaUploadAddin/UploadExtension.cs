// 
// UploadExtension.cs
//  
// Author:
//       Robert Nordan <rpvn@robpvn.net>
// 
// Copyright (c) 2012 Robert Nordan
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Pinta.Core;
using Gtk;

namespace PintaUploadAddin
{
	[Mono.Addins.Extension]
	public class UploadExtension :IExtension
	{
		Gtk.Action menu_action;
		Widget menu_item;
		
		public UploadExtension ()
		{
			menu_action = new Gtk.Action ("uploadaddin", "Upload", "Lets you upload images to the internet", Stock.Network);
			menu_action.Activated += delegate (object sender, EventArgs e) {showUploadDialog (); };
			menu_item = menu_action.CreateMenuItem ();
		}
		
		#region IExtension Members
		public void Initialize ()
		{
			Console.WriteLine ("Initialising upload extension");
			PintaCore.Actions.Addins.AddMenuItem (menu_item);
		}

		public void Uninitialize ()
		{
			Console.WriteLine ("Deinitialising upload extension");
			PintaCore.Actions.Addins.RemoveMenuItem (menu_item);
		}
		#endregion
		
		public void showUploadDialog ()
		{
			Gtk.Dialog  chooser = new UploadTypeChooserDialog ();
			chooser.Show ();
		}
		
	}
}

