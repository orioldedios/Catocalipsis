using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopper : MonoBehaviour
{
    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PopText(string content)
        {
            // Set the text content
            textComponent.text = content;
        }
}
