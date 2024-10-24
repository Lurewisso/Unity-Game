using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int Hp;
    public int MaxHp = 100;

    public int Experience  = 0;
    public int MaxExperience = 1000;
    public int Level = 1;
    public int Armor;
    public int MaxArmor  = 100;
    public int Money = 0;

    CharacterStats()
    {
       this.Hp = this.MaxHp;
   
    }


}
