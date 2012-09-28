using System;
namespace PintaUploadAddin
{
	public partial class UploadTypeChooserDialog : Gtk.Dialog
	{
		public UploadTypeChooserDialog ()
		{
			this.Build ();
			
			buttonOk.Clicked += delegate(object sender, EventArgs e) {
				//TODO: Actually check different types of uploaders when we have more than one.
				new ImgurUploadDialog (new ImgurUploadType ()).Show ();
				this.Destroy ();
			};
			
			buttonCancel.Clicked += delegate(object sender, EventArgs e) {
				this.Destroy ();
			};
			
		}
	}
}

