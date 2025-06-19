using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace ZapretRunner
{
    public partial class Form1 : Form
    {
        private string currentFolder;
        private Timer statusTimer;
        private const string RegistryRunKey = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppName = "ZapretWinForms";
        public Form1()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            currentFolder = Properties.Settings.Default.LastFolder;
            if (string.IsNullOrEmpty(currentFolder) || !Directory.Exists(currentFolder))
                currentFolder = Application.StartupPath;
            LoadBatFiles();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastBat) && listBoxBatFiles.Items.Contains(Properties.Settings.Default.LastBat))
                listBoxBatFiles.SelectedItem = Properties.Settings.Default.LastBat;
            UpdateButtonsState();
            // Статус winws
            statusTimer = new Timer();
            statusTimer.Interval = 2000;
            statusTimer.Tick += (s, e) => UpdateStatus();
            statusTimer.Start();
            UpdateStatus();
            // Трей
            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon1.Visible = false;
            this.Resize += Form1_Resize;
            // Автозапуск
            checkBoxAutostart.Checked = IsAutostartEnabled();
            if (checkBoxAutostart.Checked && Program.StartedFromAutostart && listBoxBatFiles.SelectedItem is string bat)
            {
                RunBat(bat, admin: false);
                this.WindowState = FormWindowState.Minimized;
            }
            var trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Выход", null, (s, e) => Application.Exit());
            notifyIcon1.ContextMenuStrip = trayMenu;
        }

        private void LoadBatFiles()
        {
            var files = Directory.GetFiles(currentFolder, "*.bat", SearchOption.TopDirectoryOnly)
                                  .Where(f => Path.GetFileName(f).ToLower().Contains("general"))
                                  .Select(Path.GetFileName)
                                  .OrderBy(f => f)
                                  .ToArray();
            listBoxBatFiles.Items.Clear();
            listBoxBatFiles.Items.AddRange(files);

            // Выбираем последний выбранный, если он есть
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastBat) &&
                listBoxBatFiles.Items.Contains(Properties.Settings.Default.LastBat))
            {
                listBoxBatFiles.SelectedItem = Properties.Settings.Default.LastBat;
            }
            else if (listBoxBatFiles.Items.Count > 0)
            {
                listBoxBatFiles.SelectedIndex = 0;
            }
        }

        private void UpdateButtonsState()
        {
            bool isRunning = Process.GetProcessesByName("winws").Any();
            buttonStop.Enabled = isRunning;
            buttonRun.Enabled = !isRunning && listBoxBatFiles.SelectedItem != null;
            buttonRunAsAdmin.Enabled = !isRunning && listBoxBatFiles.SelectedItem != null;
        }

        private void UpdateStatus()
        {
            bool isRunning = Process.GetProcessesByName("winws").Any();
            labelStatus.Text = isRunning ? "Статус: обход активен (winws.exe запущен)" : "Статус: обход неактивен (winws.exe не запущен)";
            labelStatus.ForeColor = isRunning ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            UpdateButtonsState();
        }

        private void RunBat(string bat, bool admin)
        {
            string batPath = Path.Combine(currentFolder, bat);
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"{batPath}\"",
                    CreateNoWindow = true,
                    UseShellExecute = admin,
                    WorkingDirectory = currentFolder,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = admin ? "runas" : ""
                };
                Process.Start(psi);
                MessageBox.Show($"Скрипт {bat} запущен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateButtonsState();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (listBoxBatFiles.SelectedItem is string bat)
            {
                RunBat(bat, admin: false);
                Properties.Settings.Default.LastBat = bat;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Выберите .bat файл!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRunAsAdmin_Click(object sender, EventArgs e)
        {
            if (listBoxBatFiles.SelectedItem is string bat)
            {
                RunBat(bat, admin: true);
                Properties.Settings.Default.LastBat = bat;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Выберите .bat файл!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var proc in Process.GetProcessesByName("winws"))
                {
                    proc.Kill();
                }
                MessageBox.Show("Все процессы winws.exe остановлены.", "Остановлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка остановки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateButtonsState();
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            buttonTest.Enabled = false;
            progressBarTest.Visible = true;
            labelTestStatus.Text = "Проверка: YouTube...";
            string result = "";
            bool yt = await TestSite("https://www.youtube.com");
            labelTestStatus.Text = "Проверка: Discord...";
            bool dc = await TestSite("https://discord.dev");
            labelTestStatus.Text = "";
            progressBarTest.Visible = false;
            buttonTest.Enabled = true;
            result += yt ? "YouTube: Доступен\n" : "YouTube: Нет доступа\n";
            result += dc ? "Discord: Доступен" : "Discord: Нет доступа";
            result += "\nДанная информация показывает только доступность сайтов.";
            MessageBox.Show(result, "Тест доступа", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<bool> TestSite(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFolder = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.LastFolder = currentFolder;
                Properties.Settings.Default.Save();
                LoadBatFiles();
                UpdateButtonsState();
            }
        }

        private void listBoxBatFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
            if (listBoxBatFiles.SelectedItem is string bat)
            {
                Properties.Settings.Default.LastBat = bat;
                Properties.Settings.Default.Save();
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            UpdateButtonsState();
        }

        // Трей
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.Activate();
        }

        // Автозапуск
        private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutostart.Checked)
            {
                string exePath = Application.ExecutablePath;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryRunKey, true))
                {
                    key.SetValue(AppName, "\"" + exePath + "\" /autostart");
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryRunKey, true))
                {
                    key.DeleteValue(AppName, false);
                }
            }
        }
        private bool IsAutostartEnabled()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryRunKey, false))
            {
                return key.GetValue(AppName) != null;
            }
        }
    }
}
