using P._02_GraphicEditor.Interfaces;
using P._02_GraphicEditor.Models;

namespace P._02_GraphicEditor
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShape triangle = new Triangle();
            GraphicEditor ge = new GraphicEditor();
            ge.DrawShape(triangle);
        }
    }
}
