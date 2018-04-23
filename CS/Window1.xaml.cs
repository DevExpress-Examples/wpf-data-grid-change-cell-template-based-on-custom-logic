using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using System.ComponentModel;

namespace EditorsDesignTime {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            List<TestData> list = new List<TestData>();
            for (int i = 0; i < 100; i++)
                list.Add(new TestData() { Editor = GetEditorType(i), Value = GetEditValue(i) });
            grid.ItemsSource = list;
        }
        string GetEditorType(int index) {
            switch (index % 6) {
                case 0:
                    return "booleanEditor";
                case 1:
                    return "buttonEditor";
                case 2:
                    return "comboboxEditor";
                case 3:
                    return "dateEditor";
                case 4:
                    return "textEditor";
                default:
                    return string.Empty;
            }
        }
        object GetEditValue(int index) {
            switch (index % 6) {
                case 0:
                    return index % 2 == 0;
                case 1:
                    return "button edit " + index;
                case 2:
                    return index % 2 == 0 ? Alignment.Far : Alignment.Near;
                case 3:
                    return DateTime.Today.AddDays(index);
                case 4:
                    return "text " + index;
                default:
                    return string.Empty;
            }
        }
    }
    public class TestData {
        public string Editor { get; set; }
        public object Value { get; set; }
    }
    public class EditorTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            GridCellData data = (GridCellData)item;
            PropertyDescriptor property = TypeDescriptor.GetProperties(data.Data)["Editor"];
            if (property == null)
                return null;
            string editorType = property.GetValue(data.Data) as string;
            return string.IsNullOrEmpty(editorType) ? null : (DataTemplate)((FrameworkElement)container).FindResource(editorType);
        }
    }
}