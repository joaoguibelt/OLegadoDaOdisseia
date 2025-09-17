using UnityEngine;

public class ChecagemChao : MonoBehaviour
{
    public LayerMask chao;

    public bool IsOnFloor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsTouchingFloor(other.gameObject))
            IsOnFloor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsTouchingFloor(other.gameObject))
            IsOnFloor = false;
    }

    private bool IsTouchingFloor(GameObject obj)
    {
        return ((1 << obj.layer) & chao.value) != 0;
    }
}


