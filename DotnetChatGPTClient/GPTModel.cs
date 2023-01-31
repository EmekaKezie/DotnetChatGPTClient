using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetChatGPTClient
{
    public class GPTModel
    {
        public string model { get; set; } = string.Empty;
        public string prompt { get; set; } = string.Empty;
        public int temperature { get; set; }
        public int max_tokens { get; set; }

    }
}
