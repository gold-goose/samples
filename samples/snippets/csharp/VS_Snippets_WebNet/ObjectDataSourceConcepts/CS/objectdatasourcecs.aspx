<%@ Page language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void EmployeesDetailsView_ItemInserted(Object sender, DetailsViewInsertedEventArgs e)
  {
    EmployeesGridView.DataBind();  
  }
  
 
  void EmployeesDetailsView_ItemUpdated(Object sender, DetailsViewUpdatedEventArgs e)
  {
    EmployeesGridView.DataBind();
  }
  

  void EmployeesDetailsView_ItemDeleted(Object sender, DetailsViewDeletedEventArgs e)
  {
    EmployeesGridView.DataBind();
  }


  void EmployeesGridView_OnSelectedIndexChanged(object sender, EventArgs e)
  {
    EmployeeDetailsObjectDataSource.SelectParameters["EmployeeID"].DefaultValue = 
      EmployeesGridView.SelectedDataKey.Value.ToString();
  }


  void EmployeeDetailsObjectDataSource_OnInserted(object sender, ObjectDataSourceStatusEventArgs e)
  {
    EmployeeDetailsObjectDataSource.SelectParameters["EmployeeID"].DefaultValue = 
      e.OutputParameters["NewEmployeeID"].ToString();
    EmployeesDetailsView.DataBind();
  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ObjectDataSource Example</title>
</head>
<body>
    <form id="form1" runat="server">
        
      <h3>ObjectDataSource Example</h3>

      <!-- <Snippet3> -->
      <asp:ObjectDataSource 
        ID="EmployeesObjectDataSource" 
        runat="server" 
        TypeName="Samples.AspNet.Controls.NorthwindEmployee" 
        SortParameterName="SortColumns"
        EnablePaging="true"
        StartRowIndexParameterName="StartRecord"
        MaximumRowsParameterName="MaxRecords" 
        SelectMethod="GetAllEmployees" >
      </asp:ObjectDataSource>
      <!-- </Snippet3> -->

      <!-- <Snippet4> -->
      <asp:ObjectDataSource 
        ID="EmployeeDetailsObjectDataSource" 
        runat="server" 
        TypeName="Samples.AspNet.Controls.NorthwindEmployee" 
        SelectMethod="GetEmployee" 
        UpdateMethod="UpdateEmployee"
        DeleteMethod="DeleteEmployee"
        InsertMethod="InsertEmployee" 
        OnInserted="EmployeeDetailsObjectDataSource_OnInserted" >
        <SelectParameters>
          <asp:Parameter Name="EmployeeID" />  
        </SelectParameters>
        <InsertParameters>
          <asp:Parameter Name="NewEmployeeID" Direction="Output" 
                         Type="Int32" DefaultValue="0" />
        </InsertParameters>
      </asp:ObjectDataSource>
      <!-- </Snippet4> -->
        
      <table cellspacing="10">
        <tr>
          <td valign="top">
            <asp:GridView ID="EmployeesGridView" 
              DataSourceID="EmployeesObjectDataSource" 
              AutoGenerateColumns="false"
              AllowSorting="true"
              AllowPaging="true"
              PageSize="5"
              DataKeyNames="EmployeeID" 
              OnSelectedIndexChanged="EmployeesGridView_OnSelectedIndexChanged"
              RunAt="server">
                
              <HeaderStyle backcolor="lightblue" forecolor="black"/>
                
              <Columns>                
                <asp:ButtonField Text="Details..."
                                 HeaderText="Show Details"
                                 CommandName="Select"/>  
                
                <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" SortExpression="EmployeeID" />
                <asp:BoundField DataField="FirstName"  HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName"   HeaderText="Last Name" SortExpression="LastName, FirstName" />                    
              </Columns>                
            </asp:GridView>            
          </td>
                
          <td valign="top">                
            <asp:DetailsView ID="EmployeesDetailsView"
              DataSourceID="EmployeeDetailsObjectDataSource"
              AutoGenerateRows="false"
              AutoGenerateInsertButton="true"
              AutoGenerateEditButton="true"
              AutoGenerateDeleteButton="true"
              EmptyDataText="No records."      
              DataKeyNames="EmployeeID"     
              Gridlines="Both" 
              OnItemInserted="EmployeesDetailsView_ItemInserted"
              OnItemUpdated="EmployeesDetailsView_ItemUpdated"
              OnItemDeleted="EmployeesDetailsView_ItemDeleted"      
              RunAt="server">
                
              <HeaderStyle backcolor="Navy" forecolor="White"/>
                  
              <RowStyle backcolor="White"/>
                
              <AlternatingRowStyle backcolor="LightGray"/>
                
              <EditRowStyle backcolor="LightCyan"/>
                                    
              <Fields>                  
                <asp:BoundField DataField="EmployeeID" HeaderText="Employee ID" InsertVisible="False" ReadOnly="true"/>                    
                <asp:BoundField DataField="FirstName"  HeaderText="First Name"/>
                <asp:BoundField DataField="LastName"   HeaderText="Last Name"/>                    
                <asp:BoundField DataField="Address"    HeaderText="Address"/>                    
                <asp:BoundField DataField="City"       HeaderText="City"/>                        
                <asp:BoundField DataField="Region"     HeaderText="Region"/>
                <asp:BoundField DataField="PostalCode" HeaderText="Postal Code"/>                    
              </Fields>                    
            </asp:DetailsView>
          </td>                
        </tr>            
      </table>
    </form>
  </body>
</html>
