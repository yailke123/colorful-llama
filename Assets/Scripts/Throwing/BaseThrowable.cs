using System.Collections.Generic;
using UnityEngine;

namespace Throwing {
    public abstract class BaseThrowable : MonoBehaviour {
        private Queue<BaseThrowable> _pool;

        public virtual void Throw(Transform origination) {
            SoundManager.Instance.PlaySoundWithName("Spit");  
            Transform myTransform = transform;
            myTransform.position = origination.position;
            myTransform.rotation = origination.rotation;
        }

        private void Awake(){
            gameObject.tag = "Throwable";
        }

        public void Init(Queue<BaseThrowable> pool) {
            _pool = pool;
        }

        protected void GoBackToPool() {
            _pool.Enqueue(this);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            switch (other.gameObject.tag)
            {
                case "Enemy":
                    //TODO explosion animation :)
                    SoundManager.Instance.PlaySoundWithName("Explosion");  
                    other.gameObject.GetComponent<EnemyLogic>().Die();
                    break;
                case "Ground":
                    gameObject.SetActive(false);
                    GoBackToPool();
                    break;
            }
        }
    }
}