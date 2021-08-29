using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VirusGlobal : MonoBehaviour
{
    public static int numVirusEliminados;
    public int vidaVirus;
    public int InternalScore;
    public int numVirusDeleted;
    public GameObject explosion;
    public ParticleSystem particulas;

    private void Start()
    {
        numVirusDeleted = 0;
    }

    private void Update()
    {
        numVirusEliminados = numVirusDeleted;
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
        if (LevelSelect.lvl4Entrar == true || LevelSelect.lvl5Entrar == true)
        {
            yield return new WaitForSeconds(4);
            particulas.Play();
            HealthSistema.currentHealth -= 15;
        }
        else if (LevelSelect.lvl6Entrar == true)
        {
            yield return new WaitForSeconds(3);
            particulas.Play();
            HealthSistema.currentHealth -= 15;
        }
        else
        {
            yield return new WaitForSeconds(5);
            particulas.Play();
            HealthSistema.currentHealth -= 10;
        }
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
        StartCoroutine(ScaleObject(gameObject.transform, new Vector2(0.01f, 0.01f), 0.2f, 0));
        vidaVirus -= 1;
        if (vidaVirus == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            numVirusDeleted += 1;
            SScoreGlobal.EliminadosCount += 1; 
            SScoreGlobal.ScoreCount += InternalScore;
            Destroy(gameObject);
        }
    }

    IEnumerator ScaleObject(Transform obj, Vector2 end, float time, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 originalScale = obj.localScale;

        float rate = 1.0f / time;
        float i = 1.0f;

        obj.localScale = Vector2.Lerp(originalScale, end, i);
        yield return new WaitForSeconds(0.05f);
        obj.localScale = Vector2.Lerp(end, originalScale, i);
    }

}
