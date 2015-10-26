﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
//---
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;


namespace Push
{
	public partial class ConfigForm : Form
	{

		#region [ FILE EXTENSIONS ]

		// File Extension...
		private void tbFileExtensions_Validated(object sender, EventArgs e)
		{
			errorProviderFileExtensions.SetError(tbFileExtensions, "");
			errorProviderFileExtensions.Dispose();
		}


		private void tbFileExtensions_Validating(object sender, CancelEventArgs e)
		{
			if (!IsValidFileExtensionFilters())
			{
				e.Cancel = true;
				tbFileExtensions.Select(0, tbFileExtensions.Text.Length);
				this.errorProviderFileExtensions.SetError(tbFileExtensions, "One or more extensions are not correct.");
			}
		} // END_METHOD


		private bool IsValidFileExtensionFilters()
		{
			if (string.IsNullOrEmpty(appSettings.FileExtensionFilter))
				return false;

			// Parse the File Extension Filter string...
			List<string> filterList = MainForm.LoadFileExtensions(appSettings);

			#region [ DEBUG STRINGS_SAVE ]
			//// BAD_FILTERS
			//filterList/*_BAD*/ =
			//	new List<string>() { "", " ", "  ", ".*", "*.", "*.*text", "*.|*", "|",
			//						 "#.*", "*.#", "IMG*.JPG", "**.*", "***.*", "*.**",
			//						 "*.***", "**.*", "***.*", "*.**", "*.***", "IMG*.JPG",
			//						 "IMAGE**.JPG", "IMAGE**.*JPG", "*.JP*" };
			//// GOOD_FILTERS
			//filterList/*_GOOD*/ =
			//	new List<string>() { "*.*", "*.jpg", "*.JPEG", "*.tif", "*.TIFF", "*.BMP", 
			//						 "*.DOC", "*.WORD", "*.txt", "*.now", "*.Jpg_Good" };
			#endregion

			// Iterate over each filter looking for poorly formed filters...
			bool isValidFilExtensionFilters = true;
			string regExPattern = @"\*\.\w+|\*\.\*";

			foreach (string filter in filterList)
			{
				Match match = Regex.Match(filter, regExPattern);

				isValidFilExtensionFilters = IsValidExtensionFilter(match, filter);
				if (!isValidFilExtensionFilters)
				{
					// We would actually break here...
					break;
				}
			} // END_FOREACH

			return isValidFilExtensionFilters;
		} // END_METHOD


		private bool IsValidExtensionFilter(Match match, string filter)
		{
			if (match.Success)
			{
				// If we get here, a match was found...

				// Perform a Equals test to make sure there isn't a false positive.
				//		EG: *.JPG would match but the input is IMG*.JPG. == False Positive...
				if (!filter.Equals(match.Value, StringComparison.CurrentCultureIgnoreCase))
				{
					// If we get here, the match and the actual string are NOT the same.
					//		False Positive...
					return false;
				}
			}
			else
			{
				// If we get here, no match was found...
				return false;
			}

			// If we get here, the filter is well formed / valid...
			return true;
		} // END_METHOD

		#endregion		

		
		// Path Common
		string errorMsg = "Invalid Path";

		private bool ValidatePath(string path)
		{
			return Directory.Exists(path);
		} // END_METHOD


		#region [ SOURCE FOLDER ]

		// Source Path
		private void tbSourceFolder_Validating(object sender, CancelEventArgs e)
		{
			if (!ValidatePath(tbSourceFolder.Text))
			{
				e.Cancel = true;
				tbSourceFolder.Select(0, tbSourceFolder.Text.Length);
				this.errorProviderSourceFolder.SetError(tbSourceFolder, errorMsg);
			}
		} // END_METHOD


		// Source Path
		private void tbSourceFolder_Validated(object sender, EventArgs e)
		{
			errorProviderSourceFolder.SetError(tbSourceFolder, "");
			errorProviderSourceFolder.Dispose();
		} // END_METHOD
		
		#endregion		


		#region [ TARGET FOLDER ]

		// Target Path
		private void tbTargetFolder_Validating(object sender, CancelEventArgs e)
		{
			if (!ValidatePath(tbTargetFolder.Text))
			{
				e.Cancel = true;
				tbTargetFolder.Select(0, tbTargetFolder.Text.Length);
				this.errorProviderTargetFolder.SetError(tbTargetFolder, errorMsg);
			}
		} // END_METHOD


		// Target Path
		private void tbTargetFolder_Validated(object sender, EventArgs e)
		{
			errorProviderTargetFolder.SetError(tbSourceFolder, "");
			errorProviderTargetFolder.Dispose();
		} // END_METHOD
		
		#endregion

	}
}
