using UnityEngine;

public class SelfDestroyTimer : MonoBehaviour
{
    public bool useTimer;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (useTimer)
        {
            Destroy(gameObject, timer);
        }
    }

    public void TriggerSelfDestroy()
    {
        Destroy(gameObject);
    }
}
