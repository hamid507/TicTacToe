using TicTacToeSharedLib.Utility;

namespace TicTacToeGame
{
    public static class FormUtil
    {
        public static void UpdateControl(Control? control, object value, ControlUpdateType updateType, Form? form = null)
        {
            if (control == null && form == null) return;

            var update = () => { };

            switch (updateType)
            {
                case ControlUpdateType.Text:
                    {
                        update = () => { if (control != null) control.Text = (string)value; };
                        break;
                    }
                case ControlUpdateType.Visible:
                    {
                        update = () => { if (control != null) control.Visible = (bool)value; };
                        break;
                    }
                case ControlUpdateType.Enabled:
                    {
                        update = () => { if (control != null) control.Enabled = (bool)value; };
                        break;
                    }
                case ControlUpdateType.ControlBox:
                    {
                        update = () => { if (form != null) form.ControlBox = (bool)value; };
                        break;
                    }
                default: break;
            }

            if (control != null && control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)delegate { update(); });
            }
            else if (form != null && form.InvokeRequired)
            {
                form.Invoke((MethodInvoker)delegate { update(); });
            }
            else
            {
                update();
            }
        }
    }
}
