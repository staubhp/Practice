using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChunker
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new DummyScorecardFileGenerator();
            //generator.generateScorecardFile();
            Console.WriteLine("Enter scorecard file path:");
            var filePath = Console.ReadLine();
            var chunker = new FileChunker(filePath, true);
            chunker.ChunkFile(7000000);
            Console.ReadLine();
        }
    }

    class FileChunker
    {
        private string filePath { get; set; }
        private bool compress { get; set; }
        private List<Task> tasks = new List<Task>(); 
        public FileChunker(string _filePath, bool _compress)
        {
            if (string.IsNullOrEmpty(_filePath))
                _filePath = @"./scorecardfile.csv";

            filePath = _filePath;
            compress = _compress;
        }

        public async void ChunkFile(float recordsInChunk)
        {
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Directory.CreateDirectory(@"./chunks");
            //TODO: clear chunk folder
            using (var lineIterator = File.ReadLines(filePath).GetEnumerator())
            {
                bool running = true;
                for (int chunk = 0; running; chunk++)
                {
                    running = WriteChunk(lineIterator, recordsInChunk, chunk, compress );
                }
            }
            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine("Chunking finished in " + stopwatch.Elapsed.TotalMinutes + " minutes");
            Console.ReadLine();
        }

        private bool WriteChunk(IEnumerator<string> lineIterator, float recordsInChunk, int chunk, bool compress)
        {
            var chunkPath = "./chunks/chunk" + chunk + ".csv";

            using (var writer = File.CreateText(chunkPath))
            {
                for (int i = 0; i < recordsInChunk; i++)
                {
                    if (!lineIterator.MoveNext())
                        return false;

                    writer.WriteLine(lineIterator.Current);
                }
            }

            Console.WriteLine("Wrote chunk " + chunkPath);

            if (compress)
                tasks.Add(Task.Run(() => CompressChunkAsync(chunkPath)));                        

            return true;
        }

        private void CompressChunkAsync(string chunkPath)
        {
            byte[] b;
            using (FileStream f = new FileStream(chunkPath, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            using (FileStream f2 = new FileStream(chunkPath.Replace(".csv", ".gz"), FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }

            Console.WriteLine("Compressed chunk " + chunkPath.Replace(".csv", ".gz"));
        }

        //private bool OldWriteChunk(IEnumerator<string> lineIterator, float recordsInChunk, int chunk, bool compress)
        //{
        //    var chunkPath = "./chunks/chunk" + chunk + (compress? ".gz" : ".csv");

        //    if (compress)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i < recordsInChunk; i++)
        //        {
        //            if (!lineIterator.MoveNext())
        //                return false;

        //            sb.AppendLine(lineIterator.Current);

        //        }

        //        byte[] b = Encoding.ASCII.GetBytes(sb.ToString());                 

        //        using (FileStream f2 = new FileStream(chunkPath, FileMode.Create))
        //        using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
        //        {
        //            gz.Write(b, 0, b.Length);
        //        }
        //    }
        //    else
        //    {
        //        using (var writer = File.CreateText(chunkPath))
        //        {
        //            for (int i = 0; i < recordsInChunk; i++)
        //            {
        //                if (!lineIterator.MoveNext())
        //                    return false;

        //                writer.WriteLine(lineIterator.Current);
        //            }
        //        }
        //    }

        //    Console.WriteLine("Wrote chunk " + chunkPath);

        //    return true;
        //}

        //private bool OldWriteChunk(IEnumerator<string> lineIterator, float recordsInChunk, int chunk, bool compress)
        //{
        //    var chunkPath = "./chunks/chunk" + chunk + ".csv";
        //    using (var writer = File.CreateText(chunkPath))
        //    {
        //        for (int i = 0; i < recordsInChunk; i++)
        //        {
        //            if (!lineIterator.MoveNext())
        //                return false;

        //            writer.WriteLine(lineIterator.Current);

        //        }
        //    }

        //    if (compress)
        //    {

        //        byte[] b;
        //        using (FileStream f = new FileStream(chunkPath, FileMode.Open))
        //        {
        //            b = new byte[f.Length];
        //            f.Read(b, 0, (int)f.Length);
        //        }

        //        using (FileStream f2 = new FileStream(chunkPath.Replace(".csv", ".gz"), FileMode.Create))
        //        using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
        //        {
        //            gz.Write(b, 0, b.Length);
        //        }

        //    }

        //    Console.WriteLine("Wrote chunk " + chunkPath);

        //    return true;
        //}
    }

    class DummyScorecardFileGenerator
    {
        public void generateScorecardFile()
        {
            var filePath = @"./scorecardfile.csv";
            Console.WriteLine("Enter number of records:");
            float recordCount = -1;
            float.TryParse(Console.ReadLine(), out recordCount);
            var rand = new Random();
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                for (int i = 0; i < recordCount; i++)
                {
                    var randN = rand.Next(0, 300);
                    sw.WriteLine("{0},{1},{2},{3},{4}",
                        randN, randN + 1, randN + 3, randN + 7, randN + 13);
                }
            }

            Console.WriteLine("Generated dummy scorecard at " + Path.GetFullPath(filePath));
            Console.ReadLine();
        }
    }

}
