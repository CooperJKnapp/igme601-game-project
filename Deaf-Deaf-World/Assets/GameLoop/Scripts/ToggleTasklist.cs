using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleTasklist : MonoBehaviour
{
    public KeyCode _key;

    Button taskButton;

    [SerializeField]
    GameObject CheckListPanel;

    private void Awake()
    {
        taskButton = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            if (!taskButton.GetComponent<Image>().enabled)
            {
                CheckListPanel.SetActive(false);
                taskButton.GetComponent<Image>().enabled = true;
            }
            else
            {
                
                taskButton.GetComponent<Image>().enabled = false;
                CheckListPanel.SetActive(true);

            }
        }
    }
}
