using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetNameInput(string value)
    {
        DataManager.Instance.playerName = value;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }    
}
