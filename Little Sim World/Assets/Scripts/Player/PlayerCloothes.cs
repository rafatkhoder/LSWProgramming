using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloothes : MonoBehaviour
{
    public GameObject redHero, pinkHero, blueHero;
    public Animator redHeroAnim, pinkHeroAnim, blueHeroAnim;


    public void ChangeClothes(string selectedBody)
    {
        // Use a dictionary to map body names to objects
        Dictionary<string, GameObject> bodyDict = new Dictionary<string, GameObject>()
        {
            { GameStrings.RedHero, redHero },
            { GameStrings.PinkHero, pinkHero },
            { GameStrings.BlueHero, blueHero }
        };
        // Use another dictionary to map body names to animators
        Dictionary<string, Animator> animatorDict = new Dictionary<string, Animator>()
         {
             { GameStrings.RedHero, redHeroAnim },
             { GameStrings.PinkHero, pinkHeroAnim },
             { GameStrings.BlueHero, blueHeroAnim }
         };
        // Enable the object and animator corresponding to the selected body and disable the others
        foreach (KeyValuePair<string, GameObject> entry in bodyDict)
        {
            // Enable the object and animator if they match the selected body
            bool isSelected = entry.Key == selectedBody;
            entry.Value.SetActive(isSelected);
            animatorDict[entry.Key].enabled = isSelected;

            // Set the player's animator to the selected animator if they match
            if (isSelected)
            {
                Player.Instance.animator = animatorDict[entry.Key];
            }
        }
    }
  
}
