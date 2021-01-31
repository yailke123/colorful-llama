using UnityEngine;

namespace Throwing {
    public class Spit : BaseThrowable {

        [SerializeField] private float spitForceMagnitude;
        [SerializeField] private Rigidbody2D rb;
        
        public override void Throw(Transform origination) {
            base.Throw(origination);
            rb.AddForce(transform.right * spitForceMagnitude, ForceMode2D.Impulse);
        }
    }
}