using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_3
{
    class DVDMember : Member
    {
        /// <summary>
        /// 最終レンタル日
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
