using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RayCastClick : MonoBehaviour
{


    public float RayDistance;
    public GameObject QuestMe;
    public GameObject Springinv1;
    public GameObject Springinv2;
    public GameObject ToyPiece;
    public GameObject ClawToy;
    public GameObject AfterHalf;
    public GameObject Darts;
    public GameObject Slingshot;
    public GameObject Sling;
    public GameObject Dart;
    public GameObject Spawner;

    public TextMeshProUGUI DisplayMe;


    private string Object = "";

   
    private bool HasBToy = false;
    private bool HasSpring1 = false;
    private bool HasSpring2 = false;
    private bool HasClawToy = false;
    private bool HasToyPiece = false;
    private bool HasDarts = false;
    private bool HasSlingshot = false;
    [SerializeField]
    private bool drawn = true;

    // Use this for initialization
    void Start()
    {

        DisplayMe.SetText("");


    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hitInv;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hitInv, RayDistance) && hitInv.transform.gameObject.tag == "QuestItem")
        {

            Object = hitInv.transform.gameObject.name;
            DisplayMe.SetText(Object);




        } else
        {

            DisplayMe.SetText("");

        }




            if (Input.GetButtonDown("Fire1"))
        { // if left button pressed...
            //Debug.DrawRay(transform.position, Camera.main.transform.forward, Color.red, RayDistance);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, RayDistance))
            {
                switch (hit.transform.gameObject.name)
                {
                    case "BrokenToy":
                        Destroy(hit.transform.gameObject);
                        QuestMe.SetActive(true);
                        HasBToy = true;

                        break;



                    case "Spring1":
                        Destroy(hit.transform.gameObject);
                        HasSpring1 = true;
                        Springinv1.SetActive(true);
                        
                        break;

                    case "Spring2":
                        Destroy(hit.transform.gameObject);
                        HasSpring2 = true;
                        Springinv2.SetActive(true);

                        break;

                    case "UpperJaw":
                        Destroy(hit.transform.gameObject);
                        HasToyPiece = true;
                        ToyPiece.SetActive(true);

                        break;

                    case "Dart":
                        Destroy(hit.transform.parent.gameObject);
                        HasDarts = true;
                        Darts.SetActive(true);

                        break;

                    case "SlingShot":
                        Destroy(hit.transform.parent.gameObject);
                        HasSlingshot = true;
                        Slingshot.SetActive(true);

                        break;




                }

                



                if (HasBToy && HasSpring1 && HasSpring2 && HasToyPiece)
                {

                    HasClawToy = true;
                    HasBToy = false;
                    QuestMe.SetActive(false);
                    HasSpring1 = false;
                    Springinv1.SetActive(false);
                    HasSpring2 = false;
                    Springinv2.SetActive(false);
                    HasToyPiece = false;
                    ToyPiece.SetActive(false);
                    ClawToy.SetActive(true);

                }

                if (hit.transform.parent.gameObject.name == "DresserB4" && HasClawToy)
                {
                    hit.transform.parent.gameObject.SetActive(false);
                    AfterHalf.SetActive(true);


                }

                








                /* if (hit.transform.gameObject.name == "BrokenToy")
                 {
                     Destroy(hit.transform.gameObject);
                     QuestMe.SetActive(true);
                    HasBToy = true;
                 }*/




                Debug.Log(hit.transform.name);
            }
        }


        if (Input.GetButtonDown("Draw"))
        {
            Debug.Log("FUckEveryone");
            if (drawn)
            {
                Sling.SetActive(false);
                drawn = false;
            }
            else
            {
                if (HasSlingshot == true)
                {

                    Sling.SetActive(true);
                    drawn = true;
                }
            }

        }


        if (Input.GetButtonDown("Fire1") && HasSlingshot && HasDarts)
        {
            Instantiate(Dart, Spawner.transform.position, gameObject.transform.rotation);


        }






    }

   /* public IEnumerator MoveUp(GameObject obj)
    {

        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, moveHeight, obj.transform.position.z), moveTime * Time.fixedDeltaTime);

        yield return null;


    }*/


}