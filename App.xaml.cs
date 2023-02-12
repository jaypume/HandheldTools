using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Forms = System.Windows.Forms;

namespace HandheldTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Forms.NotifyIcon _notifyIcon;
        private MainWindow _mainWindow;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
            _mainWindow = new MainWindow();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            //MainWindow.Left = SystemParameters.PrimaryScreenWidth - MainWindow.Width;
            //MainWindow.Show();
            //_mainWindow.Activate();
            //_mainWindow.ShowDialog();

            _notifyIcon.Icon = new System.Drawing.Icon("resources/main.ico");
            _notifyIcon.Text = "掌机控制小工具";
            _notifyIcon.Click += NotifyIconClick;

            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Status", Image.FromFile("resources/main.ico"), onStatusClicked);
            _notifyIcon.ContextMenuStrip.Items.Add("Exit", Image.FromFile("resources/main.ico"), onExitClicked);

            _notifyIcon.Visible= true; 

            base.OnStartup(e);
        }

        private void onExitClicked(object? sender, EventArgs e)
        {
            //MainWindow.WindowState = WindowState.Normal;

            // show 和 active是有区别的：
            _mainWindow.WindowState = WindowState.Normal;
            _mainWindow.Activate();
        }

        private void onStatusClicked(object? sender, EventArgs e)
        {
            MessageBox.Show("Application is running", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotifyIconClick(object? sender, EventArgs e)
        {
            _mainWindow.WindowState= WindowState.Normal;
            _mainWindow.Activate();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //_notifyIcon.Dispose();
            //_mainWindow.Close();
            base.OnExit(e);
        }
    }
}
