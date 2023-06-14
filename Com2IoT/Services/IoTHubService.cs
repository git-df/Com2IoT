using Com2IoT.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com2IoT.Services
{
    public class IoTHubService
    {
        public string DevId { get; set; } = string.Empty;
        public string DevKey { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public bool IsEnable { get; set; }

        public IoTHubService()
        {
            IsEnable = false;
        }

        public async Task<bool> StopIoT()
        {
            if (IsEnable)
            {
                bool good = await SendToIoT("Stop komunikacji z IoT");
                if (good)
                {
                    IsEnable = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> StartIoT(string dId, string dKey, string hostIoT)
        {
            DevId = dId;
            DevKey = dKey;
            HostName = hostIoT;

            if (!IsEnable)
            {
                bool good = await SendToIoT("Start komunikacji z IoT");
                if (good)
                {
                    IsEnable = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SendToIoT(string data)
        {
            try
            {
                MessageModel messageModel = new MessageModel(data);
                var authenticationKey = new DeviceAuthenticationWithRegistrySymmetricKey(DevId, DevKey);
                var divClient = DeviceClient.Create(HostName, authenticationKey, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
                string messageString = JsonConvert.SerializeObject(messageModel);
                Microsoft.Azure.Devices.Client.Message message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageString));
                await divClient.SendEventAsync(message);
                await divClient.CloseAsync();
                divClient.Dispose();
                return true;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
