using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace DataGenerator
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            const string dataPath = "C:\\Users\\Joanna\\repos\\oversamplingData\\bialaczkaData1.csv";
            var expectedRowsNumber = new List<int> {1000, 1500, 2000, 5000, 10000, 15000, 20000};
            var dataFromCsv = ReadDatasetFromCsv(dataPath);

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
                cols1,
                cols2,
                cols3,
                cols4,
                cols5,
                cols6,
                cols7,
                cols8,
                cols9,
                cols10,
                cols11,
                cols12,
                cols13,
                cols14,
                cols15,
                cols16,
                cols17,
                cols18,
                cols19,
                cols20,
                classes
            };
            var listOfProportion = new List<IEnumerable<ColumnProportion>>();
            foreach (var column in listOfColumns)
            {
                var numberOfDifferentValues = column.GroupBy(x => x);
                var columnProportion = numberOfDifferentValues.Select(x =>
                    new ColumnProportion {Value = x.Key, Proportion = (double) x.Count() / (double) rowsNumber});
                listOfProportion.Add(columnProportion);
            }

            foreach (var expectedRows in expectedRowsNumber)
            {
                var newDataset = new List<LucemiaData>();
                for (var i = 0; i < expectedRows; ++i)
                {
                    var lucemiaData = new List<int>();
                    //Najpierw generujemy cechy nowego obiektu: dzielimy przedział [0, 1] na odcinki o długości pi, 
                    foreach (var columnProportion in listOfProportion)
                    {
                        var newValue = GenerateNewValue(columnProportion);
                        lucemiaData.Add(newValue);
                    }
                    var newRow = new LucemiaData(lucemiaData);
                    newDataset.Add(newRow);
                }
                SaveDataset(newDataset, $"newDataset{expectedRows}.csv");
            }
           
        }

        private static List<LucemiaData> ReadDatasetFromCsv(string dataPath)
        {
            List<LucemiaData> dataFromCsv;
            using (TextReader textReader = File.OpenText(dataPath))
            {
                var csvReader = new CsvReader(textReader);
                csvReader.Read();
                csvReader.ReadHeader();
                dataFromCsv = csvReader.GetRecords<LucemiaData>().ToList();
            }

            return dataFromCsv;
        }

        public static void SaveDataset(List<LucemiaData> lucemiaDataset, string fileName)
        {
            //TODO get path path
            //var path = AppDomain.CurrentDomain.BaseDirectory;
            var path = "C:\\Users\\Joanna\\repos\\oversamplingData";
            using (TextWriter writer = new StreamWriter($"{path}\\{fileName}"))
            {
                var csv = new CsvWriter(writer);
                csv.WriteRecords(lucemiaDataset); // where values implements IEnumerable
            }
        }

        private static int GenerateNewValue(IEnumerable<ColumnProportion> classProportions)
        {
            var listOfSegments = new List<(double start, double end)>();
            var start = 0D;
            foreach (var classProportion in classProportions)
            {
                var segment = (start: start, end: start + classProportion.Proportion);
                listOfSegments.Add(segment);
                start += classProportion.Proportion;
            }

            //generujemy liczbę losową o rozkładzie równomiernym na odcinku [0, 1]. 
            var random = new Random();
            var randomNumber = random.NextDouble();
            var newValue = 1;
            for (var i = 0; i < listOfSegments.Count; ++i)
                //Jeśli liczba ta wpadła do i-tego odcinka (o długości pi), to numer klasy jest równy i
                if (randomNumber >= listOfSegments[i].start && randomNumber < listOfSegments[i].end)
                {
                    newValue = i + 1;
                    break;
                }

            return newValue;
        }
    }
}