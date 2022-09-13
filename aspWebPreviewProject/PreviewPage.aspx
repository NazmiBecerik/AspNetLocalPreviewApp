<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewPage.aspx.cs" Inherits="aspWebPreviewProject.PreviewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css"
        integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"
        integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js"
        integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>
    <title>Preview Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <asp:Button CssClass="col-sm-12" ID="Button1" runat="server" Text="Görüntüleri Gör" OnClick="Button1_Click" Style="margin-left: 15px" />

        </div>
        <div class="display:flex">
            <div class="row" style="margin-left: 0px; margin-right: 0px">

                <div class="col-sm-6">
                    <ul class="list-group">
                        <li class="list-group-item  list-group-item-primary">Kumaş Türü</li>
                        <%--<li id="fabricTypeDiv" class="list-group-item" runat="server"/>--%>
                        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="doubleClick"></asp:ListBox>
                    </ul>
                </div>
                <div class="col-sm-6">
                    <ul class="list-group">
                        <li class="list-group-item list-group-item-primary">Tarihi</li>
                        <%--<li class="list-group-item list-group-item-primary">This is a primary list group item</li>--%>
                        <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox2Click"></asp:ListBox>
                    </ul>
                </div>
            </div>
            <div class="row" style="margin-left: 0px; margin-right: 0px">
                <asp:Table runat="server" ID="table1">
                  
                </asp:Table>
            </div>
        </div>



        <%--<div class="col-sm-4">--%>
        <%--<ul class="list-group">--%>
        <%--<li class="list-group-item list-group-item-primary">Bulunan Hatalar</li>--%>
        <%--<li class="list-group-item list-group-item-primary">This is a primary list group item</li>--%>
        <asp:ListBox ID="ListBox3" runat="server" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ListBox3Click"></asp:ListBox>
        <%--</ul>--%>
        <%--</div>--%>
        <%--</div>--%>
    </form>
    <script>
        //function OpenWindow(kumasfolder,datefolder,fileName)
        //{
        //    window.open('http://localhost/GORUNTULER/' + kumasfolder +'/' + datefolder +'/'+fileName+'', 'top', 'height=700,width=800,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes');

        //}
        function OpenWindow(base64) {
            let pdfWindow = window.open("")
            pdfWindow.document.write(
                "<iframe allowFullScreen='true' title='Hata Görüntüleme Sayfası' width='1920' height='1100' src='data:image/jpeg;base64, " +
                encodeURI(base64) + "'></iframe>"
            )


        }
    </script>
</body>
</html>
