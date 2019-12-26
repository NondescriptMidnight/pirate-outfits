using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoffinBehavior : MonoBehaviour
{

    public GameObject selectorCoffin;
    public bool isSelected = false;
    public static bool hasSelected = false;
    public bool isMatched;
    private bool hasPlayed = false;
    public int coffinNumAssign = 0;
    private NumberScript numberScript;
    private int numberCount;
    public string coffTag;
    public static int currentSelected;

    public float startCounter = 31f;

    public AudioClip numberAmount;

    public void toggleSelector()
    {
        hasSelected = !hasSelected;
        isSelected = !isSelected;
        hasPlayed = false;
        transform.GetChild(0).gameObject.SetActive(isSelected);
        Debug.Log("Selection" + hasSelected);
    }
    void Update()
    {
        startCounter -= Time.deltaTime;
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (startCounter <= 0)
                {
                    currentSelected = coffinNumAssign;
                    hasSelected = true;
                    GameObject.Find("Sarcogh").GetComponent<CoffinScript>().SwapCoffins(this);
                    toggleSelector();
                    Debug.Log("Selection" + hasSelected);
                    print(currentSelected);
                    if (!hasPlayed)
                    {
                        AudioSource.PlayClipAtPoint(numberAmount, Camera.main.transform.position, 1f);
                        hasPlayed = false;
                    }
                }
            }
        }
    }
                    void OnMouseDown()
    {
        if (startCounter <= 0)
        {
            currentSelected = coffinNumAssign;
            hasSelected = true;
            GameObject.Find("Sarcogh").GetComponent<CoffinScript>().SwapCoffins(this);
            toggleSelector();
            Debug.Log("Selection" + hasSelected);
            print(currentSelected);
            if (!hasPlayed)
            {
                AudioSource.PlayClipAtPoint(numberAmount, Camera.main.transform.position, 1f);
                hasPlayed = false;
            }
        }
    }
    public void DestroyCoffin()
    {
        Destroy(gameObject);
        
    }
}