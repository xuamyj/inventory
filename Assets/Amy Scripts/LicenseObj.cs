using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

public class LicenseObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RunPreloadAndPlay()
    {
        // var player = Engine.GetService<IScriptPlayer>();
        // await player.PreloadAndPlayAsync("LicenseConvo");

        var switchCommand = new SwitchToNovelMode { ScriptName = "LicenseConvo" };
        switchCommand.ExecuteAsync().Forget();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            UnityEngine.Debug.Log("Touched license!");

            RunPreloadAndPlay();
        }
    }
}
