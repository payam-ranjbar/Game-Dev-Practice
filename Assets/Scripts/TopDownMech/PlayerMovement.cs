using System;
using System.Collections;
using Comm;
using UnityEngine;

namespace TopDownMech
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private MovementProperties properties;
        [SerializeField] private Animator animator;
        

        private Vector3 _direction;
        private bool _isDashing;
        private bool _isSprinting;
        
        private Transform MotorTransform => transform;

        private void Update()
        {
            if(!ReadInput()) return;

            ReadInput();
            AdjustDirectionRelativeToCam();
            _isDashing = CheckDash();
            _isSprinting = CheckSprint();
            Rotate();
            Move();
            SetMovementAnimation();
        }

        private void SetMovementAnimation()
        {
            var movementBlend = _direction.magnitude / (_isSprinting ? 1f : 2f);
            animator.SetFloat("Movement", movementBlend );
            animator.SetBool("IsDashing", _isDashing);
        }

        public bool ReadInput()
        {
            var inputVert = Input.GetAxis("Vertical");
            var inputHoriz = Input.GetAxis("Horizontal");
            
            var dir = new Vector3(inputHoriz, 0,inputVert);
            _direction = dir;

            var isAnyInput = inputVert != 0 || inputHoriz != 0;

            return isAnyInput;
        }

        private void AdjustDirectionRelativeToCam()
        {
            var camTransform = Camera.main.transform;
            var camRight = camTransform.right.GetWithY(0f);
            var camForward = camTransform.forward.GetWithY(0f);

            _direction = _direction.x * camRight + _direction.z * camForward;


        }
        private bool CheckDash()
        {
            return _isDashing || Input.GetKeyDown(properties.DashKeyCode);
        }

        private bool CheckSprint()
        {
            return Input.GetKey(properties.SprintKeyCode);
        }

        private Vector3 GetMovementVector()
        {
            var speed = GetSpeed();
            
            var movementVec = speed * _direction.normalized * Time.deltaTime;
            return movementVec;
        }

        private float GetSpeed()
        {
            if (_isDashing)
            {
                StartCoroutine(DashCoolDown());
                return properties.DashSpeed;
            }

            return _isSprinting ? properties.RunSpeed : properties.WalkSpeed;
        }
        private void Move()
        {
            var movementVec = GetMovementVector();
            MotorTransform.Translate(movementVec, Space.World);
        }

        private void Rotate()
        {
            var rotation = Quaternion.LookRotation(_direction, MotorTransform.up);
            MotorTransform.rotation = Quaternion.Slerp(MotorTransform.rotation, rotation, Time.deltaTime * properties.TurnSpeed);
        }

        private IEnumerator DashCoolDown()
        {
            if(!_isDashing) yield break;
            
            yield return new WaitForSeconds(properties.DashCoolDown);
            _isDashing = false;
        }
    }
}