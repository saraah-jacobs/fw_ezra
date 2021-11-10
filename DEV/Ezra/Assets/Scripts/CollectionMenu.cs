using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CollectionMenu : MonoBehaviour
{

    public GameObject BalloonButton;
    public GameObject FishButton;
    public GameObject balloon;
    public GameObject fish;



    // public GameObject popup;


    public void MenuBack() // Go back to main meny
    {
        SceneManager.LoadScene(0);
    }

    public void OpenPopupMenu()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Balloon")
        {
            balloon.SetActive(true);
        }

        if (EventSystem.current.currentSelectedGameObject.name == "Fish")
        {
            fish.SetActive(true);
        }
        /* 
                //Finds and assigns the child of the player named "Gun".
                popup = EventSystem.current.currentSelectedGameObject.transform.Find("EventSystem.current.currentSelectedGameObject.name").gameObject;

                //If the child was found.
                if (popup != null)
                {
                    Debug.Log("Child found!");
                    //Find the child named "ammo" of the gameobject "magazine" (magazine is a child of "gun").
                    popup.SetActive(true);
                }
                else Debug.Log("No child with that name attached");

                */


    }


    public void ClosePopups()
    {
        balloon.SetActive(false);
        fish.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("BalloonReceived"))
        {
            if (PlayerPrefs.GetInt("BalloonReceived") == 1)
            {
                BalloonButton.SetActive(true);
            }
            else
            {
                BalloonButton.SetActive(false);
            }
        }
        else
        {
            BalloonButton.SetActive(false);
        }

        if (PlayerPrefs.HasKey("FishReceived"))
        {
            if (PlayerPrefs.GetInt("FishReceived") == 1)
            {
                FishButton.SetActive(true);
            }
            else
            {
                FishButton.SetActive(false);
            }
        }
        else
        {
            FishButton.SetActive(false);
        }

    }
}
