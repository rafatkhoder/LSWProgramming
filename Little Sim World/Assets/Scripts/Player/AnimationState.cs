using UnityEngine;


public class AnimationState : MonoBehaviour
{
    private bool isMove = false;

    bool Is_Move(){return isMove = true;}
    bool Is_Idle(){return isMove = false;}




    public void UpdateAnimation(Character character)
    {
        if (character.animator.runtimeAnimatorController)
        {
            //if (character._movementDirection.x != 0 || character._movementDirection.y != 0)
            //{
            //    character.animator.Play(GameStrings.Walk);
            //}

            
            if (character._movementDirection != Vector3.zero)
            {
                character.animator.SetBool(GameStrings.IsMove, Is_Move());
                character.animator.SetFloat(GameStrings.MoveX, character._movementDirection.x);
                character.animator.SetFloat(GameStrings.MoveY, character._movementDirection.y);
            }

            else
            {
                character._movementDirection = Vector3.zero;
                character.animator.SetBool(GameStrings.IsMove, Is_Idle());
                character.animator.Play(GameStrings.Idle);
            }
        }
    }
}
