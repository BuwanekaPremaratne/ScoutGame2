using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour
{
    public static List<Notes> notes = new List<Notes>()
    {
        new Notes("n1","What is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of FranceWhat is the capital of France ","Note 1"),
        new Notes("n2","What is the capital of England","Note 2"),
        new Notes("n3","What is the capital of England","Note 3"),
        new Notes("n4","What is the capital of England","Note 4"),
        new Notes("n5","What is the capital of England","Note 5")
        
    };
}
