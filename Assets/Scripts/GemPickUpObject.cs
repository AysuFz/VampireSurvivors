using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] int amount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
