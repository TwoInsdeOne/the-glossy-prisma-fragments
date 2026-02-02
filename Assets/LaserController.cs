using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float offset;
    public Animator ani;
    private bool started;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            offset -= Time.deltaTime;
            if (offset < 0)
            {
                ani.SetTrigger("start");
                started = true;
            }
        }
        
    }
}
