using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUP : MonoBehaviour , IPickUpObject
{
    [SerializeField] int count;

    public void OnPickUp(Character character)
    {
        character.coins.Add(count);
    }
}
