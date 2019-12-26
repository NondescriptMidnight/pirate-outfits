using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumberScript : MonoBehaviour
{

    public int numberAssign = 0;
    public string tagName;
    public AudioClip wrongBuzzer;
    public AudioClip boomSound;
    public GameObject popEffect;
    public GameObject clothPiece;

    private GameObject coffin;
    private CoffinBehavior coffinBehaviour;
    private int coffinNumber;
    private int numberCount;
    private int coffinCountdown;

    void Start()
    {
        coffinBehaviour = GameObject.FindGameObjectWithTag(tagName).GetComponent<CoffinBehavior>();
    }

    void Update ()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("isclicked");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (CoffinBehavior.hasSelected && CoffinBehavior.currentSelected == numberAssign)
                {
                    GameObject popper = (GameObject)Instantiate(popEffect, transform.position, Quaternion.identity);
                    Destroy(popper, 0.5f);
                    AudioSource.PlayClipAtPoint(boomSound, Camera.main.transform.position, 0.7f);
                    Destroy(GetComponent<BoxCollider2D>());
                    Destroy(GetComponent<SpriteRenderer>());
                    coffinBehaviour.DestroyCoffin();
                    CoffinScript.coffinCount--;
                    foreach (Transform child in transform)
                    {
                        GameObject dressCreature = (GameObject)Instantiate(clothPiece, child.transform.position, child.transform.rotation);
                    }
                }
                else if (CoffinBehavior.hasSelected)
                {
                    AudioSource.PlayClipAtPoint(wrongBuzzer, Camera.main.transform.position, 0.2f);
                }
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("isclicked");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (CoffinBehavior.hasSelected && CoffinBehavior.currentSelected == numberAssign)
        {
            GameObject popper = (GameObject)Instantiate(popEffect, transform.position, Quaternion.identity);
            Destroy(popper, 0.5f);
            AudioSource.PlayClipAtPoint(boomSound, Camera.main.transform.position, 0.7f);
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent <SpriteRenderer> ());
            coffinBehaviour.DestroyCoffin();
            CoffinScript.coffinCount--;
            foreach (Transform child in transform)
            {
                GameObject dressCreature = (GameObject)Instantiate(clothPiece, child.transform.position, child.transform.rotation);
            }
        }
        else if (CoffinBehavior.hasSelected)
        {
            AudioSource.PlayClipAtPoint(wrongBuzzer, Camera.main.transform.position, 0.2f);
        }
    }
}


