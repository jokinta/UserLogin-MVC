using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin1
{
    
    public class Logs
    {
        [Key]
        public int LogId { get; set; }
        public string Activity { get; set; }
        public Logs()
        {

        }
        public Logs(string activity)
        {
            Activity = activity;
        }
    }
}
