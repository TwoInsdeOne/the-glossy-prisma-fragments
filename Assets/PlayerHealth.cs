using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public CellController cellController;
    private Rigidbody2D rb;
    public float knockbackSpeed;
    public GameObject bloodFX;
    public Shake shaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "triangle")
        {
            if (cellController.GetCellCount() > 0)
            {
                cellController.bag.GetChild(0).GetComponent<CellLifeCycle>().Release();
                
            }
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * knockbackSpeed, ForceMode2D.Impulse);
            GameObject bfx = Instantiate(bloodFX);
            bfx.transform.position = collision.GetContact(0).point;
            shaker.StartShake(shaker.timer, shaker.str, false);
        }
    }
}
