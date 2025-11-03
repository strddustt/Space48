using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;
    // Start is called before the first frame update
    void Start()
    {
        Introduction();
    }

    private void Introduction()
    {
        string text = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
        DisplayText(text, 5);
    }
    public IEnumerator DisplayText(string text, float time)
    {
        messageField.enabled = true;
        messageField.text = text;
        yield return new WaitForSeconds(time);
        messageField.enabled = false;
    }
}
