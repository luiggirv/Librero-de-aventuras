using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsGenerate : MonoBehaviour
{
    public class PreguntasAcuaticos
    {
        public string pregunta { get; set; } //Pregunta que se mostrar� en la pantalla
        public string respuesta1 { get; set; } //Respuesta corta como alternativa (Maximo de 20 caracteres)
        public string respuesta2 { get; set; }
        public string respuesta3 { get; set; }
        public string respuesta4 { get; set; }

        public int numRespuesta { get; set; } //El n�mero de la alternativa que tiene la respuesta correcta (N�mero entre el 1 al 4)
    }

    static PreguntasAcuaticos[] preguntasAc = { new PreguntasAcuaticos 
                                                { 
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales es un animal acuatico?", 
                                                    respuesta1 = "Caracol", 
                                                    respuesta2 = "Loro", 
                                                    respuesta3 = "Tortuga marina",
                                                    respuesta4 = "Mono",
                                                    numRespuesta = 3
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
                                                    pregunta = "Pregunta:\n�Cu�l animal acu�tico es el m�s inteligente?",
                                                    respuesta1 = "Estrella de mar",
                                                    respuesta2 = "Pulpo",
                                                    respuesta3 = "Delf�n",
                                                    respuesta4 = "Orca",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales es invertebrado?",
                                                    respuesta1 = "Pez Espada",
                                                    respuesta2 = "Rana",
                                                    respuesta3 = "Tibur�n",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales acu�ticos es el m�s grande del oc�ano?",
                                                    respuesta1 = "Estrella de mar",
                                                    respuesta2 = "Pez Espada",
                                                    respuesta3 = "Ballena",
                                                    respuesta4 = "Tibur�n",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�ntos brazos tienen las estrellas de mar?",
                                                    respuesta1 = "Cuatro",
                                                    respuesta2 = "Cinco",
                                                    respuesta3 = "Tres",
                                                    respuesta4 = "Seis",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Por d�nde respiran los peces?",
                                                    respuesta1 = "Branquias",
                                                    respuesta2 = "Aletas",
                                                    respuesta3 = "Cola",
                                                    respuesta4 = "Pulmones",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes animales marinos es ov�paro?",
                                                    respuesta1 = "Ballena",
                                                    respuesta2 = "Delf�n",
                                                    respuesta3 = "Pez payaso",
                                                    respuesta4 = "Foca",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�ntos tent�culos tiene un pulpo?",
                                                    respuesta1 = "Ocho",
                                                    respuesta2 = "Nueve",
                                                    respuesta3 = "Seis",
                                                    respuesta4 = "Siete",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Qu� animal acu�tico es mam�fero y respira por los pulmones?",
                                                    respuesta1 = "Pez payaso",
                                                    respuesta2 = "Delf�n",
                                                    respuesta3 = "Caballito de mar",
                                                    respuesta4 = "Pulpo",
                                                    numRespuesta = 2
                                                },
     };

    static PreguntasAcuaticos[] preguntasReciclar = { new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes objetos es contaminante para un ecosistema acu�tico?",
                                                    respuesta1 = "Sustancias qu�micas",
                                                    respuesta2 = "Algas marinas",
                                                    respuesta3 = "Rocas",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes residuos marinos NO es reciclable?",
                                                    respuesta1 = "Bolsas de pl�stico",
                                                    respuesta2 = "Latas de comida",
                                                    respuesta3 = "Botellas de vidrio y pl�stico",
                                                    respuesta4 = "Sustancias qu�micas",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�l de los siguientes objetos no es reciclable?",
                                                    respuesta1 = "Papel",
                                                    respuesta2 = "Botellas de vidrio",
                                                    respuesta3 = "Cart�n",
                                                    respuesta4 = "Desechos de comida",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Qu� objetos se meten en un contenedor de reciclaje de color verde?",
                                                    respuesta1 = "Res�duos Org�nicos",
                                                    respuesta2 = "Envases de pl�stico",
                                                    respuesta3 = "Papel y cart�n",
                                                    respuesta4 = "Vidrio",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Qu� objetos se meten en un contenedor de reciclaje de color azul?",
                                                    respuesta1 = "Res�duos Org�nicos",
                                                    respuesta2 = "Papel y cart�n",
                                                    respuesta3 = "Vidrio",
                                                    respuesta4 = "Envases de pl�stico",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Qu� objetos se meten en un contenedor de reciclaje de color amarillo?",
                                                    respuesta1 = "Vidrio",
                                                    respuesta2 = "Papel y cart�n",
                                                    respuesta3 = "Envases de pl�stico",
                                                    respuesta4 = "Res�duos Org�nicos",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�En qu� color de contenedor de reciclaje van los residuos org�nicos?",
                                                    respuesta1 = "Verde",
                                                    respuesta2 = "Gris",
                                                    respuesta3 = "Amarillo",
                                                    respuesta4 = "Marr�n",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n�Cu�nto tarda en descomponerse una botella de pl�stico?",
                                                    respuesta1 = "100 a�os",
                                                    respuesta2 = "20 a�os",
                                                    respuesta3 = "5 a�os",
                                                    respuesta4 = "M�s de 450 a�os",
                                                    numRespuesta = 4
                                                },
};



    public PreguntasAcuaticos DevolverPreguntasActuaticos()
    {
        var rand = new System.Random();
        int index = rand.Next(0, preguntasAc.Length);
        //Debug.Log(index +": " + preguntasAc[index].pregunta);
        return preguntasAc[index];
    }

    public PreguntasAcuaticos DevolverPreguntasReciclaje()
    {
        var rand = new System.Random();
        int index = rand.Next(0, preguntasReciclar.Length);
        //Debug.Log(index +": " + preguntasAc[index].pregunta);
        return preguntasReciclar[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
