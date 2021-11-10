using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingBucket : MonoBehaviour
{

    public bool letGrow;
    public GameObject fish;
    public GameObject otherFish;
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        fish.SetActive(false);
        otherFish.SetActive(false);
        scaleChange = new Vector3(0.3f, 0.3f, 0.3f);


    }

    // Update is called once per frame
    void Update()
    {
        if (letGrow)
        {
            if (this.transform.localScale.y < 10)
            {
                this.transform.localScale += scaleChange;
            }
            else if (this.transform.localScale.y >= 10)
            {
                fish.SetActive(true);
                otherFish.SetActive(true);
            }

        }

    }
}
