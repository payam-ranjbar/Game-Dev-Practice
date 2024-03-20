using System;
using UnityEngine;

namespace Comm
{
    [Serializable]
    public class FourDirectionKeyBind
    {
        [SerializeField] private KeyCode forwardKey;
        [SerializeField] private KeyCode backwardKey;
        [SerializeField] private KeyCode rightKey;
        [SerializeField] private KeyCode leftKey;


        public KeyCode ForwardKey => forwardKey;

        public KeyCode BackwardKey => backwardKey;

        public KeyCode RightKey => rightKey;

        public KeyCode LeftKey => leftKey;


        public Vector2 GetDirection2D(KeyCode keyCode)
        {
            if(keyCode == forwardKey) return Vector2.up;
            if(keyCode == backwardKey) return Vector2.down;
            if(keyCode == leftKey) return Vector2.left;
            if(keyCode == rightKey) return Vector2.right;
            
            return Vector2.zero;
        }
        public Vector3 GetDirection3D(KeyCode keyCode)
        {
            if(keyCode == forwardKey) return Vector3.forward;
            if(keyCode == backwardKey) return -Vector3.forward;
            if(keyCode == leftKey) return Vector3.left;
            if(keyCode == rightKey) return Vector3.right;
            
            return Vector3.zero;
        }
    }
    [CreateAssetMenu(fileName = "movement-properties", menuName = "Gameplay/Movement Properties", order = 0)]
    public class MovementProperties : ScriptableObject
    {
        [Header("Key Bind")]
        [SerializeField] private KeyCode sprintKeyCode = KeyCode.LeftShift;
        [SerializeField] private KeyCode dashKeyCode = KeyCode.C;
        [Header("Speed Values")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float turnSpeed;
        [Header("Values")]

        [SerializeField] private float jumpHeight;
        [SerializeField] private float dashCoolDown;

        public KeyCode SprintKeyCode => sprintKeyCode;

        public KeyCode DashKeyCode => dashKeyCode;

        public float WalkSpeed => walkSpeed;
        public float DashSpeed => dashSpeed;

        public float DashCoolDown => dashCoolDown;

        public float RunSpeed => runSpeed;

        public float JumpHeight => jumpHeight;
        public float TurnSpeed => turnSpeed;
    }
}