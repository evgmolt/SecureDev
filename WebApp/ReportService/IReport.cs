using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService
{
    public interface IReport<T>
    {
        public bool CreateReport(string resourseName, IEnumerable<T> Items);
    }
}
