using UnityEngine;

namespace Drifty
{
    public class CarController : MonoBehaviour
    {
        public Engine engine;
        public new Rigidbody rigidbody;
        public float steeringTorque = 100;

        void Update()
        {
            engine.throttle = Input.GetAxis("Vertical");
            rigidbody.AddForce(transform.forward * engine.CurrentHorsePower());
            rigidbody.AddTorque(Vector3.up * Input.GetAxis("Horizontal") * steeringTorque * rigidbody.velocity.sqrMagnitude);
        }
    }
}
