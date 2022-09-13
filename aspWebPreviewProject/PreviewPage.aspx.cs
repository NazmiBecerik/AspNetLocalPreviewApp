using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspWebPreviewProject
{
    public partial class PreviewPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public static string globalPath = @"C:\inetpub\wwwroot\";
        public static string pathLbox1 = "";
        public static string pathLbox2 = "";
       

        protected void doubleClick(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                ListBox3.Items.Clear();
                ListBox2.Items.Clear();
                pathLbox1= ListBox1.SelectedItem.Text.ToString();
                GetSubDirectories();


            }
        }

        protected void ListBox2Click(object sender, EventArgs e)
        {
          
            if (ListBox2.SelectedItem != null)
            {

                pathLbox2= ListBox2.SelectedItem.Text.ToString();
                GetSubList2Directories();
                globalPath += pathLbox1 + '/' + pathLbox2+'/';
                FilledTable(globalPath);
            }
        }

        //public void OpenImage()
        //{
        //    string FilePath = "http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Value + "/" + ListBox2.SelectedItem.Text + "/" + ListBox3.SelectedItem.Text;

        //    Response.Write("<script>");
        //    Response.Write("window.open('" + FilePath + "','top', 'height=700,width=800,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes');");
        //    Response.Write("</script>");
        //}

        protected void ListBox3Click(object sender, EventArgs e)
        {
            if (ListBox3.SelectedItem != null)
            {

                string FilePath = "http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Value + "/" + ListBox2.SelectedItem.Text + "/" + ListBox3.SelectedItem.Text;
                Response.Write("<script>");
                Response.Write("window.open('" + FilePath + "','top', 'height=700,width=800,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes');");
                Response.Write("</script>");
            
            }
        }

        public void FilledTable(string path)
        {
            DirectoryInfo directoriesForFilledTable = new DirectoryInfo(@"C:\inetpub\wwwroot\GORUNTULER\" + ListBox1.SelectedItem.Text + "\\" + ListBox2.SelectedItem.Text);
            var files = directoriesForFilledTable.GetFiles();
            TableRow tRow = new TableRow();
            tRow.Attributes.CssStyle["margin-bottom"] = "10px";
            table1.Rows.Add(tRow); 
            int row = 0;
            int cells = 0;
            for (int i = 0; i < files.Length; i++)
            {
                
                if (i % 5 == 0)
                {
                    TableRow tRow2 = new TableRow();
                    tRow2.Attributes.CssStyle["margin-bottom"] = "10px";
                    table1.Rows.Add(tRow2);
                    if (i != 0)
                    {
                        row = row + 1;
                        cells = 0;
                    }
                }
                if ((files[i].Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                  // var filePath = FileExtensionConverter.ExtensionConverter(files[i].FullName);
                    TableCell tCell = new TableCell();                   
                    table1.Rows[row].Cells.Add(tCell);
                    
                    ImageButton imgBtn = new ImageButton();
                    Label lbl = new Label();
                    lbl.Text = files[i].Name;
                    //imgBtn.ImageUrl = "http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text.ToString() + '/' + ListBox2.SelectedItem.Text.ToString() + '/' + i;
                    //imgBtn.ImageUrl = "http://localhost/GORUNTULER/512002-002/01.01.2022/images.png";

                    System.Net.WebRequest request = System.Net.WebRequest.Create(@"http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text + "//" + ListBox2.SelectedItem.Text + "/" + files[i].Name);
                    //System.Net.WebRequest request = System.Net.WebRequest.Create(filePath);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    Bitmap bitmap2 = new Bitmap(responseStream);

                    var imageHeight = 1200;
                    var imageWidth = 1920;
                    
                    System.IO.MemoryStream ms = new MemoryStream();
                    bitmap2.Save(ms, ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    var SigBase64 = Convert.ToBase64String(byteImage);
                    imgBtn.ImageUrl = "data:image/png;base64," + SigBase64;
                    //imgBtn.ImageUrl = @"http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text + "//" + ListBox2.SelectedItem.Text + "/"+files[i].Name;
                   // imgBtn.ImageUrl = @"http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text + "//" + ListBox2.SelectedItem.Text + "/"+fileNameWithExtension;
                    
                    imgBtn.Height = imageHeight/5;
                    imgBtn.Width = imageWidth/5;
                    imgBtn.ID = "imgBtn" + i;
                    imgBtn.OnClientClick = "OpenWindow('" + SigBase64 + "');return false;";
                    //imgBtn.OnClientClick = "OpenWindow('" + ListBox1.SelectedItem.Text + "','" + ListBox2.SelectedItem.Text + "','" + files[i].Name+"');return false;///";
 //çalışankodblogu  imgBtn.OnClientClick = "OpenWindow('" + ListBox1.SelectedItem.Text + "','" + ListBox2.SelectedItem.Text + "','" + files[i].Name+"');return false;";
                    //imgBtn.OnClientClick = "OpenWindow('" + ListBox1.SelectedItem.Text + "','" + ListBox2.SelectedItem.Text + "','" + files[i].Name + "');return false;";

                    //imgBtn.CommandArgument = @"http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text + "//" + ListBox2.SelectedItem.Text + "/" + files[i].Name;
                    //imgBtn.Command += new CommandEventHandler(OnImageClick);
                    //imgBtn.Attributes.Add("onclick", "return false;");
                    //imgBtn.Attributes.Add("AutoPostBack", "false");
                    //table1.Rows[0].Cells[i].Text = string.Format("<img src='' width='200' height ='200' id ='photoReview' runat='server'></img>");
                    table1.Rows[row].Cells[cells].Controls.Add(imgBtn);
                    table1.Rows[row].Cells[cells].Controls.Add(lbl);
                    table1.Rows[row].Cells[cells].Attributes.CssStyle["text-align"] = "center";
                    //   fabricTypeDiv.InnerHtml += "<li class='list-group-item' onClick=\"alert('selam')\" >" + dir.ToString() + "</li>";
                }
                // ListBox1.Items.Add(dirArray[i].ToString());
                cells = cells + 1;

            }

        }
        string fileName = "";
        protected void OnImageClick(object sender, CommandEventArgs e)
        {
            fileName = e.CommandName;
            
        }
        public void GetDirectories()
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\inetpub\wwwroot\GORUNTULER");
            DirectoryInfo[] dirArray = dirInfo.GetDirectories();
            foreach (var directory in dirArray)
            {
                ListBox1.Items.Add(directory.Name);
            }                  
        }
        public void GetSubDirectories()
        {
            ListBox2.Items.Clear();
            DirectoryInfo subDirInfo = new DirectoryInfo(@"C:\inetpub\wwwroot\GORUNTULER\" + pathLbox1);
            DirectoryInfo[] subDirArray = subDirInfo.GetDirectories();

            foreach (var subdir in subDirArray)
            {
                ListBox2.Items.Add(subdir.ToString());
            }
        }

        

        

        public void GetSubList2Directories()
        {
            ListBox3.Items.Clear();
            DirectoryInfo subDirInfo = new DirectoryInfo(@"C:\inetpub\wwwroot\GORUNTULER\" + ListBox1.SelectedItem.Text + "\\" + ListBox2.SelectedItem.Text);
            //globalPath2 = @"http://localhost/GORUNTULER/" + ListBox1.SelectedItem.Text + "/" + globalPath;
            var subDirArray = subDirInfo.GetFiles();

            for (int i = 0; i < subDirArray.Length; i++)
            {
                ListBox3.Items.Add(subDirArray[i].Name);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetDirectories();
        }
    }
}