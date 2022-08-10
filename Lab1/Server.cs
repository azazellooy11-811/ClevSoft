using System;
namespace CleverensSoft.Lab1
{//https://docs.microsoft.com/ru-ru/dotnet/api/system.threading.readerwriterlockslim?view=net-6.0
    public static class Server
    {
        private static int _count;
        private static ReaderWriterLockSlim _readerWriterLockSlim = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _readerWriterLockSlim.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _readerWriterLockSlim.ExitReadLock();
            }
           
        }

        public static int AddToCount(int value)
        {
            _readerWriterLockSlim.EnterWriteLock();
            try
            {
                return _count += value;
            }
            finally
            {
                _readerWriterLockSlim.ExitWriteLock();
            }
        }
    }
}

