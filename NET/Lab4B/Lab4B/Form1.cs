using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
  Class:  Form1.cs
  Author: Mahmood Abdul-Khaliq
  Date:   November 15, 2019

I, Mahmood Abdul-Khaliq, student number #000788833, certify that all code submitted is my own work; 
                           that I have not copied it from any other source.  
                           I also certify that I have not allowed my work to be copied by others.
*/

namespace Lab4B
{
    public partial class Form1 : Form
    {
        string filePath; //String used for filepath
        bool validFileLoaded = false; //Boolean value used for making sure the 'Check Tags' button can/can't be used
        List<string> fileContent = new List<string>(); //Contains all the raw HTML file content
        List<string> htmlTags = new List<string>(); //Contains opening and closing tags

        public Form1()
        {
            InitializeComponent();
            verifyLoadedFile();
        }

        /// <summary>
        /// Verifies if there is a proper loaded file.
        /// If there is, the 'Check Tags' subprompt menu item
        /// will be available; otherwise, it will not be.
        /// </summary>
        private void verifyLoadedFile()
        {
            if (validFileLoaded)
            {
                checkTagsToolStripMenuItem.Enabled = true;
            }
            else
            {
                checkTagsToolStripMenuItem.Enabled = false;
            }
        }

        public void ReadFile(string filePath)
        {
            fileContent.Clear();
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    fileContent.Add(line);
                }
            }
        }

        /// <summary>
        /// Upon clicking the 'Open File' subprompt of the menu, a fileDialog dialog box
        /// will appear, prompting the user to select a valid .html file.
        /// The .html file path will be stored in the filePath string.
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default arguments</param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Filters only HTML files
            fileDialog.Filter = ".HTML files (*.html)|*.html";
            fileDialog.FilterIndex = 1;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Checks to see if the file selected is actually a valid .html file
                if (Path.GetExtension(fileDialog.FileName) == ".html")
                {
                    filePath = fileDialog.FileName;
                    messageLabel.Text = "Loaded: " + fileDialog.FileName;
                    validFileLoaded = true;
                    verifyLoadedFile();
                }
                //Throws an error message if the file is not a valid .html file and resets.
                else
                {
                    messageLabel.Text = "No file loaded; load a file by using File --> Open File";
                    MessageBox.Show("Invalid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    validFileLoaded = false;
                    verifyLoadedFile();
                }
            }
        }

        /// <summary>
        /// Exits the program when the user clicks the 'Exit' button
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default arguments</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Processes each line of HTML code and searches for the tags in them
        /// </summary>
        /// <param name="html">Each individual string entered</param>
        public void ProcessHTML(string html)
        {

            //Self explanatory - if the line isn't there, don't return anything.
            if (String.IsNullOrWhiteSpace(html))
            {
                return;
            }

            //Looks through the entire string
            for (int i = 0; i < html.Length; i++)
            {
                //Checks to see if an open bracket is found
                if (html[i] == '<')
                {
                    int j = i;
                    string tag = "";
                    do
                    {
                        tag += html[j];
                        j++;
                    } while (html[j-1] != '>');

                    //Checks to make sure the tags aren't non-container elements
                    if (!(tag.Contains("img") || tag.Contains("<hr>") || tag.Contains("br")))
                    {
                        if (tag[1].Equals('/'))
                        {
                            fileListBox.Items.Add("Found closing tag: " + tag);
                            htmlTags.Add(tag.ToLower()); //Adds closed tag element to the list (lowercase) for testing balance
                        }
                        else
                        {
                            fileListBox.Items.Add("Found opening tag: " + tag);
                            if (tag.Contains(" "))
                            {
                                tag = tag.Remove(tag.IndexOf(" "))+">";
                            }
                            htmlTags.Add(tag.ToLower()); //Adds open-tagged element to the list (lowercase) for testing balance
                        }
                    }
                    //If they are non-container elements, just display them
                    else
                    {
                        fileListBox.Items.Add("Found non-container tag: " + tag); //DOES NOT add non-container tag to the list
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if tags are balanced
        /// </summary>
        /// <param name="tags">A list of HTML tags</param>
        /// <returns>A true or false result if the HTML si balanced</returns>
        public bool CheckTags(List<string> tags)
        {
            //Initial boolean value; set to 'true' by default in-case an empty HTML page is given.
            bool balanced = true;

            //Trim conditions for checking the inside of tags
            char[] trimConditions = { '<', '/', '>' };
            //Empty stack; used to store (open) HTML tags
            Stack<string> htmlTagStack = new Stack<string>();

            //For-loop; runs through the list of HTML tags
            for (int i = 0; i < tags.Count; i++)
            {
                //Temporary bool value - used to see if the current element is open or closed-tagged
                bool isOpen;
                //Temporary string value - used to see inner tag values without closing brackets (<, / or >)
                string tempString = tags.ElementAt(i).Trim(trimConditions);

                //Checks to see if the current element is an open or closed-tagged element
                if (tags.ElementAt(i)[1].Equals('/'))
                {
                    isOpen = false;
                }
                else isOpen = true;

                //If it is an open-tagged element, push it to the stack
                if (isOpen)
                {
                    htmlTagStack.Push(tags.ElementAt(i));
                }
                //If it is a closed-tagged element, check the inner contents. If it is the same as
                //the last element of the stack, pop the stack and continue
                else
                {
                    if (htmlTagStack.Peek().Trim(trimConditions).Equals(tempString))
                    {
                        htmlTagStack.Pop();
                    }
                    //If it is not the same, the HTML page is not balanced.
                    else
                    {
                        balanced = false;
                    }
                }
            }
            return balanced;
        }

        /// <summary>
        /// Updates the fileListBox with valid information about the .html file when the
        /// 'Check Tags' button is clicked
        /// </summary>
        /// <param name="sender">Default sender</param>
        /// <param name="e">Default arguments</param>
        private void CheckTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListBox.Items.Clear();
            fileContent.Clear();
            ReadFile(filePath);
            foreach (string s in fileContent)
            {
                ProcessHTML(s);
            }

            if (CheckTags(htmlTags))
            {
                messageLabel.Text = fileDialog.SafeFileName + " has balanced HTML tags.";
            }
            else messageLabel.Text = fileDialog.SafeFileName + " does not have balanced HTML tags.";
        }
    }
}
