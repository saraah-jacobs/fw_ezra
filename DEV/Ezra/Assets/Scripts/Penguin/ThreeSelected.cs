using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSelected : MonoBehaviour
{

    public NinaDialog ninaDialog;

    void OnMouseDown()
    {
        ninaDialog.index = 11;
        ninaDialog.ShowNextSentence();
    }
}
