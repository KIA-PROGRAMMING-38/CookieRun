using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : StateMachineBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor = new Color(1,1,1,1);
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Enemy에 닿아서 hp가 0이 됐을시 무적상태인것처럼 보이지 않게 SpriteColor 초기화.
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _originalColor;
        
        // GameOver
        GameManager.gameOver = true;
    }
}
