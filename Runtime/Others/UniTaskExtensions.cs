# if UNITASK_EXTENSIONS_SUPPORT

using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ED.Extensions.UniTasks
{
    public static class UniTaskExtensions
    {
        public static UniTask AttachExitCancellation(this UniTask task)
        {
            return task.AttachExternalCancellation(Application.exitCancellationToken);
        }
        
        public static UniTask<T> AttachExitCancellation<T>(this UniTask<T> task)
        {
            return task.AttachExternalCancellation(Application.exitCancellationToken);
        }
    }
}

#endif