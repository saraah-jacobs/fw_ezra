using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloonSelected : MonoBehaviour
{

    public BobDialog bobDialog;

    void OnMouseDown()
    {
        bobDialog.index = 12;
        bobDialog.ShowNextSentence();
    }

}
