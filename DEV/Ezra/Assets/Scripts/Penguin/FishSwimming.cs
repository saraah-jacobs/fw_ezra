using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{

    public GameObject bucket;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(bucket.transform.position, bucket.transform.up, -(speed * Time.deltaTime));
    }
}
