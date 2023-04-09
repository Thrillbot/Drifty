using UnityEngine;
using TMPro;

namespace Drifty
{
    public class Engine : MonoBehaviour
    {
        public AnimationCurve torqueCurve;
        public AnimationCurve soundCurve;
        public float maxRPM = 6500;
        public float currentRPM = 500;
        public float idleRPM = 500;
        [Range(0, 1)]
        public float throttle = 0;
        [Range(0,1)]
        public float flywheelInertia = 0.25f;
        public AudioSource engineSound;

        public TMP_Text debugText;

        private void Update()
        {
            currentRPM += CurrentHorsePower() * (Input.GetKey(KeyCode.Space) ? 100 : 10) * throttle * Time.deltaTime;
            if (!Input.GetKey(KeyCode.Space))
                currentRPM -= ((1f-flywheelInertia) * CurrentHorsePower() * 10 * (1f- throttle)) * Time.deltaTime;

            if (currentRPM < idleRPM)
            {
                currentRPM += CurrentHorsePower() * 20 * Time.deltaTime;
            }

            if (currentRPM > maxRPM)
            {
                currentRPM -= CurrentHorsePower() * 100 * Time.deltaTime;
            }

            engineSound.volume = soundCurve.Evaluate(currentRPM / maxRPM);
            engineSound.pitch = soundCurve.Evaluate(currentRPM / maxRPM);

            debugText.text = currentRPM + " | " + CurrentHorsePower();
        }

        public float CurrentHorsePower ()
        {
            return (torqueCurve.Evaluate(currentRPM) * currentRPM) / 5252f;
        }
    }
}
