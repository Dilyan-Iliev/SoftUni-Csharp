using System;
using MainTask.Layouts;
using MainTask.Layouts.Interfaces;

namespace MainTask.Factory
{
    public class LayoutFactory
    {
        public ILayout Create(string type)
        {
            ILayout layout = null;

            if (type == nameof(SimpleLayout))
            {
                layout = new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid Layout type");
            }

            return layout;
        }
    }
}
