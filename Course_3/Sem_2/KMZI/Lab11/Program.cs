using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class lab10
    {
        public static void CalculateCompressionEfficiency(string compressed, string original)
        {
            int compressedLength = Math.Min(compressed.Length, 4);
            double efficiency = (1 - (double)compressedLength / original.Length) * 100;
            Console.WriteLine($"\nЭффективность сжатия арифметическим методом: {efficiency:F2}%");


        }

        static void Main(string[] args)
        {
            {
                Console.OutputEncoding = Encoding.UTF8;

                string word = "малосимпатичный";
                int wordLength = word.Length;
                Compressor wordCompressor = new Compressor();



                wordCompressor.Build(word);
                Console.WriteLine("Вероятности :");
                foreach (var i in wordCompressor.Nodes)
                {
                    Console.WriteLine($"p({i.Symbol}) = {i.High - i.Low}");
                }

                Console.WriteLine("Интервалы :");
                foreach (var i in wordCompressor.Nodes)
                {
                    Console.WriteLine($"{i.Symbol}  {i.Low} - {i.High}");
                }
                Console.WriteLine();


                // Измерение времени сжатия
                Stopwatch compressionTimer = new Stopwatch();
                compressionTimer.Start();




                var compressResult = wordCompressor.Compress(word);
                compressionTimer.Stop();

                Console.WriteLine("Сжатые данные:");
                Console.WriteLine(InfoString.Sb.ToString());
                Console.WriteLine($"Результат: {compressResult}\n");

                // Измерение времени распаковки
                Stopwatch decompressionTimer = new Stopwatch();
                decompressionTimer.Start();
                var decompressResult = wordCompressor.Decompress(compressResult, wordLength, wordLength / 2 + 1);
                decompressionTimer.Stop();

                Console.WriteLine("Расжатые данные:");
                Console.WriteLine(InfoString.Sb.ToString());
                Console.WriteLine($"Результат: {decompressResult}");

                CheckCompressionOverflow(compressResult);
                CalculateCompressionEfficiency(compressResult.ToString(), word);
                Console.WriteLine($"Время сжатия: {compressionTimer.ElapsedMilliseconds} мс");
                Console.WriteLine($"Время распаковки: {decompressionTimer.ElapsedMilliseconds} мс");
            }

            Console.WriteLine("\n\n");

            {
                string word = "малосимпатичныйкрасивый";
                int wordLength = word.Length;
                Compressor wordCompressor = new Compressor();

                wordCompressor.Build(word);
                Console.WriteLine("Интервалы:");
                foreach (var i in wordCompressor.Nodes)
                {
                    Console.WriteLine($"p({i.Symbol}) = {i.High - i.Low}");
                }
                foreach (var i in wordCompressor.Nodes)
                {
                    Console.WriteLine($"{i.Symbol}  {i.Low} - {i.High}");
                }

                var compressResult = wordCompressor.Compress(word);
                Console.WriteLine("Сжатые данные");
                Console.WriteLine(InfoString.Sb.ToString());
                Console.WriteLine($"Результат: {compressResult}\n");

                var decompressResult = wordCompressor.Decompress(compressResult, wordLength, wordLength / 2 + 1);
                Console.WriteLine("Расжатые данные:");
                Console.WriteLine(InfoString.Sb.ToString());
                Console.WriteLine($"Результат: {decompressResult}");
                CheckCompressionOverflow(compressResult);
                CalculateCompressionEfficiency(compressResult.ToString(), word);
            }

            Console.ReadLine();
        }

        public static void CheckCompressionOverflow(decimal compressResult)
        {
            int maxBits = (int)Math.Log(int.MaxValue, 2) + 1;
            int bitsNeeded = Decimal.GetBits(compressResult).Length;
            if (bitsNeeded > maxBits)
            {
                Console.WriteLine("Возможно переполнение при сжатии данных.");
            }
            else
            {
                Console.WriteLine("Переполнение при сжатии данных маловероятно.");
            }
        }
    }

    public class Compressor
    {
        public List<Node> Nodes { get; set; }
        public Dictionary<char, decimal> Frequencies { get; set; }
        public Node ResultNode { get; set; }

        public void Build(string source)
        {
            Nodes = new List<Node>();
            decimal inc = 1 / (decimal)source.Length;
            Frequencies = new Dictionary<char, decimal>();
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }
                Frequencies[source[i]] += inc;
            }
            Frequencies = Frequencies.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            decimal low = 0;
            foreach (var item in Frequencies)
            {
                Nodes.Add(new Node { Symbol = item.Key, Low = Math.Round(low, 5), High = Math.Round(low + item.Value, 5) });
                low += item.Value;
            }
        }

        public decimal Compress(string source)
        {
            InfoString.Sb = new StringBuilder();
            ResultNode = new Node { Symbol = '*', High = 1, Low = 0 };
            foreach (var item in source)
            {
                decimal oldHigh = ResultNode.High;
                decimal oldLow = ResultNode.Low;
                InfoString.Sb.Append(ResultNode.ToString()).Append(Environment.NewLine);
                ResultNode.Symbol = '*';
                ResultNode.High = oldLow + (oldHigh - oldLow) * Nodes.Find(x => x.Symbol == item).High;
                ResultNode.Low = oldLow + (oldHigh - oldLow) * Nodes.Find(x => x.Symbol == item).Low;
            }
            InfoString.Sb.Append(ResultNode.ToString()).Append(Environment.NewLine);
            return ResultNode.Low;
        }

        public string Decompress(decimal compress, int leng, int t)
        {
            StringBuilder sb = new StringBuilder();
            InfoString.Sb = new StringBuilder();
            for (int i = 0; i < leng; i++)
            {
                char symbol = Nodes.Find(x => Math.Round(compress, t) >= x.Low && Math.Round(compress, t) < x.High).Symbol;
                InfoString.Sb.Append(compress.ToString() + $"\t-- {symbol}").Append(Environment.NewLine);
                sb.Append(symbol);
                Node tempNode = Nodes.Find(x => x.Symbol == symbol);
                compress = (compress - tempNode.Low) / (tempNode.High - tempNode.Low);
            }
            return sb.ToString();
        }
    }

    public class Node
    {
        public char Symbol { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }

        public override string ToString()
        {
            return string.Format("Low: {0} | High: {1}", Low.ToString(), High.ToString());
        }
    }

    public class InfoString
    {
        public static StringBuilder Sb { get; set; }
    }
}