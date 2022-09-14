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
    [SerializeField] private float _speed; // speed of the animal, different type of animal has different speed
    public float Speed
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
    public enum PlayerState
    {
        Dead,
        Alive,
        Survived
    };
    private PlayerState _currentState = PlayerState.Alive;
    public PlayerState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _currentState = value;
        }
    }

}
