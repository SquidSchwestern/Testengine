using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Testengine
{
     class animate
    {
        List<Image> frames = new List<Image>();
        int increment = 0;
        int DelayCount = 0;
        public void AddFrame(Image frame)
        {
            frames.Add(frame);
        }
        int delay = 10;
        public Image PlayOneFrame()
        {
            DelayCount++;
            if (DelayCount % delay == 0)
            {
                increment = (increment == frames.Count) ? 0 : increment + 1;
            }
            return frames[increment - 1];
        }
    }
}
