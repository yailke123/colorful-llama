using System.Collections.Generic;
using UnityEngine;

namespace Throwing {
    
    public abstract class BaseThrowable : MonoBehaviour {
        private Queue<BaseThrowable> _pool;
        
        public abstract void Throw();

        public void Init(Queue<BaseThrowable> pool) {
            _pool = pool;
        }

        protected void GoBackToPool() {
            _pool.Enqueue(this);
        }
    }
}