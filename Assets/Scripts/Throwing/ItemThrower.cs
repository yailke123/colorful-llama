using System.Collections.Generic;
using UnityEngine;

namespace Throwing {
    public class ItemThrower : MonoBehaviour {
        [SerializeField] private SkinManager skinManager;
        [SerializeField] private Transform throwingParent;
        [SerializeField] private Transform throwingSource;
        
        private BaseThrowable _throwingItemPrefab;

        private Queue<BaseThrowable> _throwablePool;

        private void Awake() {
            _throwablePool = new Queue<BaseThrowable>(10);
        }

        private void Start() {
            _throwingItemPrefab = skinManager.currentSkinConfig.ThrowingItem;
            for (int i = 0; i < 10; i++) {
                BaseThrowable instance = SpawnThrowable();
                instance.gameObject.SetActive(false);
                _throwablePool.Enqueue(instance);
            }
        }

        public void ThrowItem() {
            if (_throwablePool.Count > 0) {
                BaseThrowable headThrowable = _throwablePool.Dequeue();
                headThrowable.gameObject.SetActive(true);
                headThrowable.Throw(throwingSource);
            }
            else {
                BaseThrowable spawnThrowable = SpawnThrowable();
                spawnThrowable.Throw(throwingSource);
            }
        }

        private BaseThrowable SpawnThrowable() {
            BaseThrowable instance = Instantiate(_throwingItemPrefab, Vector3.zero, Quaternion.identity, throwingParent);
            instance.Init(_throwablePool);
            return instance;
        }

        private void Update() {
            // TODO: Delete
            if (Input.GetKeyDown("q")) {
                ThrowItem();
            }

            if (Input.GetKeyDown("w")) {

            }
        }
        
    }
}
