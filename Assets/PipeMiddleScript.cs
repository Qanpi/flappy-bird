using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    private void Awake()
    {
        logic = FindObjectOfType<LogicScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.AddScore();
    }

}
