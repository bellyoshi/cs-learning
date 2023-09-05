using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_3
{
    class MyData<T>
    {
        int iCnt = 0;

        T[] tData = new T[100];

        // T型のデータを保存する
        public void PushData(T val)
        {
            tData[iCnt] = val;
            iCnt++;
        }
    }
}
