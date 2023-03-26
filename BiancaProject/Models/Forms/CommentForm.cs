using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiancaProject.Models.Forms
{
    internal class CommentForm
    {
        public string? CommentText { get; set; }

        public DateTime TimeWritten { get; set; } = DateTime.UtcNow;

    }
}
