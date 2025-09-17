using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Filas___pt._2;

namespace Filas
{
    public class CallCenter
    {
        private int _counter = 0;
        public ConcurrentQueue<IncomingCall> Calls { get; private set; } = [];

        /*
         * Atenção: Métodos construtores
         * possuem o mesmo nome da classe (REGRA)
         * São invocados quando constrói-se uma
         * nova instância de objeto desse tipo
         */
        public CallCenter()
        {
            Calls = new ConcurrentQueue<IncomingCall>();
        }

        public int Call(int ClientId)
        {
            IncomingCall call = new IncomingCall();
            call.Id = ++_counter;
            call.ClientId = ClientId;
            call.CallTime = DateTime.Now;

            Calls.Enqueue(call);
            return Calls.Count;
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0 && Calls.TryDequeue(out IncomingCall call))
            {
                call.Consultant = consultant;
                call.StartTime = DateTime.Now;
                return call;
            }
            return null!;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.Now;
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }
    }
}