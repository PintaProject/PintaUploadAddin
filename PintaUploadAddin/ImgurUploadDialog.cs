using System;
namespace PintaUploadAddin
{
	public partial class ImgurUploadDialog : Gtk.Dialog
	{
		ImgurUploadType parent;
		
		public ImgurUploadDialog (ImgurUploadType parent)
		{
			this.parent = parent;
			this.Build ();
			
			buttonOk.Clicked += delegate(object sender, EventArgs e) {
				this.Destroy ();
			};
			
			progressTextView.Editable = false;
			progressTextView.Buffer.Insert (progressTextView.Buffer.EndIter, "Starting upload...\n");
			parent.StartUpload (progressTextView.Buffer);
			
		}
	}
}

