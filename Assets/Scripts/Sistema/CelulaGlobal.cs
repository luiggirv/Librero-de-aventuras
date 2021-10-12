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
    public float speed = 4f;
    public GameObject explosion;

    private float RotateSpeed = 2f;
    private float Radius = 0.5f;

    private Vector2 _centre;
    private float _angle;
    float movementSpeed = 2.7f;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        //_angle += RotateSpeed * Time.deltaTime;

        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        //transform.position = _centre + offset;

        transform.position += Vector3.left * Time.deltaTime * movementSpeed;
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
            yield return new WaitForSeconds(10);
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
            if (SScoreGlobal.ScoreCount - InternalScore < 0)
            {
                SScoreGlobal.ScoreCount = 0;
            }
            else
            {
                SScoreGlobal.ScoreCount -= InternalScore;
            }
            Destroy(gameObject);
        }
    }

    public void isClicked()
    {
        Debug.Log("Sprite Clicked");
        vidaCelula -= 1;
        if (vidaCelula == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            HealthSistema.currentHealth -= 10;
            Destroy(gameObject);
        }
    }

}
