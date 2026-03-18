using System.Collections.Generic;

public class WindowManager : MonoSingleton<WindowManager>
{
    readonly Stack<EscapableWindow> stack = new();

    public void Push(EscapableWindow window)
    {
        stack.Push(window);
    }

    void TryPop()
    {
        EscapableWindow window = stack.Peek();

        if (window != null && !window.Busy)
        {
            stack.Pop();
            window.Hide();
        }
    }

    void Start()
    {
        InputManager.Instance.StartListen(KeyActionType.Escape, OnEscape);
    }

    void OnDestroy()
    {
        InputManager.Instance.StopListen(KeyActionType.Escape, OnEscape);
    }

    void OnEscape(InputState state)
    {
        if (state == InputState.Down) TryPop();
    }
}
