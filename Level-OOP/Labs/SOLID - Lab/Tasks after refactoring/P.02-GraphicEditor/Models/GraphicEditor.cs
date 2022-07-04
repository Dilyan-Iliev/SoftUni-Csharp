using P._02_GraphicEditor.Interfaces;

namespace P._02_GraphicEditor.Models
{
    public class GraphicEditor 
    {
        //In the future, new shapes could be added to the system
        public void DrawShape(IShape shape)
        {
            System.Console.WriteLine(shape.Draw());
        }
    }
}
