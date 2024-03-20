using System;
using System.Collections;
using UnityEngine;

namespace TopDownMech
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private float attackCoolDown;

        private bool _isAttacking;

        private void Start()
        {
            // attackCoolDown =  
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }

        public void Attack()
        {
            if(_isAttacking) return;

            if (!animator.GetCurrentAnimatorStateInfo(1).IsTag("Smack"))
            {
                _isAttacking = true;
                animator.SetTrigger("Smack");
                StartCoroutine(AttackCoolDown());
            }
        }

        private IEnumerator AttackCoolDown()
        {
            if(!_isAttacking) yield break;

            yield return new WaitForSeconds(attackCoolDown);

            _isAttacking = false;
        }
    }
}