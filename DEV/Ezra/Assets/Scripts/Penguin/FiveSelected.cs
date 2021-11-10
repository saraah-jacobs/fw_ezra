using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveSelected : MonoBehaviour
{

    public NinaDialog ninaDialog;

    void OnMouseDown()
    {
        ninaDialog.index = 10;
        ninaDialog.ShowNextSentence();
    }
}
