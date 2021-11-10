using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class NinaDialog : MonoBehaviour
{

    public GrowingBucket growingBucket;         // script to grow bucker
    public GameObject answers;                  // boxes with answers
    public AudioSource[] ninaDialog;            // audiofiles
    public GameObject FishTaken;                // fish in bucket
    public GameObject FishOnFloor;             // fih on floor
    public TextMeshProUGUI textDisplay;        // textfield
    public string[] sentences;                 // what to say
    public int index;                          // count what sentence we're on
    public float typingSpeed;                    // delay between letters
    public GameObject button;                  // button to press on canvas
    IEnumerator Type()                          // display the text in the textfield, one letter at a time. Wait in between each letter. 

    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (index == sentences.Length)
        {
            button.SetActive(true);
        }

    }

    public void Speak()     // play audio file attached to current sentence

    {
        if (index < ninaDialog.Length)
        {
            ninaDialog[index].Play();
        }

    }

    IEnumerator ShowFish()      // hide the fih in the bucket, display the fish on the ground 
    {
        int children = FishTaken.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            FishTaken.transform.GetChild(i).gameObject.SetActive(false);
            FishOnFloor.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void NextSentence()          // execute changes in scene if needed

    {


        // animations and stuff
        if (index < sentences.Length)
        {
            if (index == 5)
            {
                growingBucket.letGrow = true;
            }
            if (index == 7)
            {
                StartCoroutine(ShowFish());
            }
            if (index == 9)
            {
                answers.SetActive(true);
            }

            ShowNextSentence();
        }
        else
        {
            PlayerPrefs.SetInt("FishReceived", 1);  // set object in calendar
            SceneManager.LoadScene(0); // back to main menus
        }

    }

    public void ShowNextSentence()      // move to next sentence, play sound and display text

    {

        textDisplay.text = "";
        Speak();
        StartCoroutine(Type());
        index++;
    }

    // Start is called before the first frame update
    void Start()
    {
        // @TODO delete this when ready
        //PlayerPrefs.SetInt("FishReceived", 0);

    }

    void Update()
    {
        // enable and diable "next" button at right time
        if (index != 15 && index != 0 & index != sentences.Length)
        {
            button.SetActive(false);
            if (index != 10 & index != 11)
            {
                if (!ninaDialog[(index - 1)].isPlaying)
                {
                    button.SetActive(true);
                }
            }
        }
    }



}