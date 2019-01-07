using System;
using System.Threading;

namespace ThreadSafety
{
    public class ConcurrentLong
    {
        private long _threadSafetyLong = new long();

        public long ThreadSafetyLong
        {
            get
            {
                return Interlocked.Read(ref _threadSafetyLong);
            }
            set
            {
                Interlocked.Exchange(ref _threadSafetyLong, value);
            }
        }

        public ConcurrentLong()
        {
        }


        public ConcurrentLong(long temp)
        {
            _threadSafetyLong = temp;
        }

        public static ConcurrentLong operator ++(ConcurrentLong a) {
            Interlocked.Increment(ref a._threadSafetyLong);
            return a;            
        }

        public static ConcurrentLong operator --(ConcurrentLong a)
        {
            Interlocked.Decrement(ref a._threadSafetyLong);
            return a;
        }
    }
}

