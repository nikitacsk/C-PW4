using System;
using ShapeContainerApp;
using System.Collections.Generic;
using System.Linq;

namespace ShapeContainerApp
{
    public class Sphere : Shape
    {
        public override string GetInfo()
        {
            return "This is a sphere";
        }
    }

    public class Cube : Shape
    {
        public override string GetInfo()
        {
            return "This is a cube";
        }
    }

    public class Pyramid : Shape
    {
        public override string GetInfo()
        {
            return "This is a pyramid";
        }
    }

    public class Prism : Shape
    {
        public override string GetInfo()
        {
            return "This is a prism";
        }
    }
    public class ShapeContainer : AbstractShapeContainer
    {
        private List<Shape> shapes;

        public ShapeContainer()
        {
            shapes = new List<Shape>();
        }

        public override string AddShape(Shape shape)
        {
            shapes.Add(shape);
            return "Shape added: " + shape.GetInfo();
        }

        public override string RemoveShape(int index)
        {
            if (index >= 0 && index < shapes.Count)
            {
                return "Shape removed: " + shapes[index].GetInfo();
            }
            else
            {
                return "Invalid index. Cannot remove shape.";
            }
        }

        public override string GetShapeInfo(int index)
        {
            if (index >= 0 && index < shapes.Count)
            {
                return shapes[index].GetInfo();
            }
            else
            {
                return "Invalid index. No shape found.";
            }
        }

        public override string GetAllShapesInfo()
        {
            if (shapes.Count == 0)
            {
                return "No shapes in the container.";
            }

            var shapeCounts = shapes.GroupBy(s => s.GetType().Name)
                                     .ToDictionary(g => g.Key, g => g.Count());

            string res = "";
            foreach (var shape in shapes)
            {
                res += "\n" +shape.GetInfo();
            }

            res += "\nSummary:";
            foreach (var pair in shapeCounts)
            {
                res += $"\n{pair.Key}: {pair.Value}";
            }
            return res;
        }
    }
}