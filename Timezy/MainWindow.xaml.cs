using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Timezy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int MAX_DEVICE = 128;

        private int m_Handle = -1;

        private int m_NumOfDevice = 0;
        private uint[] m_DeviceID;
        private int[] m_DeviceType;
        private uint[] m_DeviceAddr;

        private uint m_DeviceID1;
        private uint m_DeviceAddr1;
        private int m_DeviceType1;

        private int m_NumOfConnectedDevice = 0;
        private int[] m_ConnectedDeviceHandle;
        private uint[] m_ConnectedDeviceID;
        private int[] m_ConnectedDeviceType;
        private uint[] m_ConnectedDeviceAddr;

        BSSDK.BESysInfoData m_SysInfoBEPlus;
        BSSDK.BEConfigData m_ConfigBEPlus;

        BSSDK.BESysInfoDataBLN m_SysInfoBLN;
        BSSDK.BEConfigDataBLN m_ConfigBLN;

        BSSDK.BSSysInfoConfig m_SysInfoBST;
        BSSDK.BSIPConfig m_ConfigBST;

        public MainWindow()
        {
            InitializeComponent();
            m_DeviceID = new uint[MAX_DEVICE];
            m_DeviceType = new int[MAX_DEVICE];
            m_DeviceAddr = new uint[MAX_DEVICE];
            m_ConnectedDeviceHandle = new int[MAX_DEVICE];
            m_ConnectedDeviceID = new uint[MAX_DEVICE];
            m_ConnectedDeviceType = new int[MAX_DEVICE];
            m_ConnectedDeviceAddr = new uint[MAX_DEVICE];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            loaddevice();
        }

        public void loaddevice()
        {
            deviceList.Items.Clear();
            int result = BSSDK.BS_SearchDeviceInLAN(m_Handle, ref m_NumOfDevice, m_DeviceID, m_DeviceType, m_DeviceAddr);
            if (result != BSSDK.BS_SUCCESS)
            {
                MessageBox.Show("Cannot find any device", "Error");
                return;
            }

            for (int i = 0; i < m_NumOfDevice; i++)
            {
                string device = "";

                if (m_DeviceType[i] == BSSDK.BS_DEVICE_BIOSTATION)
                {
                    device += "BioStation ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_DSTATION)
                {
                    device += "D-Station ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_XSTATION)
                {
                    device += "X-Station ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_BIOSTATION2)
                {
                    device += "BioStation T2 ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_FSTATION)
                {
                    device += "FaceStation ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_BIOENTRY_PLUS)
                {
                    device += "BioEntry Plus ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_BIOENTRY_W)
                {
                    device += "BioEntry W ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_BIOLITE)
                {
                    device += "BioLite Net ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_XPASS)
                {
                    device += "Xpass ";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_XPASS_SLIM)
                {
                    device += "Xpass Slim";
                }
                else if (m_DeviceType[i] == BSSDK.BS_DEVICE_XPASS_SLIM2)
                {
                    device += "Xpass S2";
                }
                else
                {
                    device += "Unknown ";
                }

                device += (m_DeviceAddr[i] & 0xff) + ".";
                device += ((m_DeviceAddr[i] >> 8) & 0xff) + ".";
                device += ((m_DeviceAddr[i] >> 16) & 0xff) + ".";
                device += ((m_DeviceAddr[i] >> 24) & 0xff);

                device += "(" + m_DeviceID[i] + ")";

                deviceList.Items.Add(device);
                /// MessageBox.Show(device);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
