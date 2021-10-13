using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    public static SpeechManager instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    [System.Serializable]
    public class Elements
    {
        public GameObject speechPanel;
        public Text speech;
        public Text speekerName;

    }
}
