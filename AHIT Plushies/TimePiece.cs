using UnityEngine;

namespace AHIT_Plushies
{
    public class TimePiece : MonoBehaviour
    {
        private Animator _animator;
        void Start ()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        void LateUpdate()
        {
            var shovel = GetComponent<Shovel>();
            var isHeld = shovel.isHeld || shovel.isHeldByEnemy;
            _animator.SetBool("IsHeld", isHeld);
        }
    }
}