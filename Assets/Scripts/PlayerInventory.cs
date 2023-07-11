using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCubes { get; private set; }

    public UnityEvent<PlayerInventory> OnBoxCollected;
    public void CubesCollected()
    {
        NumberOfCubes++;
        OnBoxCollected.Invoke(this);
    }
}
