using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUpObject : MonoBehaviour , IPickUpObject
{

    [SerializeField] int healAmount;
   public void OnPickUp(Character character)
    {
        character.Heal(healAmount);
    }
}
