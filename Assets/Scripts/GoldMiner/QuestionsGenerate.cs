using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsGenerate : MonoBehaviour
{
    public class PreguntasAcuaticos
    {
        public string pregunta { get; set; } //Pregunta que se mostrará en la pantalla
        public string respuesta1 { get; set; } //Respuesta corta como alternativa (Maximo de 20 caracteres)
        public string respuesta2 { get; set; }
        public string respuesta3 { get; set; }
        public string respuesta4 { get; set; }

        public int numRespuesta { get; set; } //El número de la alternativa que tiene la respuesta correcta (Número entre el 1 al 4)
    }

    static PreguntasAcuaticos[] preguntasAc = { new PreguntasAcuaticos 
                                                { 
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes animales es un animal acuatico?", 
                                                    respuesta1 = "Caracol", 
                                                    respuesta2 = "Loro", 
                                                    respuesta3 = "Tortuga marina",
                                                    respuesta4 = "Mono",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes seres acuáticos es un depredador?",
                                                    respuesta1 = "Pez Payaso",
                                                    respuesta2 = "Tiburón",
                                                    respuesta3 = "Estrella de mar",
                                                    respuesta4 = "Caballito de mar",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál animal acuático es el más inteligente?",
                                                    respuesta1 = "Estrella de mar",
                                                    respuesta2 = "Pulpo",
                                                    respuesta3 = "Delfín",
                                                    respuesta4 = "Orca",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes animales es invertebrado?",
                                                    respuesta1 = "Pez Espada",
                                                    respuesta2 = "Rana",
                                                    respuesta3 = "Tiburón",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes animales acuáticos es el más grande del océano?",
                                                    respuesta1 = "Estrella de mar",
                                                    respuesta2 = "Pez Espada",
                                                    respuesta3 = "Ballena",
                                                    respuesta4 = "Tiburón",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuántos brazos tienen las estrellas de mar?",
                                                    respuesta1 = "Cuatro",
                                                    respuesta2 = "Cinco",
                                                    respuesta3 = "Tres",
                                                    respuesta4 = "Seis",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Por dónde respiran los peces?",
                                                    respuesta1 = "Branquias",
                                                    respuesta2 = "Aletas",
                                                    respuesta3 = "Cola",
                                                    respuesta4 = "Pulmones",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes animales marinos es ovíparo?",
                                                    respuesta1 = "Ballena",
                                                    respuesta2 = "Delfín",
                                                    respuesta3 = "Pez payaso",
                                                    respuesta4 = "Foca",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuántos tentáculos tiene un pulpo?",
                                                    respuesta1 = "Ocho",
                                                    respuesta2 = "Nueve",
                                                    respuesta3 = "Seis",
                                                    respuesta4 = "Siete",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Qué animal acuático es mamífero y respira por los pulmones?",
                                                    respuesta1 = "Pez payaso",
                                                    respuesta2 = "Delfín",
                                                    respuesta3 = "Caballito de mar",
                                                    respuesta4 = "Pulpo",
                                                    numRespuesta = 2
                                                },
     };

    static PreguntasAcuaticos[] preguntasReciclar = { new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes objetos es contaminante para un ecosistema acuático?",
                                                    respuesta1 = "Sustancias químicas",
                                                    respuesta2 = "Algas marinas",
                                                    respuesta3 = "Rocas",
                                                    respuesta4 = "Estrella de mar",
                                                    numRespuesta = 1
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes residuos marinos NO es reciclable?",
                                                    respuesta1 = "Bolsas de plástico",
                                                    respuesta2 = "Latas de comida",
                                                    respuesta3 = "Botellas de vidrio y plástico",
                                                    respuesta4 = "Sustancias químicas",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuál de los siguientes objetos no es reciclable?",
                                                    respuesta1 = "Papel",
                                                    respuesta2 = "Botellas de vidrio",
                                                    respuesta3 = "Cartón",
                                                    respuesta4 = "Desechos de comida",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Qué objetos se meten en un contenedor de reciclaje de color verde?",
                                                    respuesta1 = "Resíduos Orgánicos",
                                                    respuesta2 = "Envases de plástico",
                                                    respuesta3 = "Papel y cartón",
                                                    respuesta4 = "Vidrio",
                                                    numRespuesta = 4
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Qué objetos se meten en un contenedor de reciclaje de color azul?",
                                                    respuesta1 = "Resíduos Orgánicos",
                                                    respuesta2 = "Papel y cartón",
                                                    respuesta3 = "Vidrio",
                                                    respuesta4 = "Envases de plástico",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Qué objetos se meten en un contenedor de reciclaje de color amarillo?",
                                                    respuesta1 = "Vidrio",
                                                    respuesta2 = "Papel y cartón",
                                                    respuesta3 = "Envases de plástico",
                                                    respuesta4 = "Resíduos Orgánicos",
                                                    numRespuesta = 3
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿En qué color de contenedor de reciclaje van los residuos orgánicos?",
                                                    respuesta1 = "Verde",
                                                    respuesta2 = "Gris",
                                                    respuesta3 = "Amarillo",
                                                    respuesta4 = "Marrón",
                                                    numRespuesta = 2
                                                },
                                                new PreguntasAcuaticos
                                                {
                                                    pregunta = "Pregunta:\n¿Cuánto tarda en descomponerse una botella de plástico?",
                                                    respuesta1 = "100 años",
                                                    respuesta2 = "20 años",
                                                    respuesta3 = "5 años",
                                                    respuesta4 = "Más de 450 años",
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
