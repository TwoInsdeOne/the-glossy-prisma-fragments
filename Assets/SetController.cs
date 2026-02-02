using UnityEngine;

public class SetController : MonoBehaviour
{
    public bool startEnabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!startEnabled)
        {
            DisableAll();
        }
    }


    public void EnableAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void DisableAll()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
