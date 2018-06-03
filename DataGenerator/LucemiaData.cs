using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    internal partial class Program
    {
        [Serializable]
        public class LucemiaData
        {
            public LucemiaData(List<int> lucemiaData)
            {
                Col1 = lucemiaData[0];
                Col2 = lucemiaData[1];
                Col3 = lucemiaData[2];
                Col4 = lucemiaData[3];
                Col5 = lucemiaData[4];
                Col6 = lucemiaData[5];
                Col7 = lucemiaData[6];
                Col8 = lucemiaData[7];
                Col9 = lucemiaData[8];
                Col10 = lucemiaData[9];
                Col11 = lucemiaData[10];
                Col12 = lucemiaData[11];
                Col13 = lucemiaData[12];
                Col14 = lucemiaData[13];
                Col15 = lucemiaData[14];
                Col16 = lucemiaData[15];
                Col17 = lucemiaData[16];
                Col18 = lucemiaData[17];
                Col19 = lucemiaData[18];
                Class = lucemiaData.Last();
            }

            public LucemiaData(int Col1, int Col2, int Col3, int Col4, int Col5, int Col6, int Col7, int Col8, int Col9,
                int Col10, int Col11, int Col12, int Col13, int Col14, int Col15, int Col16, int Col17, int Col18,
                int Col19, int Class)
            {
                this.Col1 = Col1;
                this.Col2 = Col2;
                this.Col3 = Col3;
                this.Col4 = Col4;
                this.Col5 = Col5;
                this.Col6 = Col6;
                this.Col7 = Col7;
                this.Col8 = Col8;
                this.Col9 = Col9;
                this.Col10 = Col10;
                this.Col11 = Col11;
                this.Col12 = Col12;
                this.Col13 = Col13;
                this.Col14 = Col14;
                this.Col15 = Col15;
                this.Col16 = Col16;
                this.Col17 = Col17;
                this.Col18 = Col18;
                this.Col19 = Col19;
                this.Class = Class;
            }

            public int Col1 { get; set; }
            public int Col2 { get; set; }
            public int Col3 { get; set; }
            public int Col4 { get; set; }
            public int Col5 { get; set; }
            public int Col6 { get; set; }
            public int Col7 { get; set; }
            public int Col8 { get; set; }
            public int Col9 { get; set; }
            public int Col10 { get; set; }
            public int Col11 { get; set; }
            public int Col12 { get; set; }
            public int Col13 { get; set; }
            public int Col14 { get; set; }
            public int Col15 { get; set; }
            public int Col16 { get; set; }
            public int Col17 { get; set; }
            public int Col18 { get; set; }
            public int Col19 { get; set; }
            public int Col20 { get; set; }
            public int Class { get; set; }
        }
    }
}