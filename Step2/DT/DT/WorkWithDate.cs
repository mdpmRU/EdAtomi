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
        private string _selectedformat = Formats[0];

        public WorkWithDate(DateTime dt)
        {
            _dt = dt;
            IsTimeInFuture = DateTime.Compare(_dt, DateTime.Now) > 0;
        }

        public string DTFormat
        {
            get => _selectedformat;
            set => _selectedformat = IsFormat(value) ? value : Formats[0];
        }

        public bool IsTimeInFuture { get; }

        public double SumNowDate => Sum(_dt);

        public bool Compare(WorkWithDate other)
        {
            return SumNowDate > other.SumNowDate;
        }

        private static bool IsFormat(string input)
        {
            foreach (var format in Formats)
                if (input == format)
                    return true;

            return false;
        }

        private double Sum(DateTime input)
        {
            var str = input.ToString(_selectedformat);
            var sum = str
                .Where(char.IsDigit)
                .Select(char.GetNumericValue)
                .Sum();

            return sum;
        }
    }
}