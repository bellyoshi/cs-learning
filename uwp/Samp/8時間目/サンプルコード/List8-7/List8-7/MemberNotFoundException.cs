using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List8_7
{
    class MemberNotFoundException : Exception
    {
        public MemberNotFoundException() : base()
        {

        }

        public MemberNotFoundException(string Message)
            : base(Message)
        {

        }

        public MemberNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
