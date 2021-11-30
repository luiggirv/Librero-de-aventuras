using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;

public class TestIntegracion
{

    [UnityTest]
    public IEnumerator TestIntegracionTotal()
    {
        Assert.IsNotNull(PlayerPrefs.GetString("TutorialSistemas"));
        Assert.IsNotNull(PlayerPrefs.GetString("isRespiratorio"));
        Assert.IsNotNull(PlayerPrefs.GetString("isPulmonIzq"));
        Assert.IsNotNull(PlayerPrefs.GetString("isPulmonDer"));
        Assert.IsNotNull(PlayerPrefs.GetString("isTraquea"));
        Assert.IsNotNull(PlayerPrefs.GetString("isFosas"));

        Assert.IsNotNull(PlayerPrefs.GetString("isNervioso"));
        Assert.IsNotNull(PlayerPrefs.GetString("isEncefalo"));
        Assert.IsNotNull(PlayerPrefs.GetString("isNervios"));
        Assert.IsNotNull(PlayerPrefs.GetString("isMedula"));
        Assert.IsNotNull(PlayerPrefs.GetString("isGanglios"));

        Assert.IsNotNull(PlayerPrefs.GetString("isCirculatorio"));
        Assert.IsNotNull(PlayerPrefs.GetString("isArterias"));
        Assert.IsNotNull(PlayerPrefs.GetString("isVenas"));
        Assert.IsNotNull(PlayerPrefs.GetString("isCorazon"));
        Assert.IsNotNull(PlayerPrefs.GetString("isCapilares"));

        Assert.IsNotNull(PlayerPrefs.GetString("TutorialMetodo"));
        Assert.IsNotNull(PlayerPrefs.GetString("MostrarFases"));


        Assert.IsNotNull(PlayerPrefs.GetString("TutorialEcosistemas"));
        Assert.IsNotNull(PlayerPrefs.GetString("isBosque"));

        Assert.IsNotNull(PlayerPrefs.GetString("isLago"));
        Assert.IsNotNull(PlayerPrefs.GetString("isReciclaje"));
        Assert.IsNotNull(PlayerPrefs.GetString("isAcuaticos"));

        Assert.IsNotNull(PlayerPrefs.GetString("isMontaña"));
        Assert.IsNotNull(PlayerPrefs.GetString("isVerano"));
        Assert.IsNotNull(PlayerPrefs.GetString("isOtoño"));
        Assert.IsNotNull(PlayerPrefs.GetString("isInvierno"));
        Assert.IsNotNull(PlayerPrefs.GetString("isPrimavera"));

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
