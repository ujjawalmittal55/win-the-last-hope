using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    public GameObject[] lifes;
    int c = 2;
    public void cut()
    {

        Destroy(lifes[c]);
        if (c == 0)
        {
            Movement die = gameObject.GetComponent<Movement>();
            die.Die();
        }
        c--;
    }

}