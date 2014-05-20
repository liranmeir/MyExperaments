<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SortableTest._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
  <style>
    #_Default { list-style-type: none; margin: 0; padding: 0; width: 40%; }
    #_Default li { margin: 0 6px 6px 6px; padding: 0.4em; padding-left: 1.5em; font-size: 1em; height: 18px; }
    #_Default li span { position: absolute; margin-left: -1.3em; }
</style>

<ul id="_Default1" runat="server" ClientIDMode="Static">
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 1</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 2</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 3</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 4</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 5</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 6</li>
    <li class="ui-state-default"><span class="ui-icon ui-icon-arrowthick-2-n-s"></span>Item 7</li>
</ul>
<juice:sortable TargetControlID="_Default" runat="server"/>

<p><em>Enable a group of DOM elements to be sortable. Click on and drag an element to a new spot within the list, and the other items will adjust to fit. By default, sortable items share draggable properties.</em></p> 
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/jquery-1.8.2.min.js" />
        <asp:ScriptReference Path="~/Scripts/jquery-ui-1.9.0.min.js" />
    </Scripts>
</asp:ScriptManager>
</asp:Content>

