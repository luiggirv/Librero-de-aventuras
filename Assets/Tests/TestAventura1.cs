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
    [Test]
    public void TestAventura1SimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestAventura1HealthBar()
    {
        //Creamos el objecto HealthBar
        var healthbar = new GameObject().AddComponent<Slider>();

        //Inicializamos parametros
        healthbar.GetComponent<Slider>().minValue = 0;
        healthbar.GetComponent<Slider>().maxValue = 100;
        healthbar.GetComponent<Slider>().value = 100;
        float internalHealth;

        //Evaluamos si el valor se actualiza
        internalHealth = healthbar.GetComponent<Slider>().value;
        internalHealth = internalHealth - 40;
        healthbar.GetComponent<Slider>().value = internalHealth;
        Assert.IsTrue(healthbar.GetComponent<Slider>().value == 60);

        //Evaluamos si el valor de healthbar puede ser mayor a 100
        internalHealth = 150;
        healthbar.GetComponent<Slider>().value = internalHealth;
        Assert.IsFalse(healthbar.GetComponent<Slider>().value > 100);

        //Evaluamos si el valor de healthbar puede ser menor a 0
        internalHealth = -50;
        healthbar.GetComponent<Slider>().value = internalHealth;
        Assert.IsFalse(healthbar.GetComponent<Slider>().value < 0);

        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura1HealthSystem()
    {
        //Se crea un GameObject que contenga el compontente HealthSistema
        var eventSystem = new GameObject();
        eventSystem.AddComponent<HealthSistema>();
        var healthbar = new GameObject();
        healthbar.AddComponent<Slider>();
        var notaFinal = new GameObject();
        notaFinal.AddComponent<Text>();
        var GameOverUI = new GameObject();

        //Se inicializan los parametros del componente HealthSistema con un maxHealth de 100 puntos de vida.
        eventSystem.GetComponent<HealthSistema>().maxHealth = 100;
        eventSystem.GetComponent<HealthSistema>().internalHealth = 0;
        eventSystem.GetComponent<HealthSistema>().healthBar = healthbar;
        eventSystem.GetComponent<HealthSistema>().NotaFinal = notaFinal;
        eventSystem.GetComponent<HealthSistema>().GameOverUI = GameOverUI;

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

        //Si el virus está más de 5 segundos, empezará a quitar 10 puntos de vida
        //Se evaluará el valor actual del compontente HealthSistema al segundo 6
        yield return new WaitForSeconds(6);

        //Se evalua si realmente el virus quitó 10 puntos de vida.
        Assert.IsTrue(eventSystem.GetComponent<HealthSistema>().internalHealth == 90);

        //Se crea el GameObject virus para que aparezca en el escenario
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
