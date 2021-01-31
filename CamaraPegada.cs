using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPegada : MonoBehaviour
{

    public GameObject macaco;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - macaco.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= macaco.transform.position + offset;    
    }
}
