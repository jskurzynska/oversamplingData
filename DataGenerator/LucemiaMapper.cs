using CsvHelper.Configuration;

namespace DataGenerator
{
    internal partial class Program
    {
        public class LucemiaMapper : ClassMap<LucemiaData>
        {
            public LucemiaMapper()
            {
                Map(m => m.Col1).Name("Col1");
                Map(m => m.Col2).Name("Col2");
                Map(m => m.Col3).Name("Col3");
                Map(m => m.Col4).Name("Col4");
                Map(m => m.Col5).Name("Col5");
                Map(m => m.Col6).Name("Col6");
                Map(m => m.Col7).Name("Col7");
                Map(m => m.Col8).Name("Col8");
                Map(m => m.Col9).Name("Col9");
                Map(m => m.Col10).Name("Col10");
                Map(m => m.Col11).Name("Col11");
                Map(m => m.Col12).Name("Col12");
                Map(m => m.Col13).Name("Col13");
                Map(m => m.Col14).Name("Col14");
                Map(m => m.Col15).Name("Col15");
                Map(m => m.Col16).Name("Col16");
                Map(m => m.Col17).Name("Col17");
                Map(m => m.Col18).Name("Col18");
                Map(m => m.Col19).Name("Col19");
                Map(m => m.Col20).Name("Col20");
            }
        }
    }
}