using UnityEngine;

namespace UI
{
    public class BackWindow : Window
    {
        [SerializeField] private Window[] _windows;

        private void Awake()
        {
            foreach (var window in _windows)
            {
                window.OnStartOpen += Close;
                window.OnEndClose += Open;
            }
        }

        private void OnDestroy()
        {
            foreach (var window in _windows)
            {
                window.OnStartOpen -= Close;
                window.OnEndClose -= Open;
            }
        }
    }
}
