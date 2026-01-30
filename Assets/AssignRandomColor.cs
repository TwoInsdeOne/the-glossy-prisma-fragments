using UnityEngine;

public class AssignRandomColor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = RandomColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color RandomColor()
    {
        return new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.3f, 0.8f));
    }
}
