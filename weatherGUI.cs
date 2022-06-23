// Weather GUI final.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CSharpGUI 
{
    public class WinFormExample : Form 
    {

        private Button button;
        TextBox Mytextbox1;
        TextBox Mytextbox; 

        public WinFormExample() 
        {
            DisplayGUI();
        }

        private void DisplayGUI() {
            Label mylab = new Label();
            mylab.Text = "City Name:";
            mylab.Location = new Point(20, 10);
            mylab.AutoSize = true;
            mylab.Font = new Font("Calibri", 12);
            mylab.Padding = new Padding(6);
            this.Controls.Add(mylab);

            Mytextbox = new TextBox();
            Mytextbox.Text = "Enter City Name...";
            Mytextbox.Text = "Enter City Name...";
            Mytextbox.Location = new Point(120, 10);
            Mytextbox.AutoSize = true;
            Mytextbox.Font = new Font("Calibri", 12);
            Mytextbox.Padding = new Padding(6);
            this.Controls.Add(Mytextbox);

            Label mylab1 = new Label();
            mylab1.Text = "Temperature:";
            mylab1.Location = new Point(20, 200);
            mylab1.AutoSize = true;
            mylab1.Font = new Font("Calibri", 12);
            mylab1.Padding = new Padding(6);
            this.Controls.Add(mylab1);

            Mytextbox1 = new TextBox();
            Mytextbox1.Text = "Temperature";
            Mytextbox1.Text = "Temperature";
            Mytextbox1.Location = new Point(130, 200);
            Mytextbox1.AutoSize = true;
            Mytextbox1.Font = new Font("Calibri", 12);
            Mytextbox1.Padding = new Padding(6);
            this.Controls.Add(Mytextbox1);

            this.Name = "Temperature";
            this.Text = "Temperature";
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            button = new Button();
            button.Name = "button";
            button.Text = "Click Me!";
            button.Size = new Size(this.Width - 200, this.Height - 250);
            button.Location = new Point(
                (this.Width - button.Width) / 2 ,
                (this.Height - button.Height) / 2);
            button.Click += new System.EventHandler(this.MyButtonClick);

            this.Controls.Add(button);
        }

        private void MyButtonClick(object source, EventArgs e) 
        {
            string city = Mytextbox.Text;
            // Console.WriteLine("Enter City Name: ");
            // string city = Console.ReadLine();
            WebRequest request = WebRequest.Create ("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=e6b7427f8bf97526adf2869093c7509c&units=metric");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            Stream dataStream = response.GetResponseStream ();
            StreamReader reader = new StreamReader (dataStream);
            string responseFromServer = reader.ReadToEnd ();
            JObject json = JObject.Parse(responseFromServer);
            JObject main = JObject.Parse(json["main"].ToString());
            string temp = main["temp"].ToString();
            Console.WriteLine("Temperature of " + city + ": " + main["temp"].ToString());
            Mytextbox1.Text = temp;
            // MessageBox.Show("My First WinForm Application");
            // tempValue.SetText(temp);
        }

        public static void Main(String[] args) {
            Application.Run(new WinFormExample());
        }
    }
}






































// // Weather GUI final.

// using System;
// using System.Drawing;
// using System.Windows.Forms;
// using System.IO;
// using System.Net;
// using Newtonsoft.Json.Linq;

// namespace CSharpGUI 
// {
//     public class WinFormExample : Form 
//     {

//         private Button button;
//         TextBox Mytextbox1;
//         TextBox Mytextbox; 

//         public WinFormExample() 
//         {
//             DisplayGUI();
//         }

//         private void DisplayGUI() {
//             Label mylab = new Label();
//             mylab.Text = "City Name:";
//             mylab.Location = new Point(20, 10);
//             mylab.AutoSize = true;
//             mylab.Font = new Font("Calibri", 12);
//             mylab.Padding = new Padding(6);
//             this.Controls.Add(mylab);

//             Mytextbox = new TextBox();
//             Mytextbox.Text = "Enter City Name...";
//             Mytextbox.Text = "Enter City Name...";
//             Mytextbox.Location = new Point(120, 10);
//             Mytextbox.AutoSize = true;
//             Mytextbox.Font = new Font("Calibri", 12);
//             Mytextbox.Padding = new Padding(6);
//             this.Controls.Add(Mytextbox);

//             Label mylab1 = new Label();
//             mylab1.Text = "Temperature:";
//             mylab1.Location = new Point(20, 200);
//             mylab1.AutoSize = true;
//             mylab1.Font = new Font("Calibri", 12);
//             mylab1.Padding = new Padding(6);
//             this.Controls.Add(mylab1);

//             Mytextbox1 = new TextBox();
//             Mytextbox1.Text = "Temperature";
//             Mytextbox1.Text = "Temperature";
//             Mytextbox1.Location = new Point(130, 200);
//             Mytextbox1.AutoSize = true;
//             Mytextbox1.Font = new Font("Calibri", 12);
//             Mytextbox1.Padding = new Padding(6);
//             this.Controls.Add(Mytextbox1);

//             this.Name = "Temperature";
//             this.Text = "Temperature";
//             this.Size = new Size(300, 300);
//             this.StartPosition = FormStartPosition.CenterScreen;

//             button = new Button();
//             button.Name = "button";
//             button.Text = "Click Me!";
//             button.Size = new Size(this.Width - 200, this.Height - 250);
//             button.Location = new Point(
//                 (this.Width - button.Width) / 2 ,
//                 (this.Height - button.Height) / 2);
//             button.Click += new System.EventHandler(this.MyButtonClick);

//             this.Controls.Add(button);
//         }

//         private void MyButtonClick(object source, EventArgs e) 
//         {
//             string city = Mytextbox.Text;
//             // Console.WriteLine("Enter City Name: ");
//             // string city = Console.ReadLine();
//             WebRequest request = WebRequest.Create ("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=e6b7427f8bf97526adf2869093c7509c&units=metric");
//             request.Credentials = CredentialCache.DefaultCredentials;
//             HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
//             Stream dataStream = response.GetResponseStream ();
//             StreamReader reader = new StreamReader (dataStream);
//             string responseFromServer = reader.ReadToEnd ();
//             JObject json = JObject.Parse(responseFromServer);
//             JObject main = JObject.Parse(json["main"].ToString());
//             string temp = main["temp"].ToString();
//             Console.WriteLine("Temperature of " + city + ": " + main["temp"].ToString());
//             Mytextbox1.Text = temp;
//             // MessageBox.Show("My First WinForm Application");
//             // tempValue.SetText(temp);
//         }

//         public static void Main(String[] args) {
//             Application.Run(new WinFormExample());
//         }
//     }
// }







































// using System;
// using System.Drawing;
// using System.Windows.Forms;

// namespace CSharpGUI {
//     public class WinFormExample : Form {

//         private Button button;

//         public WinFormExample() {
//             DisplayGUI();
//         }

//         private void DisplayGUI() {
//             this.Name = "Temperature";
//             this.Text = "Temperature";
//             this.Size = new Size(300, 300);
//             this.StartPosition = FormStartPosition.CenterScreen;

//             button = new Button();
//             button.Name = "button";
//             button.Text = "Click Me!";
//             button.Size = new Size(this.Width - 200, this.Height - 250);
//             button.Location = new Point(
//                 (this.Width - button.Width) / 2 ,
//                 (this.Height - button.Height) / 2);
//             button.Click += new System.EventHandler(this.MyButtonClick);

//             this.Controls.Add(button);
//         }

//         private void MyButtonClick(object source, EventArgs e) {
//             MessageBox.Show("My First WinForm Application");
//         }

//         public static void Main(String[] args) {
//             Application.Run(new WinFormExample());
//         }
//     }
// }