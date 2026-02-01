using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = exit.position;
        }
    }
}
