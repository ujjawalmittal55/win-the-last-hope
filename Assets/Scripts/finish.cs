using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem end;
    AudioClip endx;
    public GameObject fin;
    IEnumerator after()
    {
        Instantiate(fin, transform.position, Quaternion.identity, transform);
        Instantiate(end, transform.position, transform.rotation);
        Debug.Log("u win");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("level1");
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name == "Player")
        {
            
            StartCoroutine(after());
        }
    
    }
}
