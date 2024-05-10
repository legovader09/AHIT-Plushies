using UnityEngine;

namespace AHIT_Plushies
{
    public class TimePiece : MonoBehaviour
    {
        private Animator _animator;
        private Shovel _shovel;

        void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _shovel = GetComponent<Shovel>();
        }

        void LateUpdate()
        {
            var isHeld = _shovel.isHeld || _shovel.isHeldByEnemy;
            _animator.SetBool("IsHeld", isHeld);
        }
    }
}