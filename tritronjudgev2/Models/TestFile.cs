using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class TestFile
    {
        public Guid Id { get; set; }
        [ForeignKey("Problem")]
        public int Problem_Id { get; set; }
        public virtual Problem Problem { get; set; }
        public byte[] InputData { get; set; }

        /// <remarks>
        /// Using byte[] (compressed with zip) to save database space.
        /// </remarks>
        public byte[] OutputData { get; set; }
    }
}
