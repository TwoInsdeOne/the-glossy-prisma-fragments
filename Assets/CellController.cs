using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CellController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float distance;
    public List<SpringJoint2D> springJoints;
    public Transform bag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cell" && collision.transform.GetComponent<CellLifeCycle>().cellState == CellState.available)
        {
            collision.transform.SetParent(bag, true);
            CatchCell(collision.GetComponent<Rigidbody2D>());
            collision.transform.GetComponent<CellLifeCycle>().cellID = bag.childCount - 1;
            collision.transform.GetComponent<CellLifeCycle>().Collect();
        }
    }
    private void CatchCell(Rigidbody2D cell)
    {
        SpringJoint2D sj = gameObject.AddComponent<SpringJoint2D>();
        sj.autoConfigureDistance = false;
        sj.enableCollision = false;
        sj.frequency = 3f;
        sj.connectedBody = cell;
        sj.distance = distance*Random.Range(0.8f, 1.2f);
        springJoints.Add(sj);
    }
    public void ReleaseCell(int cellID)
    {
        int j = -1;
        for(int i = 0; i < springJoints.Count; i++)
        {
            if (springJoints[i].connectedBody == bag.GetChild(cellID).GetComponent<Rigidbody2D>())
            {
                springJoints[i].connectedBody = null;
                Destroy(springJoints[i]);
                j = i;
                break;
            }
        }
        if(j > -1)
        {
            springJoints.RemoveAt(j);
        }
        bag.GetChild(cellID).SetParent(GameObject.Find("Released Cells").transform, true);
    }
    public int GetCellCount()
    {
        return bag.childCount;
    }
}
