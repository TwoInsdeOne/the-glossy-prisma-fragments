using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    public GameObject cell;
    public Vector2 position;
    public bool cellPresent;
    public Animator ani;
    public Transform galho;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateCell()
    {
        GameObject c = Instantiate(cell);
        c.transform.SetParent(galho);
        c.transform.localPosition = position;
        c.GetComponent<CellLifeCycle>().cg = this;
        cellPresent = true;
        ani.SetBool("cell_present", true);
    }
    public void CollectCell()
    {
        cellPresent = false;
        ani.SetBool("cell_present", false);
    }
}
