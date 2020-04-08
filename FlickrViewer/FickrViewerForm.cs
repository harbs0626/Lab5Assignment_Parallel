// Fig. 23.4: FickrViewerForm.cs
// Invoking a web service asynchronously with class HttpClient
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using System.Drawing.Imaging;
using System.Net;
using System.Collections.Generic;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #5 - Parallel Programming
/// ** Date (MM/dd/yyy) : 04/07/2020
/// ** CHANGELOGS/PATCHES:
///     1. Added items to App.Config:
///         a. key
///         b. value (from FlickrAPI)
///         c. Retrieve value from b via FickrViewerForm constructor
///     2. Added Controls:
///         a. Label "Please select image format:"
///         b. ComboBox "imageFormatComboBox"
///         c. Label "Please enter image size (width):"
///         d. TextBox "imageSizeTextBox"
///         e. Button "saveResizeButton"
///         f. ProgressBar "saveProgressBar"
///         g. Label "Image Resolution"
///         h. TextBox "imageResolutionTextBox" (readOnly set to true)
///         i. Label "Image FileName:"
///         j. TextBox "imageFileNameTextBox"
///         h. Button "resizeButton"
///         i. Button "saveOriginalButton"
///     3. Added/Updated Methods:
///         a. saveButton_Click
///         b. imagesListBox_SelectedIndexChanged
///         c. GetMyImageFormat
///         d. resizeButton_Click
///         e. saveOriginalButton_Click
///         f. exitButton_Click
///     4. Added Class:
///         a. ImageManipulation
///         b. ImageResolution
/// </summary>
namespace FlickrViewer
{
    public partial class FickrViewerForm : Form
    {
        // Use your Flickr API key here--you can get one at:
        // https://www.flickr.com/services/apps/create/apply
        
        // ** Harbin Ramo - 04/07/2020
        // private const string KEY = "";
        public static string KEY;
        // ** Harbin Ramo - 04/07/2020

        // object used to invoke Flickr web service      
        private static HttpClient flickrClient = new HttpClient();

        Task<string> flickrTask = null; // Task<string> that queries Flickr

        public FickrViewerForm()
        {
            InitializeComponent();

            // ** Harbin Ramo - 04/07/2020
            // ** Load Flickr API Key from app.Config
            KEY = string.Empty;
            KEY = ConfigurationManager.AppSettings["API"].ToString();
            // ** Harbin Ramo - 04/07/2020
        }

        // initiate asynchronous Flickr search query; 
        // display results when query completes
        private async void searchButton_Click(object sender, EventArgs e)
        {
            // if flickrTask already running, prompt user 
            if (flickrTask?.Status != TaskStatus.RanToCompletion)
            {
                var result = MessageBox.Show(
                    "Cancel the current Flickr search?",
                    "Are you sure?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // determine whether user wants to cancel prior search
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    flickrClient.CancelPendingRequests(); // cancel search
                }
            }

            // Flickr's web service URL for searches                         
            var flickrURL = "https://api.flickr.com/services/rest/?method=" +
                            $"flickr.photos.search&api_key={KEY}&" +
                            $"tags={inputTextBox.Text.Replace(" ", ",")}" +
                            "&tag_mode=all&per_page=500&privacy_filter=1";

            imagesListBox.DataSource = null; // remove prior data source
            imagesListBox.Items.Clear(); // clear imagesListBox
            pictureBox.Image = null; // clear pictureBox
            imagesListBox.Items.Add("Loading..."); // display Loading...

            // ** Harbin Ramo - 04/07/2020
            this.imageResolutionTextBox.Clear();
            this.imageFormatComboBox.Items.Clear();
            this.imageSizeTextBox.Clear();
            this.imageFileNameTextBox.Clear();
            // ** Harbin Ramo - 04/07/2020

            // invoke Flickr web service to search Flick with user's tags
            flickrTask = flickrClient.GetStringAsync(flickrURL);

            // await flickrTask then parse results with XDocument and LINQ
            XDocument flickrXML = XDocument.Parse(await flickrTask);

            // gather information on all photos
            var flickrPhotos = from photo in flickrXML.Descendants("photo")
                                let id = photo.Attribute("id").Value
                                let title = photo.Attribute("title").Value
                                let secret = photo.Attribute("secret").Value
                                let server = photo.Attribute("server").Value
                                let farm = photo.Attribute("farm").Value
                                select new FlickrResult
                                {
                                    Title = title,
                                    URL = $"https://farm{farm}.staticflickr.com/" +
                                        $"{server}/{id}_{secret}.jpg"
                                };

            imagesListBox.Items.Clear(); // clear imagesListBox

            // set ListBox properties only if results were found
            if (flickrPhotos.Any())
            {
                // ** Harbin Ramo - 04/07/2020
                int _recordCount = flickrPhotos.ToList().Count;
                this.saveProgressBar.Minimum = 0;
                this.saveProgressBar.Value = this.saveProgressBar.Minimum;
                this.saveProgressBar.Maximum = _recordCount;

                for (int i = 0; i < _recordCount; i++){
                    this.saveProgressBar.Value = i;
                }

                MessageBox.Show($"{_recordCount} record(s) found.");

                this.imageFormatComboBox.Items.Clear();
                this.imageFormatComboBox.Items.Add("-----");
                this.imageFormatComboBox.Items.Add("JPEG");
                this.imageFormatComboBox.Items.Add("GIF");
                this.imageFormatComboBox.Items.Add("PNG");
                this.imageFormatComboBox.Items.Add("BMP");
                this.imageFormatComboBox.SelectedIndex = 0;
                // ** Harbin Ramo - 04/07/2020

                imagesListBox.DataSource = flickrPhotos.ToList();
                imagesListBox.DisplayMember = "Title";
            }
            else // no matches were found
            {
                imagesListBox.Items.Add("No matches");
            }
        }

        // display selected image
        private async void imagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (imagesListBox.SelectedItem != null)
                {
                    string selectedURL = ((FlickrResult) imagesListBox.SelectedItem).URL;

                    // use HttpClient to get selected image's bytes asynchronously
                    byte[] imageBytes = await flickrClient.GetByteArrayAsync(selectedURL);

                    // display downloaded image in pictureBox                  
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(memoryStream);

                        // ** Harbin Ramo - 04/07/2020
                        this.imageResolutionTextBox.Text = $"{this.pictureBox.Image.Width}x{this.pictureBox.Height}";
                        this.imageFileNameTextBox.Text = Path.GetFileName(selectedURL);
                        // ** Harbin Ramo - 04/07/2020
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred while selecting an image.");
                return;
            }
        }

        // ** Harbin Ramo - 04/07/2020
        private static string _imageExtension;
        // ** Harbin Ramo - 04/07/2020

        // ** Harbin Ramo - 04/07/2020
        private async void saveResizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.imageFormatComboBox.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select image format.");
                    return;
                }
                else if (this.imageSizeTextBox.Text == string.Empty || this.imageSizeTextBox.Text == null)
                {
                    MessageBox.Show("Please enter image size for resizing.");
                    return;
                }
                else
                {
                    DialogResult _dialogResult = MessageBox.Show("Do you want to save/download this resized image?",
                        "Save Image", MessageBoxButtons.YesNo);

                    if (_dialogResult == DialogResult.Yes)
                    {
                        string _fileURL = ((FlickrResult)imagesListBox.SelectedItem).URL;

                        ImageManipulation _manipulate = new ImageManipulation();
                        _manipulate.SetImageFormat = GetMyImageFormat(this.imageFormatComboBox.SelectedItem.ToString());

                        byte[] _imageBytes = await flickrClient.GetByteArrayAsync(_fileURL);

                        string _sourceFile = Path.GetFileNameWithoutExtension(_fileURL);
                        string _newFile = $"NEW_{_sourceFile}{_imageExtension}";
                        string _destinationFile = Environment.CurrentDirectory + "\\" + _newFile;

                        int _imageSize = int.Parse(this.imageSizeTextBox.Text);
                        byte[] _imageResized = _manipulate.Resize(_imageBytes, _imageSize);

                        using (var _memoryStream = new MemoryStream(_imageResized))
                        {
                            Image _tempImageHolder = Image.FromStream(_memoryStream);
                            _tempImageHolder.Save(_destinationFile, _manipulate.SetImageFormat);
                        }

                        MessageBox.Show($"Successfully downloaded resized image file: {_newFile}");

                        this.saveResizeButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // ** Harbin Ramo - 04/07/2020

        // ** Harbin Ramo - 04/07/2020
        public ImageFormat GetMyImageFormat(string selectedItem)
        {
            ImageFormat _imageFormat = null;

            switch (selectedItem)
            {
                case "JPEG":
                    _imageFormat = ImageFormat.Jpeg;
                    _imageExtension = ".jpg";
                    break;
                case "GIF":
                    _imageFormat = ImageFormat.Gif;
                    _imageExtension = ".gif";
                    break;
                case "PNG":
                    _imageFormat = ImageFormat.Png;
                    _imageExtension = ".png";
                    break;
                case "BMP":
                    _imageFormat = ImageFormat.Bmp;
                    _imageExtension = ".bmp";
                    break;
                default:
                    break;
            }

            return _imageFormat;
        }
        // ** Harbin Ramo - 04/07/2020

        // ** Harbin Ramo - 04/07/2020
        private async void resizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.imageFormatComboBox.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select image format.");
                    return;
                }
                else if (this.imageSizeTextBox.Text == string.Empty || this.imageSizeTextBox.Text == null)
                {
                    MessageBox.Show("Please enter image size for resizing.");
                    return;
                }
                else
                {
                    if (imagesListBox.SelectedItem != null)
                    {
                        string _fileURL = ((FlickrResult)imagesListBox.SelectedItem).URL;

                        ImageManipulation _manipulate = new ImageManipulation();
                        _manipulate.SetImageFormat = GetMyImageFormat(this.imageFormatComboBox.SelectedItem.ToString());

                        byte[] _imageBytes = await flickrClient.GetByteArrayAsync(_fileURL);

                        int _imageSize = int.Parse(this.imageSizeTextBox.Text);
                        byte[] _imageResized = _manipulate.Resize(_imageBytes, _imageSize);

                        using (var _memoryStream = new MemoryStream(_imageResized))
                        {
                            this.pictureBox.Image = Image.FromStream(_memoryStream);
                        }

                        MessageBox.Show("Image has been resized.");

                        this.saveResizeButton.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // ** Harbin Ramo - 04/07/2020

        // ** Harbin Ramo - 04/07/2020
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // ** Harbin Ramo - 04/07/2020

        // ** Harbin Ramo - 04/07/2020
        private void saveOriginalButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to save/download the original image?",
                    "Save Image", MessageBoxButtons.YesNo);

                if (_dialogResult == DialogResult.Yes)
                {
                    string _fileURL = ((FlickrResult)imagesListBox.SelectedItem).URL;
                    string _sourceFile = Path.GetFileName(_fileURL);
                    string _origFile = $"ORIGINAL_{_sourceFile}";
                    string _destinationFile = Environment.CurrentDirectory + "\\" + _origFile;

                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(_fileURL, _destinationFile);
                    }

                    MessageBox.Show($"Successfully downloaded original image file: {_origFile}");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        // ** Harbin Ramo - 04/07/2020

    }
}

/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/
