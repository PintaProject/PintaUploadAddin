using System;
namespace PintaUploadAddin
{
	public interface IUploadType
	{
		string Name {get;}
		
		string Description {get;}
		
		Gtk.Dialog UploadWindow {get;}
	}
}

