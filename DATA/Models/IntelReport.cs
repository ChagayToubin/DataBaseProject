using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DATA.Models
{
    public class IntelReport
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }



        public void PrintReport()
        {
            Console.WriteLine($"ID: {Id}, Reporter: {ReporterId}, Target: {TargetId}, Time: {Timestamp}");
            Console.WriteLine(Text);
        }

        public class Builder
        {
            private readonly IntelReport _report = new IntelReport();

            public Builder SetId(int id)
            {
                _report.Id = id;
                return this;
            }

            public Builder SetReporterId(int reporterId)
            {
                _report.ReporterId = reporterId;
                return this;
            }

            public Builder SetTargetId(int targetId)
            {
                _report.TargetId = targetId;
                return this;
            }

            public Builder SetText(string text)
            {
                _report.Text = text;
                return this;
            }

            public Builder SetTimestamp(DateTime timestamp)
            {
                _report.Timestamp = timestamp;
                return this;
            }
            public IntelReport Build()
            {
                return _report;
            }
        }
    }
}
