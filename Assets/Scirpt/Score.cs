using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score_textholder;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        score_textholder.text = score.ToString();
        if (score >= 911)
        {
            score = score-score + 911;
            Invoke(nameof(Ending),3.0f);
        }
    }
    void Ending()
    {
        SceneManager.LoadScene("Credit");
    }

}
