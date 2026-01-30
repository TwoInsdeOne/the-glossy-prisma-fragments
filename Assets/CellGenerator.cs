using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    public GameObject cell;
    public Vector2 position;
    public bool cellPresent;
    public Animator ani;
    public Transform galho;

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
