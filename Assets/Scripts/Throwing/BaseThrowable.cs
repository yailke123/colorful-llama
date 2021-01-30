using System.Collections.Generic;
using UnityEngine;

namespace Throwing {
    public abstract class BaseThrowable : MonoBehaviour {
        [SerializeField] protected Rigidbody2D Rb;
        private Queue<BaseThrowable> _pool;

        public virtual void Throw(Transform origination) {
            Transform myTransform = transform;
            myTransform.position = origination.position;
            myTransform.rotation = origination.rotation;
        }

        public void Init(Queue<BaseThrowable> pool) {
            _pool = pool;
        }

        protected void GoBackToPool() {
            _pool.Enqueue(this);
        }

        private void OnCollisionEnter(Collision other) {
            // Todo: check for collision with the ground.
        }
    }
}