using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBalloonSelected : MonoBehaviour
{

    public BobDialog bobDialog;

    void OnMouseDown()
    {
        bobDialog.index = 11;
        bobDialog.ShowNextSentence();
    }

}