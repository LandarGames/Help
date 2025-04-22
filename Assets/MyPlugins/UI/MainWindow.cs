using UnityEngine;
using UI;

public class MainWindow : Window
{
    [SerializeField] private Window[] _windows;

    private void Awake()
    {
        OnStartOpen += () => 
        {
            foreach (var window in _windows)
                window.SetActive(false, 0);
        };
    }
}
