using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MisheGame");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
