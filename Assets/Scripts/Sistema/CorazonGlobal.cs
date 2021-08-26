using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CorazonGlobal : MonoBehaviour
{
    public int vidaCorazon;
    public GameObject explosion;

    private void Start()
    {
    }

    private void Update()
    {

    }

    private void Awake()
    {
        //StartCoroutine(RotateMe(Vector3.back * 200, 10f));
        StartCoroutine(Damage());
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("Touch");
    //    vidaVirus -= 1;
    //    if (vidaVirus == 0)
    //    {
    //        Destroy(gameObject);
    //    }

    //}
    IEnumerator Damage()
    {
            yield return new WaitForSeconds(8);
            Destroy(gameObject);
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        vidaCorazon -= 1;
        if (vidaCorazon == 0)
        {
            if (HealthSistema.currentHealth + 40 > 100)
            {
                HealthSistema.currentHealth = 100;
            }
            else
            {
                HealthSistema.currentHealth += 40;
            }
            Debug.Log("Curarvida");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
