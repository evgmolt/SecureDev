using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService
{
    public class ReportToFile<T> : IReport<T>
    {
        public bool CreateReport(string resourseName, IEnumerable<T> Items)
        {
            try
            {
                if (File.Exists(resourseName))
                {
                    File.Delete(resourseName);
                }
                var resultList = Items.Select(s => s.ToString());
                File.WriteAllLines(resourseName, resultList);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
