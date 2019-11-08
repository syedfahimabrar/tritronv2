using System;
using System.Collections.Generic;
using System.Text;

namespace TritronAPI.common
{
    public class CompilerResult
    {
        public CompilerResult(bool isCompiledSuccessfully, string compilerComment, string outputFile = null)
        {
            IsCompiledSuccessfully = isCompiledSuccessfully;
            CompilerComment = compilerComment;
            OutputFile = outputFile;
        }

        public CompilerResult()
        {
            //throw new NotImplementedException();
        }

        public bool IsCompiledSuccessfully { get; set; }

        public string CompilerComment { get; set; }

        public string OutputFile { get; set; }
    }
}
