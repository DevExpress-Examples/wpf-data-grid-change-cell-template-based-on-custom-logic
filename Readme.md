<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128648629/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2017)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

<!-- default file list -->
*Files to look at*:

* [Window1.xaml](./CS/Window1.xaml) (VB: [Window1.xaml](./VB/Window1.xaml))
* [Window1.xaml.cs](./CS/Window1.xaml.cs) (VB: [Window1.xaml](./VB/Window1.xaml))
<!-- default file list end -->
# How to change a cell template based on custom logic


This sample illustrates how to change a cell template based on a condition using [CellTemplateSelector](https://documentation.devexpress.com/#WPF/DevExpressXpfGridColumnBase_CellTemplateSelectortopic). 

To implement this approach, do the following:

1. **Implement custom DataTemplates.** Editors declared in these templates should follow our recommendations from this help topic: [CellTemplate](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate.property):

````xaml
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
````

2. **Create a custom *DataTemplateSelector* descendant.** This descendant should return templates according to your scenario requirements.  

***Note:*** Each GridControl cell contains an object of the [EditGridCellData](https://documentation.devexpress.com/WPF/clsDevExpressXpfGridEditGridCellDatatopic) data type in its DataContext. This object's [RowData.Row](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.RowData.Row.property) property contains your data item. You can use this property if your logic should take property values from data items into account:
````cs
public class EditorTemplateSelector : DataTemplateSelector {
    public override DataTemplate SelectTemplate(object item, DependencyObject container) {
        GridCellData data = (GridCellData)item;
        var dataItem = data.RowData.Row as TestData;
        return string.IsNullOrEmpty(dataItem.Editor) ? null : (DataTemplate)((FrameworkElement)container).FindResource(dataItem.Editor);
    }
}
````
