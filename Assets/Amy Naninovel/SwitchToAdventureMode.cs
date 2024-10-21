using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;

[CommandAlias("adventure")]
public class SwitchToAdventureMode : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken)
    {
        // 1. Disable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        // 2. Stop script player.
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // 3. Reset state.
        var stateManager = Engine.GetService<IStateManager>();
        await stateManager.ResetStateAsync();

        // // 4. Switch cameras.
        // var advCamera = GameObject.Find("AdvCamera").GetComponent<Camera>();
        // advCamera.enabled = true;
        // var naniCamera = Engine.GetService<ICameraManager>().Camera;
        // naniCamera.enabled = false;

        // 5. Enable character control.
        var controller = Object.FindObjectOfType<PlayerController>();
        controller.IsInputBlocked = false;
    }
}
