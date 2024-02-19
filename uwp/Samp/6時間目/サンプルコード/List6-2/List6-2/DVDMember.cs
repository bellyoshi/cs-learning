using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List6_2
{
    class DVDMember : Member
    {
        /// <summary>
        /// 最終レンタル日
        /// </summary>
        public DateTime LastDate { get; set; }
    }
}
