using System.Collections.Concurrent;

namespace Core.Utils.Queue
{
    public class CircularQueue<T> : ConcurrentQueue<T> where T : class 
    {
        public readonly int Limit;

        public CircularQueue(int limit) =>
            Limit = limit;
        

        public new void Enqueue(T element)
        {
            base.Enqueue(element);
            if (Count > Limit)
            {
                TryDequeue(out _);
            }
        }

    }
}
