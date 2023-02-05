using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randmo_Number_File_Writer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int numbersToSave;
        private void exitButton_Click(object sender, EventArgs e)
        {
            //on click close app
            this.Close();
        }

        private void numbersToHoldTextBox_TextChanged(object sender, EventArgs e)
        {
            //handle empty box
            if (numbersToHoldTextBox.Text.Length < 1)
            {
                MessageBox.Show("Enter a valid integer");
            }
            else
            {
                //asign the number inputed to the numbers to save
                numbersToSave = int.Parse(numbersToHoldTextBox.Text);

            }

        }

        private void saveButton_Click(object sender, EventArgs e)

        {
            //initialize streamwriter
            StreamWriter outputFile;
            //on click get the value of numbers to save and generate the random numbers
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFile = File.CreateText(saveFileDialog.FileName);
                //start for loop to get all  random numbers and wirte to file created
                //declare int var
                int num;
                //create the random object
                Random rand = new Random();
                for (int i =0; i < numbersToSave; i++)
                {
                   
                    //assign 
                    num = rand.Next(1,101);

                    //add num to the file
                    outputFile.WriteLine(num);

                }
                outputFile.Close();

                StreamReader inputfile;
                inputfile = File.OpenText(saveFileDialog.FileName);
                listBox.Items.Clear();
                //read file
                while (!inputfile.EndOfStream)
                {
                    // Read an item from the file.
                    // Process the item. add to the listbox

                    int number = int.Parse( inputfile.ReadLine());
                    listBox.Items.Add(number);

                }

                //close file

                inputfile.Close(); 
            }
            else
            {
                MessageBox.Show("The action was cancelled");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //handle by clearing items

            listBox.Items.Clear();  
            numbersToHoldTextBox.Clear();

        }
    }
}
