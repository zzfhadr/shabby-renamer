using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security;
using System.Security.Permissions;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System.IO;

namespace rename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//load button way to use : change . in music title to 丶
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Songs (*.MP3;*.FLAC;*.WAV)|*.MP3;*.FLAC;*.WAV|" + 
                "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String filePath in openFileDialog1.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        //string filePath = @"D:\desktop\LOOMING\Desktop\qwer\0.序章.mp3";
                        var file = ShellFile.FromFilePath(filePath);

                        // Read and Write:

                        string[] oldAuthors = file.Properties.System.Author.Value;
                        string oldTitle = file.Properties.System.Title.Value;
                        StringBuilder newTile = new StringBuilder(3650);
                        //file.Properties.System.Author.Value = new string[] { "Author #1", "Author #2" };
                        if (oldTitle == null || oldTitle == "kuwo")
                        //if (true)
                        {

                            //get file name
                            int i, j;
                            StringBuilder filename = new StringBuilder(3650);
                            // MessageBox.Show("filepath:"+filePath);
  
                            j = 0;
                            for (i = filePath.Length - 1; i >= 0; i--)
                            {
                                //there is a problem here!!!
                                if (filePath[i] == '\\' && j == 0)
                                    j = 1;
                                // MessageBox.Show(" "+filePath[i]);
                                if (j == 0)
                                    filename.Append(filePath[i]);


                            }
                            oldTitle = new string (filename.ToString().Reverse().ToArray());
                        }
                        //int counter = -1;
                            foreach (char caca in oldTitle)
                            {
                               // counter++;

                                if (caca == '.')
                                    newTile.Append('、');
                                else
                                    newTile.Append(caca);

                            }
                            file.Properties.System.Title.Value = newTile.ToString();
                        
                       

                        // Alternate way to Write:

                        //ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
                        //propertyWriter.WriteProperty(SystemProperties.System.Author, new string[] { "Author" });
                        //propertyWriter.Close();
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + filePath.Substring(filePath.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }




        }

        private void button6_Click(object sender, EventArgs e)//change buttion way to use : generete irc for 
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Songs (*.MP3;*.FLAC;*.WAV)|*.MP3;*.FLAC;*.WAV|" +
                "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (String filePath in openFileDialog1.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {

                        //get file name
                        int i, j;
                        StringBuilder filename = new StringBuilder(3650);
                        // MessageBox.Show("filepath:"+filePath);
                        StringBuilder pathpath = new StringBuilder(3560);
                        j = 0;
                        for (i = filePath.Length - 1; i >= 0; i--)
                        {
                            //there is a problem here!!!
                            if (filePath[i] == '\\'&& j == 0 )
                                j=1;
                            // MessageBox.Show(" "+filePath[i]);
                            if (j == 0)
                                filename.Append(filePath[i]);
                            else
                                pathpath.Append(filePath[i]);

                        }


                        //get rid of .mp3
                        StringBuilder lrcfile = new StringBuilder(3600);
                        i = 231;
                        foreach (char c9 in filename.ToString())
                        {
                            if (c9 == '.' && i == 231)
                            {
                                i = 0;
                            }
                            if(i==0)
                            {
                                lrcfile.Append(c9);
                                //i++;
                            }
                        }
                        //plus .lrc and path 
                        //FINALly name got!!!!

                        lrcfile.Remove(0, 1);
                        string lrcfullname = new string(pathpath.ToString().Reverse().ToArray())+ new string(lrcfile.ToString().Reverse().ToArray()) + ".lrc";
                        // Create a FileInfo  

                        //rename
                        System.IO.FileInfo fi = new System.IO.FileInfo(lrcfullname);
                        // Check if file is there  
                        if (fi.Exists)
                        {
                            var file = ShellFile.FromFilePath(filePath);
                            string[] oldAuthors = file.Properties.System.Author.Value;
                            string oldTitle = file.Properties.System.Title.Value;
                            // Move file with a new name. Hence renamed.
                            
                            Directory.CreateDirectory(new string(pathpath.ToString().Reverse().ToArray()) + @"ライン");
                            if (oldAuthors[0] == null)
                            { 
                                ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
                                propertyWriter.WriteProperty(SystemProperties.System.Author, new string[] { "Ace" });
                                propertyWriter.Close();
                                 oldAuthors = file.Properties.System.Author.Value;
                            }

                            if (oldTitle == null)
                            {
                                
                                fi.CopyTo(new string(pathpath.ToString().Reverse().ToArray()) + @"ライン\" + oldAuthors[0] + " - " + new string (lrcfile.ToString().Reverse().ToArray()) + ".lrc");
                                
                            }
                            else
                            fi.CopyTo(new string(pathpath.ToString().Reverse().ToArray())+ @"ライン\" + oldAuthors[0] + " - " + oldTitle+".lrc");
                            //Console.WriteLine("File Renamed.");
                        }
                        else
                            MessageBox.Show(lrcfullname);

                        // MessageBox.Show("lrcfullname:" + lrcfullname);
                        //Console.WriteLine(lrcfullname);

                        //string filePath = @"D:\desktop\LOOMING\Desktop\qwer\0.序章.mp3";

                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + filePath.Substring(filePath.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

