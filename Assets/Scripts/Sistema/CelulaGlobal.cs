using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CelulaGlobal : MonoBehaviour
{
    public int vidaCelula;
    public int InternalScore;
    public GameObject explosion;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void Awake()
    {
        StartCoroutine(RotateMe(Vector3.back * 200, 10f));
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
            yield return new WaitForSeconds(5);
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
        vidaCelula -= 1;
        if (vidaCelula == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            HealthSistema.currentHealth -= 10;
            Debug.Log("Quitarvida");
            SScoreGlobal.ScoreCount -= InternalScore;
            Destroy(gameObject);
        }
    }

}
