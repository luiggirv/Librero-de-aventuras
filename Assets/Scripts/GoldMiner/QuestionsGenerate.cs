using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsGenerate : MonoBehaviour
{
    public class PreguntasAcuaticos
    {
        public string pregunta { get; set; }
        public string respuesta1 { get; set; }
        public string respuesta2 { get; set; }
        public string respuesta3 { get; set; }
        public string respuesta4 { get; set; }

        public int numRespuesta { get; set; }
    }

    static PreguntasAcuaticos[] preguntasAc = { new PreguntasAcuaticos 
                                                { 
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes objetos es contaminante para un ecosistema acu�tico?", 
                                                    respuesta1 = "Sustancias t�xicas", 
                                                    respuesta2 = "Algas marinas", 
                                                    respuesta3 = "Rocas",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes seres acu�ticos es un depredador?",
                                                    respuesta1 = "Pez Payaso",
                                                    respuesta2 = "Tibur�n",
                                                    respuesta3 = "Estrella de mar",
                                                    respuesta4 = "Caballito de mar",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes residuos marinos NO es reciclable?",
                                                    respuesta1 = "Sustancias qu�micas",
                                                    respuesta2 = "Latas de comida",
                                                    respuesta3 = "Botellas de vidrio y pl�stico",
                                                    respuesta4 = "Bolsas de pl�stico",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales NO es vertebrado?",
                                                    respuesta1 = "Pez Espada",
                                                    respuesta2 = "Rana",
                                                    respuesta3 = "Tibur�n",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales acu�ticos es el m�s grande?",
                                                    respuesta1 = "Estrella de mar",
                                                    respuesta2 = "Pez Espada",
                                                    respuesta3 = "Ballena",
                                                    respuesta4 = "Tibur�n",
                                                    numRespuesta = 3
                                                },
                                                };



    public PreguntasAcuaticos DevolverPreguntasActuaticos()
    {
        var rand = new System.Random();
        int index = rand.Next(0, preguntasAc.Length);
        //Debug.Log(index +": " + preguntasAc[index].pregunta);
        return preguntasAc[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
