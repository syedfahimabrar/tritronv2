using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.DTOs
{
    public class TestFIleDto
    {
        public Guid Id { get; set; }
        public byte[] InputTest { get; set; }
        public byte[] OutputTest { get; set; }
    }
}
