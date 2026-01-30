using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovements : MonoBehaviour
{
    public PlayerControls playerControls;
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    public float impulsePerCell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = playerControls.Movements.Move.ReadValue<Vector2>();
        direction = direction.normalized*speed;
        rb.AddForce(direction*(1 + GetComponent<CellController>().bag.childCount*impulsePerCell), ForceMode2D.Impulse);
    }
}
