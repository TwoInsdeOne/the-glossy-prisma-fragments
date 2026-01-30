using Unity.VisualScripting;
using UnityEngine;

public enum CellState
{
    available,
    active,
    used
}

public class CellLifeCycle : MonoBehaviour
{
    public CellState cellState;
    public float lifeCountdown;
    public int cellID;
    public CellGenerator cg;
    public Animator ani;
    public TrailRenderer tr;
    public float trailWidthAfterDying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trailWidthAfterDying = tr.widthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (cellState == CellState.active)
        {
            lifeCountdown -= Time.deltaTime;
        }

        if(lifeCountdown < 0 && cellState == CellState.active)
        {
            transform.parent.parent.GetComponent<CellController>().ReleaseCell(GetCellID());
            ani.SetTrigger("dying");
            cellState = CellState.used;
        }
        if(cellState == CellState.used) {
            trailWidthAfterDying -= Time.deltaTime;
            
            tr.widthMultiplier = Mathf.Max(trailWidthAfterDying,0);
        }
    }

    public void Collect()
    {
        cg.CollectCell();
        cellState = CellState.active;
    }
    public int GetCellID()
    {
        
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if(transform == transform.parent.GetChild(i))
            {
                return i;
            }
        }
        return 0;
    }
}
