using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursing_Election
{
    [Serializable]
    public class CandidateData
    {
        public string Name { get; set; }
        public string Motto { get; set; }
        public int StudentId { get; set; }
        public string PositionTitle { get; set; }
        public string ImageBase64 { get; set; }
    }
}
