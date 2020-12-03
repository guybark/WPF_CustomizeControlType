using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace WPF_CustomizeControlType
{
    public class MyCustomButton : Button
    {
        private MyCustomButtonAutomationPeer peer;

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            if (this.peer == null)
            {
                this.peer = new MyCustomButtonAutomationPeer(this);
            }

            return this.peer;
        }
    }

    public class MyCustomButtonAutomationPeer : ButtonAutomationPeer
    {
        public MyCustomButtonAutomationPeer(MyCustomButton owner) : base(owner)
        {
        }

        // If there's a known AutomationControlType that's a good semantic match for the control,
        // use it. And then you DON'T need to override GetLocalizedControlTypeCore(). 
        
        // But if there's no good semantic match in AutomationControlType, return Custom, and also
        // return a helpful localized string GetLocalizedControlTypeCore(). Whatever gets returned 
        // from GetLocalizedControlTypeCore() will get announced by Narrator.

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Custom;
        }

        protected override string GetLocalizedControlTypeCore()
        {
            return "Status indicator"; // TODO: Localized this!
        }

        // Don't need to override this if AutomationProperties.Name is set to the localized status in XAML.
        protected override string GetNameCore()
        {
            return "Connection lost"; // This is an example. Localize whatever's returner here.
        }
    }
}
