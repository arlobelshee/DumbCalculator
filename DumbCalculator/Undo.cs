using System;

namespace DumbCalculator
{
    internal class Undo : IDisposable
    {
        private Func<bool> undoOperation;
        private bool disposed;

        public Undo(Func<bool> undoOperation)
        {
            this.undoOperation = undoOperation;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                undoOperation?.Invoke();
                disposed = true;
            }
        }
    }
}