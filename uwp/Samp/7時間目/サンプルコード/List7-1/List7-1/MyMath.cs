using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7_1
{
    class MyData
    {
        int iCnt = 0;
        int dCnt = 0;

        int[] iData = new int[100];
        double[] dData = new double[100];

        // int型のデータを保存する
        public void PushData(int val)
        {
            iData[iCnt] = val;
            iCnt++;
        }

        // double型のデータを保存する
        public void PushData(double val)
        {
            dData[dCnt] = val;
            dCnt++;
        }
    }
}
