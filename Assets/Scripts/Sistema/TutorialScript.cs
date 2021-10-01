using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform objectToMove;
    public Transform objectToMoveAnticuerpo;
    public Transform target1Anti;
    public Transform target2Anti;
    public Transform target3Anti;
    public Transform target4Anti;
    public float speed1;
    public float speed2;
    public GameObject cuadroText;
    public GameObject cuadro;
    public GameObject humo;

    public GameObject button0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject button15;
    public GameObject button16;
    public GameObject button17;
    public GameObject button18;
    public GameObject button19;
    public GameObject button20;
    public GameObject button21;
    public GameObject button22;
    public GameObject button23;

    public GameObject tutorialText;
    public GameObject pizarra;
    public GameObject virus;
    public GameObject virus2;
    public GameObject virus3;
    public GameObject virus4;
    public GameObject corazon;
    public GameObject celula;
    public GameObject informaci�nText;
    public GameObject informaci�nText2;
    public GameObject informaci�nText3;
    public GameObject informaci�nText4;
    public GameObject informaci�nText5;
    public GameObject informaci�nText6;

    public GameObject virusEjemplo;
    public GameObject virusEjemplo2;
    public GameObject virusEjemplo3;
    public GameObject virusEjemplo4;

    bool virus1eliminado = false;
    bool virus2eliminado = false;
    bool virus3eliminado = false;
    bool virus4eliminado = false;
    bool bandera = true;

    public AudioSource audioClick;

    public Sprite[] sprites;
    public Sprite[] spritesAnticuerpo;

    bool point1;
    bool point2;
    bool point3;
    bool point4;

    // Start is called before the first frame update
    void Start()
    {
        point1 = true;
        point2 = false;
        point3 = false;
        point4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 == true)
        {
            float step = speed1 * Time.deltaTime;
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, step);

            float step2 = speed1 * Time.deltaTime;
            objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target1Anti.position, step2);
            if (objectToMove.position == target1.position)
            {
                humo.SetActive(true);
            }
        }
        else if (point2 == true)
        {
            float step = speed2 * Time.deltaTime;
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, step);
            float step2 = speed1 * Time.deltaTime;
            objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target2Anti.position, step2);
        }
        if (virusEjemplo == null)
        {
            virus1eliminado = true;
        }
        if (virusEjemplo2 == null)
        {
            virus2eliminado = true;
        }
        if (virusEjemplo3 == null)
        {
            virus3eliminado = true;
        }
        if (virusEjemplo4 == null)
        {
            virus4eliminado = true;
        }
        if (virus1eliminado && virus2eliminado && virus3eliminado && virus4eliminado && bandera)
        {
            PassPoint22();
        }
    }
    public void PassPoint1()
    {
        audioClick.Play();
        humo.SetActive(false);
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target3.position, 200);
        objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target3Anti.position, 200);
        objectToMoveAnticuerpo.GetComponent<SpriteRenderer>().sprite = spritesAnticuerpo[1];
        tutorialText.SetActive(false);
        cuadro.SetActive(true);
        point1 = false;
        button0.SetActive(false);
        button1.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Lo siento, �te despert�? \n�Justo estaba buscando a un anticuerpo como t�!";
    }


    public void PassPoint2()
    {
        audioClick.Play();
        objectToMoveAnticuerpo.GetComponent<SpriteRenderer>().sprite = spritesAnticuerpo[2];
        button1.SetActive(false);
        button2.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Hola! Como ver�s, soy la sustancia que entr� por la inyecci�n de una vacuna. Puedes llamarme Sustan.";
    }
    public void PassPoint3()
    {
        audioClick.Play();
        button2.SetActive(false);
        button3.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estoy aqu� porque tengo una misi�n.\n�Y ese es entrenarte para la batalla!";
    }
    public void PassPoint4()
    {
        audioClick.Play();
        objectToMoveAnticuerpo.GetComponent<SpriteRenderer>().sprite = spritesAnticuerpo[3];
        button3.SetActive(false);
        button4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Varias bacterias est�n a punto de entrar al organismo! Es mi misi�n ense�arte la informaci�n esencial de esas bacterias.";
    }

    public void PassPoint5()
    {
        audioClick.Play();
        button4.SetActive(false);
        button5.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Cada bacteria tiene sus propias caracter�sticas y pueden aparecer en cualquier lado del organismo. �Hay que estar atentos!";
    }

    public void PassPoint6()
    {
        audioClick.Play();
        point2 = true;
        button5.SetActive(false);
        button6.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Para entrenarte, me disfrazar� de cada bacteria y describir� sus caracter�sticas. Empecemos con la primera bacteria.";
    }
    public void PassPoint7()
    {
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[1];
        objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target2Anti.position, 50);
        point2 = false;
        pizarra.SetActive(true);
        virus.SetActive(true);
        informaci�nText.SetActive(true);
        button6.SetActive(false);
        button7.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio) 
        {
            cuadroText.GetComponent<Text>().text = "La bacteria Staphylococcus tiene una frecuencia de aparici�n muy alto. Son las bacterias m�s debiles, pero pueden empezar a lastimarte si est�n mucho tiempo frente a ti.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "La bacteria Enterovirus tiene una frecuencia de aparici�n muy alto. Son las bacterias m�s debiles, pero pueden empezar a lastimarte si est�n mucho tiempo frente a ti.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "La bacteria Rhinovirus tiene una frecuencia de aparici�n muy alto. Son las bacterias m�s debiles, pero pueden empezar a lastimarte si est�n mucho tiempo frente a ti.";
        }
    }
    public void PassPoint8()
    {
        audioClick.Play();
        button7.SetActive(false);
        button8.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria puede atacar al torrente sangu�neo y a las articulaciones del cuerpo. �Hay que tener cuidado!";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria pueden causar dolor de cabeza y dolor de garganta. Es la causante inicial de futuras enfermedades.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria es la principal causa del resfriado com�n. �Hay que eliminarla cuanto antes!";
        }
    }

    public void PassPoint9()
    {
        audioClick.Play();
        button8.SetActive(false);
        button9.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[2];
        virus.SetActive(false);
        virus2.SetActive(true);
        informaci�nText.SetActive(false);
        informaci�nText2.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, la bacteria Staphylococcus Aureus tiene una frecuencia de aparici�n alto. Esta bacteria resiste un poco m�s que la bacteria Staphylococcus pero su ataque es similar.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, la bacteria Coxsackievirus tiene una frecuencia de aparici�n alto. Esta bacteria resiste un poco m�s que las bacterias normales pero su ataque es similar.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, la bacteria Streptococcus Pneumoniae tiene una frecuencia de aparici�n alto. Esta bacteria resiste un poco m�s que la bacteria Rhinovirus pero su ataque es similar.";
        }
    }
    public void PassPoint10()
    {
        audioClick.Play();
        button9.SetActive(false);
        button10.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria puede atacar al coraz�n y a sus v�lvulas card�acas. Hay que eliminarla r�pido.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria puede causar fiebre alta, dolor de cabeza y dolor muscular. �Hay que tener cuidado!";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Estas bacteria puede causar tos, fiebre y dificultad para respirar. �Hay que tener cuidado!";
        }
    }
    public void PassPoint11()
    {
        audioClick.Play();
        button10.SetActive(false);
        button11.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[3];
        virus2.SetActive(false);
        virus3.SetActive(true);
        informaci�nText2.SetActive(false);
        informaci�nText3.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, tenemos a la bacteria Streptococcus. Tiene una frecuencia de aparici�n menor a las 2 bacterias anteriores pero es m�s resistentes y su da�o de ataque es mayor al resto.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, tenemos a la bacteria Neisseria Meningitidis. Tiene una frecuencia de aparici�n menor que las 2 bacterias anteriores pero es m�s resistente y su da�o de ataque es mayor.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Por otro lado, tenemos a la bacteria Haemophilus Influenzae. Tiene una frecuencia de aparici�n menor que las 2 bacterias anteriores pero es m�s resistente y su da�o de ataque es mayor.";
        }
    }
    public void PassPoint12()
    {
        audioClick.Play();
        button11.SetActive(false);
        button12.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacterias puede causar dificultad para respirar, fiebre y falta de energ�a. �Es muy peligrosa!";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria puede causar fiebre, escalofr�os, dolor de cabeza y cambios en el estado mental. �Son muy peligrosas!";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Esta bacteria puede causar fiebre alta, rigidez en el cuello y v�mitos. �Es muy peligrosa!";
        }
    }
    public void PassPoint13()
    {
        audioClick.Play();
        button12.SetActive(false);
        button13.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[4];
        virus3.SetActive(false);
        virus4.SetActive(true);
        informaci�nText3.SetActive(false);
        informaci�nText4.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Finalmente la �ltima bacteria: La bacteria Neisseria Meningitidis. Esta bacteria es la m�s resistente que puedas encontrar, pero aparece en muy poca frecuencia.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Finalmente la �ltima bacteria: La bacteria Arbovirus. Esta bacteria es el m�s resistente de las 4 anteriores, pero aparecen en muy poca frecuencia.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Finalmente la �ltima bacteria: La bacteria Bordetella Pertussis. Esta bacteria es el m�s resistente de las 4 anteriores, pero aparecen en muy poca frecuencia.";
        }
    }
    public void PassPoint14()
    {
        audioClick.Play();
        button13.SetActive(false);
        button14.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "Sin embargo, esta bacteria es muy peligrosa para el organismo. Puede causar fiebre, dolor de cabeza y problemas en el torrente sanguinea. �Hay que estar atento al escenario!";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "Sin embargo, esta bacteria es muy peligrosas para el organismo. Puede causar fiebre alta, desorientaci�n y par�lisis. �Hay que eliminarlas cuanto antes!";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "Sin embargo, esta bacteria es muy peligrosas para el organismo.  Puede causar fiebre alta, ojos enrojecidos y tos ferina. �Hay que eliminarlas cuanto antes!";
        }
    }
    public void PassPoint15()
    {
        audioClick.Play();
        button14.SetActive(false);
        button15.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[0];
        virus4.SetActive(false);
        corazon.SetActive(true);
        informaci�nText4.SetActive(false);
        informaci�nText5.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Tambi�n podr�s encontrar el objecto Coraz�n durante la batalla.";
    }
    public void PassPoint16()
    {
        audioClick.Play();
        button15.SetActive(false);
        button16.SetActive(true);
        cuadroText.GetComponent<Text>().text = "El objeto Coraz�n es muy �til para recuperar vida. Cuando menos te lo esperes, este objeto puede salvarte.";
    }
    public void PassPoint17()
    {
        audioClick.Play();
        button16.SetActive(false);
        button17.SetActive(true);
        corazon.SetActive(false);
        celula.SetActive(true);
        informaci�nText5.SetActive(false);
        informaci�nText6.SetActive(true);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            cuadroText.GetComponent<Text>().text = "�Incluso puedes encontrarte con algunos gl�bulos rojos en el escenario!. Eso s�, hay que evitar atacarlos porque transportan ox�geno a los tejidos corporales.";
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            cuadroText.GetComponent<Text>().text = "�Incluso puedes encontrarte con celulas en el escenario!. Eso s�, recuerda evitar atacarlos porque son aliados.";
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            cuadroText.GetComponent<Text>().text = "�Incluso puedes encontrarte con celulas en el escenario!. Eso s�, recuerda evitar atacarlos porque son aliados.";
        }
    }
    public void PassPoint18()
    {
        audioClick.Play();
        button17.SetActive(false);
        button18.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Despues de un tiempo desaparecen del escenario. Mientras tanto, tu atenci�n debe estar con las bacterias. �No lo olvides!";
    }
    public void PassPoint19()
    {
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target2Anti.position, 50);
        pizarra.SetActive(false);
        informaci�nText6.SetActive(false);
        celula.SetActive(false);
        button18.SetActive(false);
        button19.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Ups, se me olvidaba!.\nPara eliminar a las bacterias, debes tocarlos con la pantalla t�ctil.";
    }
    public void PassPoint20()
    {
        audioClick.Play();
        point1 = false;
        
        button19.SetActive(false);
        button20.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Un toque equivale a 1 HP de da�o y tienes que eliminarlos antes que las bacterias te empiecen a atacar.";
    }
    public void PassPoint21()
    {
        audioClick.Play();
        objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target4Anti.position, 50);
        button20.SetActive(false);
        virusEjemplo.SetActive(true);
        virusEjemplo2.SetActive(true);
        virusEjemplo3.SetActive(true);
        virusEjemplo4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Mira, aparecieron enemigos! Justo a tiempo. Intenta eliminarlos haciendo toques con la pantalla t�ctil.";
    }
    public void PassPoint22()
    {
        bandera = false;
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        objectToMoveAnticuerpo.position = Vector3.MoveTowards(objectToMoveAnticuerpo.position, target2Anti.position, 50);
        objectToMoveAnticuerpo.GetComponent<SpriteRenderer>().sprite = spritesAnticuerpo[5];
        button21.SetActive(false);
        button22.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Bien hecho! Con este tutorial ya est�s listo para la batalla.";
    }
    public void PassPoint23()
    {
        audioClick.Play();
        button22.SetActive(false);
        button23.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Si te olvidas de alguna indicaci�n, siempre puedes consultar este tutorial.\nAhora si, �buena suerte!";
    }
    public void PassPoint24()
    {
        audioClick.Play();
        point1 = false;
        button23.SetActive(false);
        if (LevelSelect.lvlTutorialCirculatorio)
        {
            SceneManager.LoadScene(26);
            LevelSelect.lvlTutorialCirculatorio = false;
        }
        else if (LevelSelect.lvlTutorialNervioso)
        {
            SceneManager.LoadScene(33);
            LevelSelect.lvlTutorialNervioso = false;
        }
        else if (LevelSelect.lvlTutorialRespiratorio)
        {
            SceneManager.LoadScene(8);
            LevelSelect.lvlTutorialRespiratorio = false;
        }
        
    }
}
