using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nursing_Election
{
    public class VotersInformation
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public string Block { get; set; }
        public int Level { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public VotersInformation(string name, string block, int student_id, int level, byte[] photo)
        {
            Name = name;
            StudentId = student_id;
            Block = block;
            Level = level;
            ProfileImage = photo;
        }
      
    }
}
