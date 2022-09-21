using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public Text text;
    int point = 0;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.name == "BronzeCoin")
        {
            point += 1;
            Destroy(other.gameObject);
        }
        if (other.transform.name == "GoldCoin")
        {
            point += 2;
            Destroy(other.gameObject);
        }
        text.text = point.ToString();


    }
    // Update is called once per frame
    void Update()
    {

    }
}
