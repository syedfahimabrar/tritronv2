using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace tritronAPI.Model
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
