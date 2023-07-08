using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPageAnimation : MonoBehaviour
{
    public float min_limit, max_limit;

    private bool change;

    // Start is called before the first frame update
    void Start()
    {
        change = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(timer());

        //if (change)
        //{
        //    transform.eulerAngles = Vector3.forward * min_limit;
        //}
        //else
        //{
        //    transform.eulerAngles = Vector3.forward * max_limit;
        //}


    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(0.5f);
        if (change)
        {
            transform.eulerAngles = Vector3.forward * min_limit;
            yield return new WaitForSeconds(0.5f);
            change = false;
        }
        else
        {
            transform.eulerAngles = Vector3.forward * max_limit;
            yield return new WaitForSeconds(0.5f);
            change = true;
        }
    }


    
}
