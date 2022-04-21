using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT
{
    public class WorkWithDate
    {
        private static readonly string[] Formats = { "d", "D", "F", "f", "G", "g", "M", "O", "R", "s", "T", "t", "U", "u", "Y", "y" };
        private readonly DateTime _dt;
        public WorkWithDate(DateTime dt)
        {
            _dt = dt;
            IsTimeInFuture = DateTime.Compare(_dt, DateTime.Now) > 0;
        }


        private string _selectedformat = Formats[0];

        public string DTformat
        {
            get => _selectedformat;
            set => _selectedformat = IsFormat(value) ? value : Formats[0];
        }

        public bool IsTimeInFuture { get; }

        public int SumNowDate => Sum(_dt);

        public bool Compare(WorkWithDate date1)
        {
            return SumNowDate > date1.SumNowDate;
        }

        private static bool IsFormat(string input)
        {
            //if (input.Length != 1)
            //    return false;
            foreach (var format in Formats)
                if (input == format)
                    return true;

            return false;
        }

        private int Sum(DateTime input)
        {
            var str = input.ToString(_selectedformat);
            var sum = 0;
            foreach (var ch in str)
                if (char.IsDigit(ch))
                    sum += int.Parse(ch.ToString());

            return sum;
        }



    }
}