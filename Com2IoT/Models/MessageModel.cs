using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com2IoT.Models
{
    public class MessageModel
    {
        public DateTime Sended { get; set; }
        public string Message { get; set; }

        public MessageModel(string data)
        {
            Message = data;
            Sended = DateTime.UtcNow;
        }
    }
}
