using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player - qurbani janwar class
public class Player : MonoBehaviour
{
    [SerializeField] private string Name; // name of the player
    private int _lives; // total lives the player has, by default this will be = 3 at the start of each level
    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
        }
    }
    [SerializeField] private string Type; // can be from [goat, sheep, dumba, cow, bull, camel, etc.]
    [SerializeField] private int _speed; // speed of the animal, different type of animal has different speed
    public int Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

}
