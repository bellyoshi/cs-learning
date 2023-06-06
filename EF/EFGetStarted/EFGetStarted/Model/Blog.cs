using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted.Model;

public class Blog
{
    public int BlogId { get; set; }
    public string? Url { get; set; }

    public List<Post> Posts { get; } = new();
}
