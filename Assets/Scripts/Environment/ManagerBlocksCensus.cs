using System.Collections.Generic;
using UnityEngine;

public static class ManagerBlocksCensus 
{
    private static LinkedList<GameObject> _blocks = new ();

    //TODO при смене сцены очищать список
    public static void ClearList()
    {
        _blocks.Clear();
    }
    
    public static void AddBlock(GameObject block)
    {
        _blocks.AddLast(block);
    }

    public static void RemoveBlock(GameObject block)
    {
        _blocks.Remove(block);
    }

    public static GameObject TryGetBlockByPosition(Vector3 position)
    {
        foreach (GameObject block in _blocks)
        {
            if (block.transform.position == position)
                return block;
        }

        return null;
    }
}
