using System;
namespace CleverensSoft.Lab2
{
    public class AsyncCaller
    {
        private readonly EventHandler handler;
        private Thread thread;

        public AsyncCaller(EventHandler handler)
        {
            this.handler = handler;
        }

        private void Aborter(IAsyncResult ar)
        {
            thread?.Abort();
        }

        private void Wait(object timeout)
        {
            Thread.Sleep((int)timeout);
        }

        public bool Invoke(int timeout, object sender, EventArgs e)
        {
            thread = new Thread(Wait);
            IAsyncResult asyncResult = handler?.BeginInvoke(sender, e, Aborter, this);
            thread.Start(timeout);
            thread.Join();
            thread = null;
            return asyncResult.IsCompleted;
        }
    }
}

