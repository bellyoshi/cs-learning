using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List5_18
{
    class Sample
    {
        public int hensu1;
        private int hensu2;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        Sample()
        {
            DoSomething1(); // OK
            DoSomething2(); // OK
        }

        /// <summary>
        /// publicメソッド
        /// </summary>
        public void DoSomething1()
        {
            hensu1 = 100;   // OK
            hensu2 = 200;   // OK
        }

        /// <summary>
        /// privateメソッド
        /// </summary>
        private void DoSomething2()
        {
            hensu1 = 300;   // OK
            hensu2 = 400;   // OK
        }
    }
}
