using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nursing_Election
{
    internal class ViewResultClass
    {
        public static string result;
        public ViewResultClass()
        {
            ViewResultHere();
        }
        public void SetResult(string res)
        {
            result = res;
        }
        public string GetResult()
        {
            return result;
        }

        public void ViewResultHere()
        {
            MessageBox.Show(result);
        }


    }
   
}
