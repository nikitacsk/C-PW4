using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using ShapeContainerApp;

namespace Avaloniacsh
{
    public partial class MainWindow : Window
    {
        private TextBox indexTextBox;
        private TextBox shapeTypeTextBox;
        private TextBlock outputTextBlock;
        private ShapeContainer shapeContainer;

        public MainWindow()
        {
            InitializeComponent();
            shapeContainer = new ShapeContainer();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            indexTextBox = this.FindControl<TextBox>("IndexTextBox");
            shapeTypeTextBox = this.FindControl<TextBox>("ShapeTypeTextBox");
            outputTextBlock = this.FindControl<TextBlock>("OutputTextBlock");

            this.FindControl<Button>("AddButton").Click += AddButton_Click;
            this.FindControl<Button>("RemoveButton").Click += RemoveButton_Click;
            this.FindControl<Button>("GetShapeInfoButton").Click += GetShapeInfoButton_Click;
            this.FindControl<Button>("GetAllShapesInfoButton").Click += GetAllShapesInfoButton_Click;
        }

        private void AddButton_Click(object? sender, RoutedEventArgs e)
        {
            string shapeType = shapeTypeTextBox.Text?.Trim();

            Shape? shape = shapeType?.ToLower() switch
            {
                "sphere" => new Sphere(),
                "cube" => new Cube(),
                "pyramid" => new Pyramid(),
                "prism" => new Prism(),
                _ => null
            };

            if (shape != null)
            {
                string result = shapeContainer.AddShape(shape);
                outputTextBlock.Text = result;
            }
            else
            {
                outputTextBlock.Text = "Invalid shape type. Use: Sphere, Cube, Pyramid, or Prism.";
            }
        }

        private void RemoveButton_Click(object? sender, RoutedEventArgs e)
        {
            if (int.TryParse(indexTextBox.Text, out int index))
            {
                string result = shapeContainer.RemoveShape(index);
                outputTextBlock.Text = result;
            }
            else
            {
                outputTextBlock.Text = "Invalid index.";
            }
        }

        private void GetShapeInfoButton_Click(object? sender, RoutedEventArgs e)
        {
            if (int.TryParse(indexTextBox.Text, out int index))
            {
                string result = shapeContainer.GetShapeInfo(index);
                outputTextBlock.Text = result;
            }
            else
            {
                outputTextBlock.Text = "Invalid index.";
            }
        }

        private void GetAllShapesInfoButton_Click(object? sender, RoutedEventArgs e)
        {
            string result = shapeContainer.GetAllShapesInfo();
            outputTextBlock.Text = result;
        }
    }
}
