using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text vida;
    public int maxLife = 50;
    public int currentLife;

    private void Start()
    {
        currentLife = maxLife;
    } 
    private void Update()
    {
        vida.text = currentLife.ToString();
    }
}
