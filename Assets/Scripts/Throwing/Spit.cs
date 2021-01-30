using UnityEngine;

namespace Throwing {
    public class Spit : BaseThrowable {

        [SerializeField] private float spitForceMagnitude;
        
        public override void Throw(Transform origination) {
            base.Throw(origination);
            Rb.AddForce(transform.forward * spitForceMagnitude, ForceMode2D.Impulse);
        }
    }
}