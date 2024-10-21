using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class FortuneObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            UnityEngine.Debug.Log("Touched fortune!");

            var switchCommand = new SwitchToNovelMode { ScriptName = "FortuneConvo" };
            switchCommand.ExecuteAsync().Forget();
        }
    }
}
