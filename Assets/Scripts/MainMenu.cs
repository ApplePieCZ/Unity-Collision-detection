// VGE - collision detection in 3D
// Lukas Marek, 01.05.2023
// Script for main menu and scene loading

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
    
    public void LoadScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
    
    public void LoadScene3()
    {
        SceneManager.LoadScene("Scene3");
    }
    
    public void LoadScene4()
    {
        SceneManager.LoadScene("Scene4");
    }
    
    public void LoadScene5()
    {
        SceneManager.LoadScene("Scene5");
    }
    
    public void LoadScene6()
    {
        SceneManager.LoadScene("Scene6");
    }
    
    public void LoadScene7()
    {
        SceneManager.LoadScene("Scene7");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
