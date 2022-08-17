using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utility
{
    public static class FileAssist
    {
        private static Stopwatch _stopwatch = new Stopwatch();

        public static long Megabyte => (long)Math.Pow(10, 6);
        public static long Gigabyte => (long)Math.Pow(10, 9);

        #region Write methods

        public static void Write_File(string fileName, long number)
        {
            _stopwatch.Restart();

            using(FileStream fileWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write))            
                for (int i = 0; i < number; i++)
                    fileWriter.WriteByte(0);   
            
            PrintOutOperationTime("File writen using FileStream", fileName);
        }

        public static void Write_Binary(string fileName, long number)
        {
            _stopwatch.Restart();

            using (FileStream fileWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (BinaryWriter binaryWriter = new BinaryWriter(fileWriter))            
                for (int i = 0; i < number; i++)
                    binaryWriter.Write((byte)0);

            PrintOutOperationTime("File writen using BinaryWriter", fileName);
        }

        public static void Write_Writer(string fileName, long number)
        {
            _stopwatch.Restart();

            using(FileStream fileWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using(StreamWriter writer = new StreamWriter(fileWriter))
                for (int i = 0; i < number; i++)
                    writer.Write(0);

            PrintOutOperationTime("File writen using StreamWriter", fileName);
        }

        public static void Write_Buffer(string fileName, long number)
        {
            int parts = 4;
            int bufferSize = (int)(number / parts);
            byte[] buffer = new byte[bufferSize];

            _stopwatch.Restart();

            using(FileStream fileWriter = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using(BufferedStream bufferedWriter = new BufferedStream(fileWriter, bufferSize))
                for (int i = 0; i < parts; i++)
                    bufferedWriter.Write(buffer, 0, bufferSize);

            PrintOutOperationTime("File writen using BufferedStream", fileName);  
        }

        #endregion

        #region Read methods

        public static byte[] Read_File(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' was not found!");
                return null;
            }

            _stopwatch.Restart();

            using(FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileReader.Length];
                int bytesToRead = (int)fileReader.Length;
                int bytesRead = 0;

                while(bytesToRead > 0)
                {
                    int n = fileReader.Read(bytes, bytesRead, bytesToRead);

                    if(n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                }

                PrintOutOperationTime("File read using FileStream", fileName);                
                return bytes;
            }
                
        }

        public static byte[] Read_Buffer(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' was not found!");
                return null;
            }

            _stopwatch.Restart();

            using (FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedStream = new BufferedStream(fileReader))
            {
                byte[] bytes = new byte[fileReader.Length];
                int bytesToRead = (int)fileReader.Length;
                int bytesRead = 0;

                while (bytesToRead > 0)
                {
                    int n = bufferedStream.Read(bytes, bytesRead, bytesToRead);

                    if (n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                }

                PrintOutOperationTime("File read using bufferedStream", fileName);                
                return bytes;
            }
        }

        public static string Read_Reader(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' was not found!");
                return null;
            }

            StringBuilder output = new StringBuilder();
            _stopwatch.Restart();

            using (FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader streamReader = new StreamReader(fileReader))               
                while(!streamReader.EndOfStream)
                    output.Append(streamReader.ReadLine());            

            PrintOutOperationTime("File read using StreamReader", fileName);
            return output.ToString();
        }

        public static int[] Read_Binary(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' was not found!");
                return null;
            }

            int[] output;
            _stopwatch.Restart();

            using (FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryReader = new BinaryReader(fileReader))
            {
                output = new int[fileReader.Length / 4];
                int index = 0;

                while (fileReader.Position < fileReader.Length)
                {
                    output[index] = binaryReader.ReadInt32();
                    index++;
                }                    
            }                          

            PrintOutOperationTime("File read using BinaryReader", fileName);
            Console.WriteLine($"Output array size: {output.Length}");
            return output;
        }

        #endregion

        private static void PrintOutOperationTime(string message, string fileName)
        {            
            Console.WriteLine($"{Environment.NewLine}{message} - File size {GetFileSize(fileName)}");
            _stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {((double)_stopwatch.ElapsedMilliseconds / 1000):F3} seconds");
        }

        private static string GetFileSize(string fileName)
        {
            string[] sizes = { "B", "Kb", "Mb", "Gb", "Tb", }; 
            double length = new FileInfo(fileName).Length;
            int order = 0;

            while(length >= 1024 && order < sizes.Length - 1)
            {
                order++;
                length = length / 1024;
            }

            return $"{length:F1}{sizes[order]}";
        }
    }
}
