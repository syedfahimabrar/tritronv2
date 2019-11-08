using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JudgeCompiler
{
    class cCompiler
    {
        private readonly string filePath;
        private readonly string outFile;
        public cCompiler(byte[] content, Guid Id, string filep)
        {
            string tempPath = Environment.GetEnvironmentVariable("TritronTemp");
            string cppFilepath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString();
            cppFilepath += @"\" + Id + ".cpp";
            string c = Directory.GetCurrentDirectory().ToString();
            outFile = tempPath + @"\" + Id + ".exe";
            filePath = cppFilepath;
            if (!File.Exists(cppFilepath))
            {
                FileStream fs = null;
                using (fs = File.Create(cppFilepath))
                {
                    // Add some information to the file.
                    fs.Write(content, 0, content.Length);
                }
            }
        }
        public string ExecuteCommand()
        {
            //Console.WriteLine(command);
            string strError = string.Empty;
            // create the ProcessStartInfo using "cmd" as the program to be run, and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows, and then exit.
            StringBuilder arguments = new StringBuilder();
            //this.filePath = @"C:\Users\fahim\Documents\Visual Studio 2017\Projects\TritronJudge\hello.cpp";
            //g++ inf.cpp -o fah.exe -lm -DONLINE_JUDGE -Wall -DINF=1e9 -DEPS=1e-9  
            arguments.Append($"\"{filePath}\"");
            arguments.Append(' ');
            arguments.Append($"-o \"{outFile}\"");
            arguments.Append(' ');
            arguments.Append("-lm");
            arguments.Append(' ');
            arguments.Append("-DONLINE_JUDGE");
            arguments.Append(' ');
            arguments.Append("Wall");
            arguments.Append(' ');
            arguments.Append("-DINF=1e9");
            arguments.Append(' ');
            arguments.Append("-DEPS=1e-9");
            arguments.Append(' ');
            string arg = arguments.ToString().Trim();
            //arg = @"/C g++ -o C:\Users\fahim\Documents\Visual Studio 2017\Projects\Compiler\Compiler\hello  C:\Users\fahim\Documents\Visual Studio 2017\Projects\Compiler\Compiler\hello.cpp  ";

            System.Diagnostics.ProcessStartInfo procStartInfo = new
                System.Diagnostics.ProcessStartInfo
            {
                // The following commands are needed to redirect the standard output.
                //This means that it will be redirected to the Process.StandardOutput StreamReader.
                Arguments = arg,
                CreateNoWindow = false,
                FileName = Environment.GetEnvironmentVariable("TritronC") ?? throw new InvalidOperationException("TritronCpp Environment Variable not settuped"),// ConfigurationManager.AppSettings["gccPath"],
                //"cmd.exe";
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process
            {
                StartInfo = procStartInfo
            };
            proc.Start();

            // Get the output into a string

            string result = proc.StandardOutput.ReadToEnd();
            //MessageBox.Show("warning"+result);
            //if (result == "")
            //{
            //    result += command + "success";
            //    ce_obj.statusMsg(result);
            //}
            //strError += "standardoutput----->"+proc.StandardOutput.ReadToEnd()+"<\r\n";
            strError = proc.StandardError.ReadToEnd();
            if (strError != "")
            {
                result = strError;
            }
            else
            {
                result = "Success!";
            }
            //MessageBox.Show("error"+strError);
            return result;

        }

    }
}
