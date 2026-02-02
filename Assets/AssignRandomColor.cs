using UnityEngine;

public class AssignRandomColor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            if (t.GetComponent<SpriteRenderer>() != null)
            {
                t.GetComponent<SpriteRenderer>().color = RandomColor();
            }
            
        }
    }
    public Color RandomColor()
    {
        return new Color(Random.Range(0.4f, 0.8f), Random.Range(0.4f, 0.8f), Random.Range(0.5f, 1f), Random.Range(0.5f, 0.8f));
    }
}
