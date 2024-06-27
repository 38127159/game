using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ui : MonoBehaviour
{
    public TMP_Text score;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = n.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        n = 0;
        score.text = n.ToString();
    }

    public void AddScore()
    {
        n++;
        score.text = n.ToString();
    }
}
