using System;
using System.IO;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Pinta.Core;

namespace PintaUploadAddin
{

	public class ImgurUploadType : IUploadType
	{
		public string Name { get {return "Imgur";} }
		
		public string Description { get {return "Uploads to the Imgur anonymous API";} }
		
		public Gtk.Dialog UploadWindow { get {return new ImgurUploadDialog (this);}}
		
		public void StartUpload (Gtk.TextBuffer updateWindow) 
		{
			//Create a temp file
			updateWindow.Insert (updateWindow.EndIter, "Saving file.\n");
			PintaCore.Workspace.ActiveDocument.Save (false);
			
			//Using Imgur API key
			updateWindow.Insert (updateWindow.EndIter, "Uploading file.\n");
			string result = PostToImgur (PintaCore.Workspace.ActiveDocument.PathAndFileName,
			                             "ecf58baa7533e4c4535205bcac51a010");
			string web_path = ParseResult (result);
			updateWindow.Insert (updateWindow.EndIter, "The imgur address is:\n");
			updateWindow.Insert (updateWindow.EndIter, web_path);
		}
		
		private string PostToImgur(string imagFilePath, string apiKey)
		{
			byte[] imageData;

			FileStream fileStream = File.OpenRead(imagFilePath);
			imageData = new byte[fileStream.Length];
			fileStream.Read(imageData, 0, imageData.Length);
			fileStream.Close();

			const int MAX_URI_LENGTH = 32766;
			string base64img = System.Convert.ToBase64String(imageData);
			StringBuilder sb = new StringBuilder();

			for(int i = 0; i < base64img.Length; i += MAX_URI_LENGTH) {
				sb.Append(Uri.EscapeDataString(base64img.Substring(i, Math.Min(MAX_URI_LENGTH, base64img.Length - i))));
			}

			string uploadRequestString = "image=" + sb.ToString ();

			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://api.imgur.com/3/image.xml");
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.Headers ["authorization"] = "Client-ID 3daa740367748fb";
			webRequest.ServicePoint.Expect100Continue = false;

			StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());
			streamWriter.Write(base64img);
			streamWriter.Close();

			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader responseReader = new StreamReader(responseStream);

			string responseString = responseReader.ReadToEnd();
			
			return responseString;
		}
		
		private string ParseResult (string result)
		{
			//TODO: Parse some other interesting stuff out of this!
			XDocument resultXML = XDocument.Parse (result);
			return resultXML.Element ("data").Element ("link").Value;
		}
		
	}
}
