using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    public static GameObject itemDragging;
    Vector3 startPosition;
    Transform startParent;
    Transform dragParent;
    public static bool isDragging = false;

    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        //Debug.Log("OnBeginDrag");
        itemDragging = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        itemDragging = null;

        if (transform.parent == dragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
        isDragging = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name;
        collisionGameobjectName = collision.gameObject.name;

        Debug.Log(thisGameobjectName);
        Debug.Log(collisionGameobjectName);

        if (thisGameobjectName == "Regadera" && collisionGameobjectName == "Fuego(Clone)" ||
            thisGameobjectName == "AnimalFood" && collisionGameobjectName == "Jaguar(Clone)"
            )
        {
            Debug.Log("Se apaga fuego");
            Destroy(collision.gameObject);
            GlobalScore.ScoreCount += 100;
        }
        //else if ( thisGameobjectName == "Pala" && collisionGameobjectName == "Recogedor")
        //{
        //    Instantiate(Resources.Load("Regadera"), transform.position, Quaternion.identity);
        //    Destroy(collision.gameObject);
        //    Destroy(gameObject);
        //}

    }


    void Update()
    {

    }
}
