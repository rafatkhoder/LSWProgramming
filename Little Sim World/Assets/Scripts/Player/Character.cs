using UnityEngine;

public class Character  :MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public float speed = 5.0f;
    private Vector3 movementDirection;
    public Vector3 _movementDirection 
    { 
        get { return movementDirection; }
         set { movementDirection = value; } 
    }

    protected Vector2 UpdtaeInput()
    {
        movementDirection.x = InputManger.Instance.XMoving();
        movementDirection.y = InputManger.Instance.YMoving();
        return movementDirection;
    }
    protected void UpdatePosition(Character character)
    {
       // transform.position += character.movementDirection * Time.deltaTime * speed;
        rigidbody2D.MovePosition(transform.position + movementDirection * speed * Time.deltaTime);
    }

}
