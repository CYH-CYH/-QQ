using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static  class bkImageLis
    {
        public static Bitmap[] bk = new Bitmap[111];
        #region 莫打开眼睛花---加载背景图片       
        public static void LoadImg()
        {
            bk[0] = Properties.Resources._2020060500000001; bk[1] = Properties.Resources._2020060500000002; bk[2] = Properties.Resources._2020060500000003;
            bk[3] = Properties.Resources._2020060500000004; bk[4] = Properties.Resources._2020060500000005; bk[5] = Properties.Resources._2020060500000006;
            bk[6] = Properties.Resources._2020060500000007; bk[27] = Properties.Resources._2020060500000028; bk[48] = Properties.Resources._2020060500000049;
            bk[7] = Properties.Resources._2020060500000008; bk[28] = Properties.Resources._2020060500000029; bk[49] = Properties.Resources._2020060500000050;
            bk[8] = Properties.Resources._2020060500000009; bk[29] = Properties.Resources._2020060500000030; bk[50] = Properties.Resources._2020060500000051;
            bk[9] = Properties.Resources._2020060500000010; bk[30] = Properties.Resources._2020060500000031; bk[51] = Properties.Resources._2020060500000052;
            bk[10] = Properties.Resources._2020060500000011; bk[31] = Properties.Resources._2020060500000032; bk[52] = Properties.Resources._2020060500000043;
            bk[11] = Properties.Resources._2020060500000012; bk[32] = Properties.Resources._2020060500000033; bk[53] = Properties.Resources._2020060500000054;
            bk[12] = Properties.Resources._2020060500000013; bk[33] = Properties.Resources._2020060500000034; bk[54] = Properties.Resources._2020060500000055;
            bk[13] = Properties.Resources._2020060500000014; bk[34] = Properties.Resources._2020060500000035; bk[55] = Properties.Resources._2020060500000056;
            bk[14] = Properties.Resources._2020060500000015; bk[35] = Properties.Resources._2020060500000036; bk[56] = Properties.Resources._2020060500000057;
            bk[15] = Properties.Resources._2020060500000016; bk[36] = Properties.Resources._2020060500000037; bk[57] = Properties.Resources._2020060500000058;
            bk[16] = Properties.Resources._2020060500000017; bk[37] = Properties.Resources._2020060500000038; bk[58] = Properties.Resources._2020060500000059;
            bk[17] = Properties.Resources._2020060500000018; bk[38] = Properties.Resources._2020060500000039; bk[59] = Properties.Resources._2020060500000060;
            bk[18] = Properties.Resources._2020060500000019; bk[39] = Properties.Resources._2020060500000040; bk[60] = Properties.Resources._2020060500000061;
            bk[19] = Properties.Resources._2020060500000020; bk[40] = Properties.Resources._2020060500000041; bk[61] = Properties.Resources._2020060500000062;
            bk[20] = Properties.Resources._2020060500000021; bk[41] = Properties.Resources._2020060500000042; bk[62] = Properties.Resources._2020060500000063;
            bk[21] = Properties.Resources._2020060500000022; bk[42] = Properties.Resources._2020060500000043; bk[63] = Properties.Resources._2020060500000064;
            bk[22] = Properties.Resources._2020060500000023; bk[43] = Properties.Resources._2020060500000044; bk[64] = Properties.Resources._2020060500000065;
            bk[23] = Properties.Resources._2020060500000024; bk[44] = Properties.Resources._2020060500000045; bk[65] = Properties.Resources._2020060500000066;
            bk[24] = Properties.Resources._2020060500000025; bk[45] = Properties.Resources._2020060500000046; bk[66] = Properties.Resources._2020060500000067;
            bk[25] = Properties.Resources._2020060500000026; bk[46] = Properties.Resources._2020060500000047; bk[67] = Properties.Resources._2020060500000068;
            bk[26] = Properties.Resources._2020060500000027; bk[47] = Properties.Resources._2020060500000048; bk[68] = Properties.Resources._2020060500000069;

            bk[69] = Properties.Resources._2020060500000070; bk[78] = Properties.Resources._2020060500000079; bk[86] = Properties.Resources._2020060500000087;
            bk[70] = Properties.Resources._2020060500000071; bk[79] = Properties.Resources._2020060500000080; bk[87] = Properties.Resources._2020060500000088;
            bk[71] = Properties.Resources._2020060500000072; bk[80] = Properties.Resources._2020060500000081; bk[88] = Properties.Resources._2020060500000089;
            bk[72] = Properties.Resources._2020060500000073; bk[81] = Properties.Resources._2020060500000082; bk[89] = Properties.Resources._2020060500000090;
            bk[73] = Properties.Resources._2020060500000074; bk[82] = Properties.Resources._2020060500000083; bk[90] = Properties.Resources._2020061400000004;
            bk[74] = Properties.Resources._2020060500000075; bk[83] = Properties.Resources._2020060500000084; bk[91] = Properties.Resources._2020061400000005;
            bk[75] = Properties.Resources._2020060500000076; bk[84] = Properties.Resources._2020060500000085; bk[92] = Properties.Resources._2020061400000006;
            bk[76] = Properties.Resources._2020060500000077; bk[85] = Properties.Resources._2020060500000086; bk[93] = Properties.Resources._2020061400000007;
            bk[77] = Properties.Resources._2020060500000077;
            bk[94] = Properties.Resources._2020061400000008; bk[102] = Properties.Resources._2020061400000018; bk[110] = Properties.Resources._2020061400000026;
            bk[95] = Properties.Resources._2020061400000009; bk[103] = Properties.Resources._2020061400000019; 
            bk[96] = Properties.Resources._2020061400000010; bk[104] = Properties.Resources._2020061400000020;
            bk[97] = Properties.Resources._2020061400000011; bk[105] = Properties.Resources._2020061400000021;

            bk[98] = Properties.Resources._2020061400000013; bk[106] = Properties.Resources._2020061400000022;
            bk[99] = Properties.Resources._2020061400000014; bk[107] = Properties.Resources._2020061400000023;

            bk[100] = Properties.Resources._2020061400000016; bk[108] = Properties.Resources._2020061400000024;
            bk[101] = Properties.Resources._2020061400000017; bk[109] = Properties.Resources._2020061400000025;

        }
        #endregion
       
    }
}
