<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128622017/14.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T328505)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/T328505/Form1.cs) (VB: [Form1.vb](./VB/T328505/Form1.vb))
* [MyTokenEdit.cs](./CS/T328505/MyTokenEdit.cs) (VB: [MyTokenEdit.vb](./VB/T328505/MyTokenEdit.vb))
<!-- default file list end -->
# How to provide custom filter functionality for TokenEdit


<p>This example demonstrates how to implement the <strong>CustomFilterTokens</strong> event that can be used for custom filtering of tokens in TokenEdit's dropdown. To accomplish this task, create a custom <strong>TokenEdit</strong> descendant and override the following methods.<br>1. Override TokenEdit's <strong>CreatePopupController</strong> method to create a custom <strong>TokenEditTokenListPopupController </strong>descendant.<br>2. In the custom <strong>TokenEditTokenListPopupController </strong>descendant, override the <strong>UpdateFilter </strong>method to clear the default filter.<br>3. Override TokenEdit's <strong>CreatePopupForm </strong>method to create a custom <strong>TokenEditPopupForm </strong>descendant.<br>4. Override a custom <strong>TokenEditPopupForm </strong>descendant's <strong>CreateDropDownControl </strong>method to create a custom <strong>DefaultTokenEditDropDownControl </strong>descendant.<br>5. Override a <strong>DefaultTokenEditDropDownControl</strong> descendant's <strong>SetDataSource </strong>method in order to raise the <strong>CustomFilterTokens </strong>event.<br><br>Here is a small sample of how to use this functionality:</p>


```cs
        //Enable custom filter functionality    
        this.tokenEdit1.Properties.UseCustomFilter = true;
        //Handle the event
        this.tokenEdit1.Properties.CustomFilterTokens = new EventHandler<MyFilterEventArgs>(TokenEdit_CustomFilterText);    
      
        private void TokenEdit_CustomFilterText(object sender, MyFilterEventArgs e) {    
              if(condition)      
                e.IsValidToken = true;
        }
```




```vb
       'Enable custom filter functionality    
       Me.tokenEdit1.Properties.UseCustomFilter = true
       'Handle the event
       Me.tokenEdit1.Properties.CustomFilterTokens = AddressOf Me.TokenEdit_CustomFilterText
    
       Private Sub TokenEdit_CustomFilterText(ByVal sender As Object, ByVal e As MyFilterEventArgs)
          If condition Then
              e.IsValidToken = true
          End If        
      End Sub
```


<p> </p>

<br/>


