using System;
using System.Collections.Generic;
using System.Text;
using Homework.Utility;

namespace Homework_06
{
    public class Lesson06_Task03
    {
        private const string _fileName = "data.bin";
        private static byte[] _data;
        private static string _output;
        private static int[] _numbers;

        public static void RunTask03()
        {
            FileAssist.Write_File(_fileName, FileAssist.Gigabyte);
            FileAssist.Write_Binary(_fileName, FileAssist.Gigabyte);
            FileAssist.Write_Writer(_fileName, FileAssist.Megabyte);
            FileAssist.Write_Buffer(_fileName, FileAssist.Megabyte);

            _data = FileAssist.Read_File(_fileName);
            _data = FileAssist.Read_Buffer(_fileName);
            _output = FileAssist.Read_Reader(_fileName);
            _numbers = FileAssist.Read_Binary(_fileName);
        }
    }
}
