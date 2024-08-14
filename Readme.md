<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648629/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2017)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WPF Data Grid - Change a Cell Template Based on Custom Logic

This example demonstrates how to use the [CellTemplateSelector](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplateSelector) property to change a cell template based on a condition.

![image](https://user-images.githubusercontent.com/65009440/175017683-25c66e3c-b535-47c3-a79a-bb64e6c5c370.png)

To implement this approach, do the following:

1. **Specify custom DataTemplates.** Editors declared in these templates should follow our recommendations from this help topic: [CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate):

   ```xaml
   <DataTemplate x:Key="booleanEditor">
       <dxe:CheckEdit Name="PART_Editor" />
   </DataTemplate>
   <DataTemplate x:Key="buttonEditor">
       <dxe:ButtonEdit Name="PART_Editor" />
   </DataTemplate>
   <DataTemplate x:Key="comboboxEditor">
       <dxe:ComboBoxEdit Name="PART_Editor" .../>
   </DataTemplate>
   <DataTemplate x:Key="dateEditor">
       <dxe:DateEdit Name="PART_Editor" />
   </DataTemplate>
   <DataTemplate x:Key="textEditor">
       <dxe:TextEdit Name="PART_Editor" />
   </DataTemplate>
   ```

2. **Create a custom *DataTemplateSelector* descendant.** This descendant should return templates according to your scenario requirements.  

   ***Note:*** Each GridControl cell contains an object of the [EditGridCellData](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.EditGridCellData) data type in its DataContext. This object's [RowData.Row](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.RowData.Row) property contains your data item. You can use this property if your logic should take property values from data items into account:

   ```cs
   public class EditorTemplateSelector : DataTemplateSelector {
       public override DataTemplate SelectTemplate(object item, DependencyObject container) {
           EditGridCellData data = (EditGridCellData)item;
           var dataItem = data.RowData.Row as TestData;
           return dataItem == null || string.IsNullOrEmpty(dataItem.Editor) ? null : (DataTemplate)((FrameworkElement)container).FindResource(dataItem.Editor);
       }
   }
   ```

<!-- default file list -->
## Files to look at

* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml](./VB/Window1.xaml))
<!-- default file list end -->

## Documentation

* [Assign Editors to Cells](https://docs.devexpress.com/WPF/401011/controls-and-libraries/data-grid/data-editing-and-validation/modify-cell-values/assign-an-editor-to-a-cell)
* [Choose Templates Based on Custom Logic](https://docs.devexpress.com/WPF/6677/controls-and-libraries/data-grid/appearance-customization/choosing-templates-based-on-custom-logic)
* [Appearance Customization](https://docs.devexpress.com/WPF/6152/controls-and-libraries/data-grid/appearance-customization)
* [ColumnBase.CellTemplateSelector](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplateSelector)

## More Examples

* [WPF Data Grid - Assign a ComboBox Editor to a Column](https://github.com/DevExpress-Examples/wpf-data-grid-assign-combobox-editor-to-column)
* [WPF Data Grid - Use Custom Editors to Edit Cell Values](https://github.com/DevExpress-Examples/how-to-use-custom-editors-to-edit-cell-values-e1596)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-change-cell-template-based-on-custom-logic&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-change-cell-template-based-on-custom-logic&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
