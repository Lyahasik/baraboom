using System.Collections.Generic;
using UnityEngine;

//TODO при смене сцены очищать список
public static class ManagerBlocksCensus 
{
    private static LinkedList<GameObject> _blocks = new ();

    public static void AddBlock(GameObject block)
    {
        _blocks.AddLast(block);
    }
}
