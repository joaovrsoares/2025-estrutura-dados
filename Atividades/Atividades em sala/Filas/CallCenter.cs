using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Filas
{
    public class CallCenter
    {
        private int _counter = 0;
        public Queue<IncomingCall> Calls { get; private set; } = [];

        /*
         * Atenção: Métodos construtores
         * possuem o mesmo nome da classe (REGRA)
         * São invocados quando constrói-se uma
         * nova instância de objeto desse tipo
         */
        public CallCenter()
        {
            Calls = new Queue<IncomingCall>();
        }

        public void Call(int ClientId)
        {
            IncomingCall call = new IncomingCall();
            call.Id = ++_counter;
            call.ClientId = ClientId;
            call.CallTime = DateTime.Now;

            Calls.Enqueue(call);
        }

        public IncomingCall Answer(string consultant)
        {
            if (Calls.Count > 0)
            {
                IncomingCall call = Calls.Dequeue();
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