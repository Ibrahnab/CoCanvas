using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Application.Files
{
    public sealed class FileData
    {
        public required Stream Stream { get; set; }
        public required string ContentType { get; set; }
        public required string FileName { get; set; }
    }
}
