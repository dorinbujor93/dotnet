namespace OpenClosedDrawingShapesBefore
{
    using OpenClosedDrawingShapesBefore.Contracts;

    public class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            shape.Draw();
        }   
    }
}
