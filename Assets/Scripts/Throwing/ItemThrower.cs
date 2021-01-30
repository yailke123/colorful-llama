using UnityEngine;

namespace Throwing {
    public class ItemThrower : MonoBehaviour {
        [SerializeField] private SkinManager skinManager;
        private BaseThrowable _throwingItem;
        [SerializeField] private GameObject throwingParent;

        private void Start() {
            _throwingItem = skinManager.currentSkinConfig.ThrowingItem;
        }

        public void ThrowItem() {
            _throwingItem.Throw();
        }
        
    }
}
