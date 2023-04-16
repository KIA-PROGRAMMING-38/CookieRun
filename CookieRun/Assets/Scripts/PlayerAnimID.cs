using UnityEngine;

namespace Sprites
{
    public static class PlayerAnimID
    {
        public static readonly int IS_JUMPING = Animator.StringToHash("IsJumping");
        public static readonly int IS_DOUBLEJUMPING = Animator.StringToHash("IsDoubleJumping");
        public static readonly int IS_SLIDE = Animator.StringToHash("IsSlide");
        public static readonly int IS_RUN = Animator.StringToHash("IsRun");
        public static readonly int IS_HURT = Animator.StringToHash("IsHurt");
    }
}