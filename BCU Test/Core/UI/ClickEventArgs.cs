using System;

namespace BCU_Test.Core.UI
{
    public class ClickEventArgs : EventArgs
    {
        public bool IsRight { get; private set; }
        public bool ShiftDown { get; private set; }
        public bool ControlDown { get; private set; }
        public ClickEventArgs(bool right, bool shift, bool control)
        {
            IsRight = right;
            ShiftDown = shift;
            ControlDown = control;
        }
    }
}
