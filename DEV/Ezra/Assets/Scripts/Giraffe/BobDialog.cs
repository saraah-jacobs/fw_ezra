using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BobDialog : MonoBehaviour
{

    // load all objects
    public TextMeshProUGUI textDisplay;      // Textfield
    public string[] sentences;              // what to say
    public AudioSource[] bobDialog;         // audiofiles
    public int index;                       // count what sentence we're on
    public float typingSpeed;               // delay between letters
    public GameObject button;               // button to press on canvas
    public GameObject balloons;             // balloons to appear
    public GameObject balloonsChosen;       // big balloons to choose from

    private Renderer renderer;              // renderer
    private Material[] mats;                // materials on the balloon + string

    public Material greenMat;               // green colour of the balloon itself

    IEnumerator Type()                      // display the text in the textfield, one letter at a time. Wait in between each letter. 
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void Speak()     // play audio file attached to current sentence
    {
        if (index < bobDialog.Length)
        {
            bobDialog[index].Play();
        }

    }

    public void NextSentence()       // execute changes in scene if needed
    {

        if (index < sentences.Length - 1)
        {

            if (index == 6)
            {
                StartCoroutine(BalloonsAppear(balloons));
            }

            if (index == 9)
            {
                BalloonGrouping();
            }

            if (index == 10)
            {
                StartCoroutine(BalloonsAppear(balloonsChosen));
            }

            if (index == 12)
            {
                index++;
            }

            if (index == 13)
            {
                ColourBalloons();
            }

            ShowNextSentence(); // execute function

        }
        else
        {
            PlayerPrefs.SetInt("BalloonReceived", 1); // set object in calendar
            SceneManager.LoadScene(0); // back to main menus

        }

    }

    public void ShowNextSentence()  // move to next sentence, play sound and display text
    {
        index++;
        textDisplay.text = "";
        Speak();
        StartCoroutine(Type());
    }


    IEnumerator BalloonsAppear(GameObject balloonsToShow) // show the balloon row
    {
        int childrenToShow = balloonsToShow.transform.childCount;
        for (int i = 0; i < childrenToShow; i++)
        {
            balloonsToShow.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }



    public void BalloonGrouping() // move the balloons into different groups
    {
        MoveLeft(balloons.transform.GetChild(0));
        MoveLeft(balloons.transform.GetChild(1));
        MoveRight(balloons.transform.GetChild(4));
        MoveRight(balloons.transform.GetChild(5));

    }

    public void MoveLeft(Transform bal)  // move a balloon to the left
    {
        bal.Translate(-0.1f, 0, 0);
    }
    public void MoveRight(Transform bal)  // move a balloon to the right
    {
        bal.Translate(0.1f, 0, 0);
    }

    public void ColourBalloons()  // change the colour of 5th balloon to green
    {
        renderer = balloons.transform.GetChild(4).GetChild(0).GetComponent<Renderer>();
        mats = renderer.materials;
        mats[0] = greenMat;
        renderer.materials = mats;

    }

    // Start is called before the first frame update
    void Start()
    {

        // disable balloons
        int children = balloons.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            balloons.transform.GetChild(i).gameObject.SetActive(false);
        }

        int childrenChosen = balloonsChosen.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            balloonsChosen.transform.GetChild(i).gameObject.SetActive(false);
        }

        // @TODO delete this when ready
        //PlayerPrefs.SetInt("BalloonReceived", 0);


    }


    void Update()
    {

        // enable and diable "next" button at right time
        if (index != 20)
        {
            button.SetActive(false);
            if (index != 11 & index != 13)
            {
                if (!bobDialog[index].isPlaying)
                {
                    button.SetActive(true);
                }
            }
        }
    }





}
