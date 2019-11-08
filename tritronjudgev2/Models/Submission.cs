using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Submission
    {
        public Guid Id { get; set; }
        public virtual Problem Problem { get; set; }
        public User User { get; set; }
        public virtual Contest Contest { get; set; }
        public string Language { get; set; }
        public bool IsContestTime { get; set; }
        public byte[] Content { get; set; }
        [NotMapped]
        public string code
        {
            get
            {
                return System.Text.Encoding.UTF8.GetString(this.Content);
            }

            set
            {

                //this.Content = value.Compress();
            }
        }
        public bool IsCompiledSuccessfully { get; set; }
        public string CompilerComment { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsProcessing { get; set; }
        public string ProcessingComment { get; set; }
        public DateTime SubmissionTime { get; set; }
    }
}
