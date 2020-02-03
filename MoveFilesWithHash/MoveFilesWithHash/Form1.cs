using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Threading;

namespace MoveFilesWithHash
{


    public partial class Form1 : Form
    {
        public string NewFileHash;
     
        public string OrginalFileHash;

     

 

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
        }

        private void btnBrowseForInput_Click(object sender, EventArgs e)
        {
           
            DialogResult result = folderBrowserDialog1.ShowDialog();

            txtInputTxt.Text = folderBrowserDialog1.SelectedPath.ToString();

        }

        private void btnBrowseForOutput_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            txtOutputPath.Text = folderBrowserDialog1.SelectedPath.ToString();

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            int result = 0;
            Class1 stackClass = new Class1();
            //return all files in the directory 
            DirectoryInfo inputDir = new DirectoryInfo(txtInputTxt.Text);
            progressBar1.Value = 0;
            progressBar1.Visible = true;


            string[] FilesInInputDir = FindFiles(txtInputTxt.Text);

            DirectoryInfo OutputDir = new DirectoryInfo(txtOutputPath.Text);


            ConcurrentStack<int> concurretStack = new ConcurrentStack<int>();

            result = await (AsyncMoveFiles(FilesInInputDir, OutputDir, inputDir, concurretStack));

            if (result == 1)
            {
                
            }

        }
        
        private static string[] FindFiles(string dir)
        {

            string[] FilesInDir = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);

            return (FilesInDir);
        }

        private Task<int> AsyncMoveFiles(string[] files, DirectoryInfo outputDir, DirectoryInfo InputDir,  ConcurrentStack<int> stack)
        {
            
          
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(argument: stack);
            }

            return Task<int>.Run(() =>
            {
                try
                {
                    return MoveFiles(files, outputDir, InputDir, stack);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + " " + ex.StackTrace);
                    return 2;
                }
            });

        }

        private static string CalculateHash(string filePath)
        {

            byte[] buffer;
            int bytesRead;
            long size;
            long totalByesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                try
                {

                    using (HashAlgorithm hasher = MD5.Create())
                    {
                        do
                        {
                            buffer = new byte[4096];

                            bytesRead = file.Read(buffer, 0, buffer.Length);

                            totalByesRead += bytesRead;

                            hasher.TransformBlock(buffer, 0, bytesRead, null, 0);



                        } while (bytesRead != 0);

                        hasher.TransformFinalBlock(buffer, 0, 0);

                        return MakeHashString(hasher.Hash);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + " " + ex.StackTrace);

                    return "failure";
                }
            }

        }

        private static int MoveFiles(string[] files, DirectoryInfo outputDir, DirectoryInfo InputDir,  ConcurrentStack<int> stack)
        { 
            
            bool CheckIfFileExists = false;
            bool CheckIfHashesMatch = false;

            Form1 frm1 = new Form1();

            frm1.progressBar1.Maximum = files.Length;
            frm1.progressBar1.Step = 1;
            frm1.progressBar1.Visible = true;
            frm1.progressBar1.Value = 1;

            int counter = 0;

            Parallel.ForEach(files, f =>
            {
                
                string MoveToThisDir = outputDir.FullName;

                string fileName = f.Substring((f.LastIndexOf("\\")));

                File.SetAttributes(MoveToThisDir, FileAttributes.Normal);

                MoveToThisDir = outputDir.FullName + fileName;

                try
                {
                    File.Copy(f, MoveToThisDir, true);

                    CheckIfFileExists = (File.Exists(MoveToThisDir));

                    if (!CheckIfFileExists)
                    {
                        Exception exception = new FileNotFoundException();
                        throw exception;
                      
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + " " + ex.StackTrace);
                }

                Form1 frm = new Form1();
               
                frm.OrginalFileHash = CalculateHash(f);

                if (frm.OrginalFileHash == "failure")
                {
                    Exception exception = new SystemException();
                    throw exception;
                }

                frm.NewFileHash = CalculateHash(MoveToThisDir);

                if (frm.OrginalFileHash == frm.NewFileHash)
                {
                    frm.backgroundWorker1.CancelAsync();
                    CheckIfHashesMatch = true;

                }
                else
                {
                    x = false;

                    MessageBox.Show("An error has occured and the hashes for the file: " + f + " do not match");
                }


                stack.Push(counter);

                counter++;

            });

            if (CheckIfHashesMatch)
            {
                frm1.backgroundWorker1.CancelAsync();
                frm1.Dispose();
                return 1;
            }
            else
            {
                frm1.backgroundWorker1.CancelAsync();
                frm1.Dispose();
                return 2;
            }
        }

        

       void update()
        {
            MethodInvoker m = new MethodInvoker(() => progressBar1.Value = 100);
            progressBar1.Invoke(m);

        }
      
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder hashString = new StringBuilder(32);

            foreach (byte b in hash)
            {
                hashString.Append(b.ToString("X2").ToLower());
            }

            return hashString.ToString();
        }

       
       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            ConcurrentStack<int> stack = (ConcurrentStack<int>) e.Argument;

            while (worker.CancellationPending != true)
            {
                if (stack.Count != 0)
                {
                    foreach (int i in stack)
                    {
                        worker.ReportProgress(i);
                        stack.TryPop(out int result);
                    }
                }
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
            progressBar1.Refresh();
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("File Transfer Completed Sucessfully");
              
            }
        }
    }
}
