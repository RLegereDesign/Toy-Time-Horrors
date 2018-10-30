using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastClick : MonoBehaviour
{


    public float RayDistance;
    public GameObject QuestMe;
    private GameObject shitToMove;
    public float moveHeight;
    public float moveTime;
    private bool moveDisShit;


    private bool HasKey = false;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        { // if left button pressed...
            Debug.DrawRay(transform.position, Camera.main.transform.forward, Color.red, RayDistance);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, RayDistance))
            {
                if (hit.transform.gameObject.tag == "QuestItem")
                {
                    Destroy(hit.transform.gameObject);
                    QuestMe.SetActive(true);
                    HasKey = true;
                }

                if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, RayDistance) && HasKey == true && hit.transform.tag == "Door")
                {
                   
                   shitToMove = hit.transform.gameObject;
                    moveDisShit = true;
                    //StartCoroutine("MoveUp", obj);


                }


                    Debug.Log(hit.transform.name);
            }
        }

            if (moveDisShit)
            {
                shitToMove.transform.position = Vector3.Lerp(shitToMove.transform.position, new Vector3(shitToMove.transform.position.x, moveHeight, shitToMove.transform.position.z), ((1 / moveTime) * 100) * Time.deltaTime);
            if (shitToMove.transform.position.y == moveHeight)
            {
                moveDisShit = false;
            }
        }


        

    }

   /* public IEnumerator MoveUp(GameObject obj)
    {

        obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, moveHeight, obj.transform.position.z), moveTime * Time.fixedDeltaTime);

        yield return null;


    }*/


}