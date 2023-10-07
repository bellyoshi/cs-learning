namespace UiGraphics
{
    internal class GraphicsDrawable : IDrawable

    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            int offset_x = 100;
            int offset_y = 100;
            canvas.FillColor = Colors.DarkBlue;
            canvas.FillCircle(offset_x, offset_y, 80);
            canvas.StrokeColor = Colors.LightPink;
            double rad = 0;
            int r = 100;
            float x1 = offset_x + r;
            float y1 = offset_y + 0;
   

            for(int i = 0; i < 100; i++)
            {
                float x2 = (float)(Math.Cos(rad) * r) + offset_x;
                float y2 = (float)(Math.Sin(rad) * r) + offset_y;
                canvas.DrawLine(x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
                rad += Math.PI * (170.0 / 180.0);
            }

        }
    }
}
