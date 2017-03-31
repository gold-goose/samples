<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu LevelSubMenuStyles</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu LevelSubMenuStyles</h3>

      <asp:menu id="NavigationMenu"
        staticdisplaylevels="3"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"  
        runat="server">
        
        <levelsubmenustyles>
          <asp:submenustyle backcolor="LightSteelBlue"
            forecolor="Black"/>
          <asp:submenustyle backcolor="SkyBlue"
            forecolor="Gray"/>          
        </levelsubmenustyles>  
      
        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Music"
              tooltip="Music">
              <asp:menuitem text="Classical"
                tooltip="Classical"/>
              <asp:menuitem text="Rock"
                tooltip="Rock"/>
              <asp:menuitem text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem text="Movies"
              tooltip="Movies">
              <asp:menuitem text="Action"
                tooltip="Action"/>
              <asp:menuitem text="Drama"
                tooltip="Drama"/>
              <asp:menuitem text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
