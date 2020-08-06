using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject MainP;
    [SerializeField] GameObject LevelP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ReturnToMain()
    {
        LevelP.SetActive(false);
        MainP.SetActive(true);
    }
    public void OpenTheLevels()
    {
        LevelP.SetActive(true);
        MainP.SetActive(false);
    }
    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
