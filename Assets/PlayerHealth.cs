using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public CellController cellController;
    private Rigidbody2D rb;
    public float knockbackSpeed;
    public GameObject bloodFX;
    public Shake shaker;
    public Animator ani;
    public float damageCD;
    private float damageCD_;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageCD_ > 0)
        {
            
            damageCD_ -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "triangle" && damageCD_ <= 0)
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
            ani.SetBool("take damage", true);
            damageCD_ = damageCD;
        }
        if (collision.gameObject.tag == "laser" && damageCD_ <= 0)
        {
            if (cellController.GetCellCount() > 0)
            {
                cellController.bag.GetChild(0).GetComponent<CellLifeCycle>().Release();

            }
            float sin_a = Mathf.Sin(Mathf.Atan2(transform.position.y - collision.transform.position.y, transform.position.x - collision.transform.position.x));
            float sin_b = Mathf.Sin(Mathf.Deg2Rad * collision.transform.eulerAngles.z);
            float dsin = sin_a - sin_b;
            float angle = (collision.transform.eulerAngles.z + (dsin < 0 ? -90 : 90)) * Mathf.Deg2Rad;


            Vector2 direction = (new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))).normalized;
            rb.AddForce(direction * knockbackSpeed, ForceMode2D.Impulse);
            
            GameObject bfx = Instantiate(bloodFX);
            bfx.transform.position = collision.GetContact(0).point;
            

            shaker.StartShake(shaker.timer, shaker.str, true);
            ani.SetBool("take damage", true);
            damageCD_ = damageCD;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public void ResetAnimatorBool()
    {
        ani.SetBool("take damage", false);
    }
}
