using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;

public class TestAventura1
{
    // A Test behaves as an ordinary method
    //[Test]
    //public void TestAventura1SimplePasses()
    //{
        // Use the Assert class to test conditions
    //}

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator TestAventura1HealthBar()
    //{
    //    //Creamos el objecto HealthBar
    //    var healthbar = new GameObject().AddComponent<Slider>();

    //    //Inicializamos parametros
    //    healthbar.GetComponent<Slider>().minValue = 0;
    //    healthbar.GetComponent<Slider>().maxValue = 100;
    //    healthbar.GetComponent<Slider>().value = 100;
    //    float internalHealth;

    //    //Evaluamos si el valor se actualiza
    //    internalHealth = healthbar.GetComponent<Slider>().value;
    //    internalHealth = internalHealth - 40;
    //    healthbar.GetComponent<Slider>().value = internalHealth;
    //    Assert.IsTrue(healthbar.GetComponent<Slider>().value == 60);

    //    //Evaluamos si el valor de healthbar puede ser mayor a 100
    //    internalHealth = 150;
    //    healthbar.GetComponent<Slider>().value = internalHealth;
    //    Assert.IsFalse(healthbar.GetComponent<Slider>().value > 100);

    //    //Evaluamos si el valor de healthbar puede ser menor a 0
    //    internalHealth = -50;
    //    healthbar.GetComponent<Slider>().value = internalHealth;
    //    Assert.IsFalse(healthbar.GetComponent<Slider>().value < 0);

    //    // Use yield to skip a frame.
    //    yield return null;
    //}

    [UnityTest]
    public IEnumerator TestAventura1HealthSystem()
    {
        //Se crea un GameObject que contenga la clase HealthSistema
        var eventSystem = new GameObject();
        eventSystem.AddComponent<HealthSistema>();
        var healthbar = new GameObject();
        healthbar.AddComponent<Slider>();
        var notaFinal = new GameObject();
        notaFinal.AddComponent<Text>();
        var GameOverUI = new GameObject();

        //Se inicializan los parametros de la clase HealthSistema con un maxHealth de 100 puntos de vida.
        eventSystem.GetComponent<HealthSistema>().maxHealth = 100;
        eventSystem.GetComponent<HealthSistema>().internalHealth = 0;
        eventSystem.GetComponent<HealthSistema>().healthBar = healthbar;
        eventSystem.GetComponent<HealthSistema>().NotaFinal = notaFinal;
        eventSystem.GetComponent<HealthSistema>().GameOverUI = GameOverUI;

        //Se crea un GameObject que contenga la clase VirusGlobal
        var virus = new GameObject();
        virus.AddComponent<VirusGlobal>();
        var explosion = new GameObject();
        var particulas = new GameObject().AddComponent<ParticleSystem>();

        //Se inicializan los parametros de la clase VirusGlobal
        virus.GetComponent<VirusGlobal>().vidaVirus = 1;
        virus.GetComponent<VirusGlobal>().InternalScore = 100;
        virus.GetComponent<VirusGlobal>().numVirusDeleted = 0;
        virus.GetComponent<VirusGlobal>().explosion = explosion;
        virus.GetComponent<VirusGlobal>().particulas = particulas.GetComponent<ParticleSystem>();

        //Si el virus está más de 5 segundos, empezará a quitar 10 puntos de vida
        //Se evaluará el valor actual del compontente HealthSistema al segundo 6
        yield return new WaitForSeconds(6);

        //Se evalua si realmente el virus quitó 10 puntos de vida.
        Assert.IsTrue(eventSystem.GetComponent<HealthSistema>().internalHealth == 90);

        //Se crea un GameObject que contenga la clase CelulaGlobal
        var aliado = new GameObject();
        aliado.AddComponent<CelulaGlobal>();

        //Se inicializan los parametros del componente CelulaGlobal
        aliado.GetComponent<CelulaGlobal>().vidaCelula = 1;
        aliado.GetComponent<CelulaGlobal>().InternalScore = 200;
        aliado.GetComponent<CelulaGlobal>().speed = 4;
        aliado.GetComponent<CelulaGlobal>().explosion = explosion;

        //Se elimina la celula
        aliado.GetComponent<CelulaGlobal>().isClicked();
        yield return new WaitForSeconds(1);

        //Se verifica si realmente la celula, al ser eliminada, quitó 10 puntos de vida.
        Assert.IsTrue(eventSystem.GetComponent<HealthSistema>().internalHealth == 80);

        //Se crea un GameObject que contenga la clase CorazonGlobal
        var corazon = new GameObject();
        corazon.AddComponent<CorazonGlobal>();

        //Se inicializan los parametros del componente CorazonGlobal
        corazon.GetComponent<CorazonGlobal>().vidaCorazon = 1;
        corazon.GetComponent<CorazonGlobal>().explosion = explosion;

        //Se usa o elimina el objeto corazon
        var oldHealth = eventSystem.GetComponent<HealthSistema>().internalHealth;
        corazon.GetComponent<CorazonGlobal>().isClicked();
        yield return new WaitForSeconds(1);

        //Se verifica si realmente el corazón aumento puntos de vida al jugador (De 80 puntos de vida a 100).
        Assert.IsTrue(oldHealth < eventSystem.GetComponent<HealthSistema>().internalHealth);
        //El objeto corazón da 40 puntos de vida pero no debe sobrepasar los 100 puntos de vida.
        Assert.IsTrue(eventSystem.GetComponent<HealthSistema>().internalHealth == 100);

        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura1STimeGlobal()
    {
        //Se crea un GameObject que contenga el compontente STimeGlobal
        var stimeglobal = new GameObject();
        stimeglobal.AddComponent<STimeGlobal>();
        var tiempoReal = new GameObject();
        tiempoReal.AddComponent<Text>();
        var puntajeFinal = new GameObject();
        puntajeFinal.AddComponent<Text>();
        var puntajeReal = new GameObject();
        puntajeReal.AddComponent<Text>();
        var finalUI = new GameObject();

        //Se inicializan los parametros del componente STimeGlobal con tiempo inicial 60 segundos
        stimeglobal.GetComponent<STimeGlobal>().timeStart = 60;
        stimeglobal.GetComponent<STimeGlobal>().TiempoReal = tiempoReal;
        stimeglobal.GetComponent<STimeGlobal>().finNivelUI = finalUI;
        stimeglobal.GetComponent<STimeGlobal>().puntajeNivelFinal = puntajeFinal;
        stimeglobal.GetComponent<STimeGlobal>().puntajeTotal = puntajeFinal;
        stimeglobal.GetComponent<STimeGlobal>().quitarTiempo = 10; //Si el jugador se equivoca de escenario

        //Se crea el componente PauseMenuSistema para que aparezca en el escenario
        var pauseMenu = new GameObject();
        pauseMenu.AddComponent<PauseMenuSistema>();
        var pauseMenuUI = new GameObject();

        //Se inicializan los parametros del componente VirusGlobal
        pauseMenu.GetComponent<PauseMenuSistema>().pauseMenuUI = pauseMenuUI;

        //Pausar el tiempo
        pauseMenu.GetComponent<PauseMenuSistema>().Pause();
        var oldTime = stimeglobal.GetComponent<STimeGlobal>().timeStart; //Se captura el tiempo actual
        Assert.AreEqual(oldTime, stimeglobal.GetComponent<STimeGlobal>().timeStart); // Se evalua si los valores son iguales

        //Reanudar el tiempo
        pauseMenu.GetComponent<PauseMenuSistema>().Resume();
        var newTime = stimeglobal.GetComponent<STimeGlobal>().timeStart; //Se captura el tiempo actual
        yield return new WaitForSeconds(5); //Se espera 5 segundos para evaluar si el tiempo cambia cuando está pausado
        Assert.AreNotEqual(newTime, stimeglobal.GetComponent<STimeGlobal>().timeStart); // Se evalua si los valores no son iguales

        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura1SScoreGlobal()
    {
        //Se crea un GameObject que contenga el compontente SScoreGlobal
        var eventSystem = new GameObject();
        eventSystem.AddComponent<SScoreGlobal>();
        var puntajeReal = new GameObject();
        puntajeReal.AddComponent<Text>();
        var eliminadosReal = new GameObject();
        eliminadosReal.AddComponent<Text>();

        //Se inicializan los parametros del componente SScoreGlobal 
        eventSystem.GetComponent<SScoreGlobal>().InternalScore = 0;
        eventSystem.GetComponent<SScoreGlobal>().InternalEliminados = 0;
        eventSystem.GetComponent<SScoreGlobal>().PuntajeReal = puntajeReal;
        eventSystem.GetComponent<SScoreGlobal>().EliminadosReal = eliminadosReal;

        //Se crea el GameObject virus para que aparezca en el escenario
        var virus = new GameObject();
        virus.AddComponent<VirusGlobal>();
        var explosion = new GameObject();
        var particulas = new GameObject().AddComponent<ParticleSystem>();

        //Se inicializan los parametros del componente VirusGlobal
        virus.GetComponent<VirusGlobal>().vidaVirus = 1;
        virus.GetComponent<VirusGlobal>().InternalScore = 100;
        virus.GetComponent<VirusGlobal>().numVirusDeleted = 0;
        virus.GetComponent<VirusGlobal>().explosion = explosion;
        virus.GetComponent<VirusGlobal>().particulas = particulas.GetComponent<ParticleSystem>();


        //Eliminar virus y ver si aumenta score
        var scoreInicial = eventSystem.GetComponent<SScoreGlobal>().InternalScore;
        virus.GetComponent<VirusGlobal>().vidaVirus=0;
        virus.GetComponent<VirusGlobal>().upScore();
        yield return new WaitForSeconds(1);
        Assert.IsTrue(scoreInicial < eventSystem.GetComponent<SScoreGlobal>().InternalScore);

        // Use yield to skip a frame.
        yield return null;
    }

        [SetUp]
    public void SetUp()
    {

    }

    [TearDown]
    public void TearDown()
    {

    }


}
