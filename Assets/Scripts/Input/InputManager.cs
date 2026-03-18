using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoSingleton<InputManager>
{
    [SerializeField] InputActionAsset inputActionAsset;

    KeyActionDictionary dictionary;
    bool inputEnabled = true;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void InitStatic()
    {
        ShuttingDown = false;
    }

    void Awake()
    {
        dictionary = new KeyActionDictionary();
        dictionary.Init(inputActionAsset);

        EventManager.StartListening(Event.DisableInput, DisableInput);
        EventManager.StartListening(Event.EnableInput, EnableInput);
    }

    void Update()
    {
        if (inputEnabled) dictionary.Check();
    }

    public void StartListen(KeyCode keycode, Action<InputState> action) => dictionary.StartListen(keycode, action);
    public void StartListen(KeyActionType type, Action<InputState> action) => dictionary.StartListen(type, action);
    public void StopListen(KeyCode keycode, Action<InputState> action) => dictionary.StopListen(keycode, action);
    public void StopListen(KeyActionType type, Action<InputState> action) => dictionary.StopListen(type, action);

    void DisableInput() => inputEnabled = false;
    void EnableInput() => inputEnabled = true;

    void OnDestroy()
    {
        EventManager.StopListening(Event.DisableInput, DisableInput);
        EventManager.StopListening(Event.EnableInput, EnableInput);
    }
}
