using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filas___pt._2
{
    public class IncomingCall
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; } = null!;
    }
}