using System;

namespace ConsoleApp2
{
    public delegate void OnMyEventHandler(object sender, EventArgs e);

   public class MyEvent
    {
        public event OnMyEventHandler MyEv;

        public void OnMyEvent()
        {
            if (MyEv != null)
            {
                MyEv(this, EventArgs.Empty);
            }
        }
    }

}