using System;

namespace ShapeContainerApp
{
    public abstract class Shape
    {
        public abstract string GetInfo();
    }

    public abstract class AbstractShapeContainer
    {
        public abstract string AddShape(Shape shape);
        public abstract string RemoveShape(int index);
        public abstract string GetShapeInfo(int index);
        public abstract string GetAllShapesInfo();
    }
}