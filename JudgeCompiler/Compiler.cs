using Models;
using System;
using System.Collections.Generic;
using System.Text;
using RestrictedProcessCore;
using TritronAPI.common;

namespace JudgeCompiler
{
    public class Compiler
    {
        public string Language, SourceCode;
        public Guid SubmissionID;
        private Submission submission;
        public string CompilePath;
        public Compiler(string Language, Guid SubmissionId, Submission submission)
        {
            this.Language = Language;
            SubmissionID = SubmissionId;
            this.submission = submission;
            if (submission.IsContestTime)
            {
                this.CompilePath = submission.Contest.Id + @"\" + submission.User.UserName + @"\" +
                                   submission.Problem.ProblemName+@"\"+submission.Id;
            }
            else
            {
                this.CompilePath = submission.User.UserName + @"\" + submission.Id;
            }
        }

        public CompilerResult Compile()
        {
            if (Language == LanguageList.cpp.ToString())
            {
                byte[] content = submission.Content;
                cppCompiler compiler = new cppCompiler(content, SubmissionID,this.CompilePath);
                string result = compiler.ExecuteCommand();
                CompilerResult compilerResult;
                if (result == "Success!")
                {
                    compilerResult = new CompilerResult(true, result, SubmissionID.ToString() + "exe");
                    return compilerResult;
                }
                compilerResult = new CompilerResult(false, result, null);
                return compilerResult;
            }
            else if(Language == LanguageList.c.ToString())
            {
                byte[] content = submission.Content;
            }
            return null;
        }

        public ProcessExecutionResult Execute()
        {
            return null;
        }
    }
}
