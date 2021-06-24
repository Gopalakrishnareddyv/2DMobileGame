using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoretext;
    int updatedscore = 0;
    public void Increment()
    {

        updatedscore++;
        scoretext.text = "" + updatedscore;
    }
}
