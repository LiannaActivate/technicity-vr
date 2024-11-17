    using UnityEngine;

    public class HingeJointAutomaticDoor : MonoBehaviour
    {
        [SerializeField] private HingeJoint hingeJoint; // Reference to the Hinge Joint component
        [SerializeField] private float openVelocity = 100f; // Speed of door opening
        [SerializeField] private float openAngle = 90f; // Target angle for door opening

        private bool isOpening = false;

        private void Start()
        {
            hingeJoint.useMotor = false; // Ensure motor is initially disabled
        }

        public void OpenDoor()
        {
            if (!isOpening)
            {
                isOpening = true;
                JointMotor motor = hingeJoint.motor;
                motor.force = openVelocity;
                motor.targetVelocity = openAngle > 0 ? openVelocity : -openVelocity;
                hingeJoint.motor = motor;
                hingeJoint.useMotor = true;
            }
        }

        public void CloseDoor()
        {
            if (isOpening)
            {
                isOpening = false;
                JointMotor motor = hingeJoint.motor;
                motor.force = openVelocity;
                motor.targetVelocity = openAngle > 0 ? -openVelocity : openVelocity;
                hingeJoint.motor = motor;
                hingeJoint.useMotor = true;
            }
        }
    }
