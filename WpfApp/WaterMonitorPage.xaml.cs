using BO;
using DataAccessLayer;
using Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class WaterMonitorPage : Page
    {
        private readonly IWaterMonitorService waterMonitorService;
        private readonly int _pondId;

        public WaterMonitorPage(int pondId)
        {
            InitializeComponent();
            waterMonitorService = new WaterMonitorService();
            _pondId = pondId;
            LoadWaterMonitors(pondId);
        }

        private void LoadWaterMonitors(int pondId)
        {
            var waterMonitorList = WaterMonitorDAO.GetWaterMonitors(pondId);
            WaterMonitorDataGrid.ItemsSource = waterMonitorList;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var waterMonitor = new WaterMonitor
                {
                    Co2 = string.IsNullOrWhiteSpace(Co2TextBox.Text) ? 0 : float.Parse(Co2TextBox.Text),
                    Ammonium = string.IsNullOrWhiteSpace(AmmoniumTextBox.Text) ? 0 : float.Parse(AmmoniumTextBox.Text),
                    CarbonHardnesskh = string.IsNullOrWhiteSpace(CarbonHardnessTextBox.Text) ? 0 : float.Parse(CarbonHardnessTextBox.Text),
                    Hardnessgh = string.IsNullOrWhiteSpace(HardnessTextBox.Text) ? 0 : float.Parse(HardnessTextBox.Text),
                    Nitrate = string.IsNullOrWhiteSpace(NitrateTextBox.Text) ? 0 : float.Parse(NitrateTextBox.Text),
                    Nitrite = string.IsNullOrWhiteSpace(NitriteTextBox.Text) ? 0 : float.Parse(NitriteTextBox.Text),
                    OutdoorTemperature = string.IsNullOrWhiteSpace(OutdoorTemperatureTextBox.Text) ? 0 : int.Parse(OutdoorTemperatureTextBox.Text),
                    Oxygen = string.IsNullOrWhiteSpace(OxygenTextBox.Text) ? 0 : float.Parse(OxygenTextBox.Text),
                    Ph = string.IsNullOrWhiteSpace(PhTextBox.Text) ? 0 : float.Parse(PhTextBox.Text),
                    Phosphate = string.IsNullOrWhiteSpace(PhosphateTextBox.Text) ? 0 : float.Parse(PhosphateTextBox.Text),
                    Salt = string.IsNullOrWhiteSpace(SaltTextBox.Text) ? 0 : float.Parse(SaltTextBox.Text),
                    Temperature = string.IsNullOrWhiteSpace(TemperatureTextBox.Text) ? 0 : int.Parse(TemperatureTextBox.Text),
                    TotalChlorine = string.IsNullOrWhiteSpace(TotalChlorineTextBox.Text) ? 0 : float.Parse(TotalChlorineTextBox.Text),
                    PondId = string.IsNullOrWhiteSpace(PondIdTextBox.Text) ? 0 : int.Parse(PondIdTextBox.Text),
                    Date = DateTextBox.SelectedDate
                };

                waterMonitorService.CreateWaterMonitor(waterMonitor);
                LoadWaterMonitors(_pondId);
                ClearTextFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating Water Monitor: {ex.Message}");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(WaterMonitorIdTextBox.Text, out int id))
            {
                var waterMonitor = new WaterMonitor
                {
                    Id = id,
                    Co2 = string.IsNullOrWhiteSpace(Co2TextBox.Text) ? 0 : float.Parse(Co2TextBox.Text),
                    Ammonium = string.IsNullOrWhiteSpace(AmmoniumTextBox.Text) ? 0 : float.Parse(AmmoniumTextBox.Text),
                    CarbonHardnesskh = string.IsNullOrWhiteSpace(CarbonHardnessTextBox.Text) ? 0 : float.Parse(CarbonHardnessTextBox.Text),
                    Hardnessgh = string.IsNullOrWhiteSpace(HardnessTextBox.Text) ? 0 : float.Parse(HardnessTextBox.Text),
                    Nitrate = string.IsNullOrWhiteSpace(NitrateTextBox.Text) ? 0 : float.Parse(NitrateTextBox.Text),
                    Nitrite = string.IsNullOrWhiteSpace(NitriteTextBox.Text) ? 0 : float.Parse(NitriteTextBox.Text),
                    OutdoorTemperature = string.IsNullOrWhiteSpace(OutdoorTemperatureTextBox.Text) ? 0 : int.Parse(OutdoorTemperatureTextBox.Text),
                    Oxygen = string.IsNullOrWhiteSpace(OxygenTextBox.Text) ? 0 : float.Parse(OxygenTextBox.Text),
                    Ph = string.IsNullOrWhiteSpace(PhTextBox.Text) ? 0 : float.Parse(PhTextBox.Text),
                    Phosphate = string.IsNullOrWhiteSpace(PhosphateTextBox.Text) ? 0 : float.Parse(PhosphateTextBox.Text),
                    Salt = string.IsNullOrWhiteSpace(SaltTextBox.Text) ? 0 : float.Parse(SaltTextBox.Text),
                    Temperature = string.IsNullOrWhiteSpace(TemperatureTextBox.Text) ? 0 : int.Parse(TemperatureTextBox.Text),
                    TotalChlorine = string.IsNullOrWhiteSpace(TotalChlorineTextBox.Text) ? 0 : float.Parse(TotalChlorineTextBox.Text),
                    PondId = string.IsNullOrWhiteSpace(PondIdTextBox.Text) ? 0 : int.Parse(PondIdTextBox.Text),
                    Date = DateTextBox.SelectedDate
                };

                waterMonitorService.UpdateWaterMonitor(waterMonitor);
                LoadWaterMonitors(_pondId);
                ClearTextFields();
            }
            else
            {
                MessageBox.Show("Invalid Water Monitor ID.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(WaterMonitorIdTextBox.Text, out int id))
            {
                var waterMonitor = waterMonitorService.GetWaterMonitorById(id);
                if (waterMonitor != null)
                {
                    waterMonitorService.DeleteWaterMonitor(waterMonitor);
                    LoadWaterMonitors(_pondId);
                    ClearTextFields();
                }
                else
                {
                    MessageBox.Show("Water Monitor not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Water Monitor ID.");
            }
        }

        private void dg_selection(object sender, SelectionChangedEventArgs e)
        {
            if (WaterMonitorDataGrid.SelectedItem is WaterMonitor selectedWaterMonitor)
            {
                WaterMonitorIdTextBox.Text = selectedWaterMonitor.Id.ToString();
                Co2TextBox.Text = selectedWaterMonitor.Co2.ToString();
                AmmoniumTextBox.Text = selectedWaterMonitor.Ammonium.ToString();
                CarbonHardnessTextBox.Text = selectedWaterMonitor.CarbonHardnesskh.ToString();
                HardnessTextBox.Text = selectedWaterMonitor.Hardnessgh.ToString();
                NitrateTextBox.Text = selectedWaterMonitor.Nitrate.ToString();
                NitriteTextBox.Text = selectedWaterMonitor.Nitrite.ToString();
                OutdoorTemperatureTextBox.Text = selectedWaterMonitor.OutdoorTemperature.ToString();
                OxygenTextBox.Text = selectedWaterMonitor.Oxygen.ToString();
                PhTextBox.Text = selectedWaterMonitor.Ph.ToString();
                PhosphateTextBox.Text = selectedWaterMonitor.Phosphate.ToString();
                SaltTextBox.Text = selectedWaterMonitor.Salt.ToString();
                TemperatureTextBox.Text = selectedWaterMonitor.Temperature.ToString();
                TotalChlorineTextBox.Text = selectedWaterMonitor.TotalChlorine.ToString();
                PondIdTextBox.Text = selectedWaterMonitor.PondId.ToString();
                DateTextBox.SelectedDate = selectedWaterMonitor.Date;
            }
            else
            {
                ClearTextFields();
            }
        }

        private void ClearTextFields()
        {
            WaterMonitorIdTextBox.Clear();
            Co2TextBox.Clear();
            AmmoniumTextBox.Clear();
            CarbonHardnessTextBox.Clear();
            HardnessTextBox.Clear();
            NitrateTextBox.Clear();
            NitriteTextBox.Clear();
            OutdoorTemperatureTextBox.Clear();
            OxygenTextBox.Clear();
            PhTextBox.Clear();
            PhosphateTextBox.Clear();
            SaltTextBox.Clear();
            TemperatureTextBox.Clear();
            TotalChlorineTextBox.Clear();
            PondIdTextBox.Clear();
            DateTextBox.SelectedDate = null;
        }
    }
}