using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace DataGenerator
{
    class Program
    {
        [Serializable]
        public class LucemiaData
        {
            public LucemiaData()
            {
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


        public class ColumnProportion
        {
            public int Value { get; set; }
            public double Proportion { get; set; }
        }
        static void Main(string[] args)
        {
            const string dataPath = "C:\\Users\\Joanna\\repos\\oversamplingData\\bialaczkaData1.csv";
            var expectedRowsNumber = 1000;

            using (TextReader textReader = File.OpenText(dataPath))
            {
                CsvReader csvReader = new CsvReader(textReader);
                csvReader.Read();
                csvReader.ReadHeader();
                var dataFromCsv = csvReader.GetRecords<LucemiaData>().ToList();
                var rowsNumber = dataFromCsv.Count;
                var classes = dataFromCsv.Select(x => x.Class).ToList();
                var cols1 = dataFromCsv.Select(x => x.Col1).ToList();
                var cols2 = dataFromCsv.Select(x => x.Col2).ToList();
                var cols3 = dataFromCsv.Select(x => x.Col3).ToList();
                var cols4 = dataFromCsv.Select(x => x.Col4).ToList();
                var cols5 = dataFromCsv.Select(x => x.Col5).ToList();
                var cols6 = dataFromCsv.Select(x => x.Col6).ToList();
                var cols7 = dataFromCsv.Select(x => x.Col7).ToList();
                var cols8 = dataFromCsv.Select(x => x.Col8).ToList();
                var cols9 = dataFromCsv.Select(x => x.Col9).ToList();
                var cols10 = dataFromCsv.Select(x => x.Col10).ToList();
                var cols11 = dataFromCsv.Select(x => x.Col11).ToList();
                var cols12 = dataFromCsv.Select(x => x.Col12).ToList();
                var cols13 = dataFromCsv.Select(x => x.Col13).ToList();
                var cols14 = dataFromCsv.Select(x => x.Col14).ToList();
                var cols15 = dataFromCsv.Select(x => x.Col15).ToList();
                var cols16 = dataFromCsv.Select(x => x.Col16).ToList();
                var cols17 = dataFromCsv.Select(x => x.Col17).ToList();
                var cols18 = dataFromCsv.Select(x => x.Col18).ToList();
                var cols19 = dataFromCsv.Select(x => x.Col19).ToList();
                var cols20 = dataFromCsv.Select(x => x.Col20).ToList();
                var listOfColumns = new List<List<int>>
                {
                    cols1, cols2, cols3, cols4, cols5, cols6, cols7, cols8, cols9, cols10, cols11,
                    cols12, cols13, cols14, cols15, cols16, cols17, cols18, cols19, cols20, classes
                };
                var listOfProportion = new List<IEnumerable<ColumnProportion>>();
                foreach (var column in listOfColumns)
                {
                    var numberOfDifferentValues = column.GroupBy(x => x);
                    var columnProportion = numberOfDifferentValues.Select(x => new ColumnProportion { Value = x.Key, Proportion = (double)x.Count() / (double)rowsNumber });
                    listOfProportion.Add(columnProportion);
                }
                var numberOfClasses = classes.GroupBy(x => x);
                var classProportionn = numberOfClasses.Select(x => (double)x.Count() / (double)rowsNumber);
                //Najpierw generujemy nr klasy, do której należy generowany obiekt: dzielimy przedział [0, 1] na odcinki o długości pi, 
                var classProportions = listOfProportion.Last();
                var listOfSegments = new List<(double start, double end)>();
                var start = 0D;
                //TODO wyciagnac te segmenty
                foreach (var classProportion in classProportions)
                {
                    var segment = (start: start, end: start + classProportion.Proportion);
                    listOfSegments.Add(segment);
                    start += classProportion.Proportion;
                }

                //generujemy liczbę losową o rozkładzie równomiernym na odcinku [0, 1]. 
                var random = new Random();
                var randomNumber = random.NextDouble();
                var newClass = 1;
                for (var i = 0; i < listOfSegments.Count; ++i)
                {
                    //Jeśli liczba ta wpadła do i-tego odcinka (o długości pi), to numer klasy jest równy i
                    if (randomNumber >= listOfSegments[i].start && randomNumber < listOfSegments[i].end)
                    {
                        newClass = i+1;
                        break;
                    }
                }
                var newRow = new LucemiaData { Class = newClass };

            }

        }
    }

}
