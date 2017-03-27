using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Apress.MVCRecipes.DBInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            List<string> serverList = e.Result as List<string>;
            if (serverList != null && serverList.Count>0)
            {
                ServersComboBox.ItemsSource = e.Result as List<string>;
                ServersComboBox.IsEnabled = true;
                SearchingLabel.Text = "Please select the database instance where you would like to install the sample database.";
            }
            else
            {
                SearchingLabel.Text = "No local databases found. Please install either SQL Server Standard or SQL Server Developer Edition";
            }
        }


        
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.ToString() == "getList")
            {
                e.Result = DbUtility.GetListOfAvailibleDatabaseServers();
            }
            else
            {
                try
                {
                    Restore sqlRestore = new Restore();
                    string assemblyDirPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string backupPath = assemblyDirPath + @"\DBBackup\SharedAPI.bak";
                    string databaseName = "Chapter7SharedDatabase";

                    BackupDeviceItem buDevice = new BackupDeviceItem(backupPath, DeviceType.File);
                    sqlRestore.Devices.Add(buDevice);
                    sqlRestore.Database = databaseName;
                    string serverName = e.Argument.ToString();
                    ServerConnection connection = new ServerConnection(serverName);
                    Server sqlServer = new Server(connection);
                    Information info = sqlServer.Information;

                    //use default database directories
                    string dataFilePath = info.MasterDBPath;
                    string logFilePath = info.MasterDBLogPath;
                    Database database = sqlServer.Databases[databaseName];
                    if (database == null)
                    {
                        database = new Database(sqlServer, databaseName);
                        database.Create();
                    }
                    String dataFileLocation = dataFilePath + "\\" + databaseName + ".mdf";
                    String logFileLocation = logFilePath + "\\" + databaseName + "_Log.ldf";
                    Database db = sqlServer.Databases[databaseName];
                    RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);

                    sqlRestore.Complete += sqlRestore_Complete;

                    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName, dataFileLocation));
                    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName + "_log", logFileLocation));
                    sqlRestore.ReplaceDatabase = true;

                    sqlRestore.SqlRestore(sqlServer);



                }
                catch (Microsoft.SqlServer.Management.Smo.FailedOperationException error)
                {
                    SearchingLabel.Dispatcher.BeginInvoke(
                new UpdateTextDel(UpdateText),
                string.Format("The sample database creation failed with the following error:{0}.",
                error.Message)
                );
                }
                catch (ConnectionFailureException connectError)
                {
                    SearchingLabel.Dispatcher.BeginInvoke(
                new UpdateTextDel(UpdateText),
                string.Format("We could not connect to the database. error:{0}.",
                connectError.Message)
                );
                }
            }
            
            

        }

        BackgroundWorker worker;

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ServersComboBox.IsEnabled = false;
            worker.RunWorkerAsync("getList");
            
            
        }

        private void ServersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServersComboBox.IsEnabled && ServersComboBox.SelectedValue != null)
            {
                CreateDatabaseButton.Visibility = Visibility.Visible;
            }
        }

        private void CreateDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            CreateDatabaseButton.IsEnabled = false;
            SearchingLabel.Text = "Creating the sample database please wait...";
            worker.RunWorkerAsync(ServersComboBox.SelectedValue.ToString());
            

        }

        private delegate void UpdateTextDel(string text);
        private void UpdateText(string text)
        {
            SearchingLabel.Text = text;
        }
        void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            SearchingLabel.Dispatcher.BeginInvoke(
                new UpdateTextDel(UpdateText), "The sample database has been created sucessfully."
                );
        }
    }
}
