using UnityEngine;
using System.Collections.Generic;

public class SetTrigger : MonoBehaviour
{
    public List<SetController> disableSet;
    public List<SetController> enableSet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0; disableSet.Count > i; i++) {
                disableSet[i].DisableAll();
            }
            for (int i = 0; enableSet.Count > i; i++)
            {
                enableSet[i].EnableAll();
            }
        }
    }
}
