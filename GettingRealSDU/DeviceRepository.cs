﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealDomain;
using GettingRealDAL;



namespace GettingRealSDU_BL
{
   public class DeviceRepository : IRepository
    {
        //Singleton 
        private static readonly DeviceRepository _staticinstance = new DeviceRepository();
        public static DeviceRepository StaticInstance
        {
            get
            {
                return _staticinstance;
            }
        }


        public List<Device> DeviceList;
        XML xml = new XML();
        string divecelistfile = "devices.xml";
        public DeviceRepository()
        {
           DeviceList = new List<Device>();
        }        
         

        public Device GetDevice(string id)
        {           
           return StaticInstance.DeviceList.Find(Device => Device.DeviceId == id); 
        }

        public List<Device> GetDeviceList()
        {
            return StaticInstance.DeviceList;
        }

        public void CreateDevice(string id, string name)
        {                           
           StaticInstance.DeviceList.Add(new Device(id, name));
        }

        public void DeleteDevice(string id)
        {
           StaticInstance.DeviceList.Remove(DeviceList.Find(Device => Device.DeviceId == id));
        }

        public void LoadData()
        {
          StaticInstance.DeviceList=XML.LoadDeviceListFromXmlFile(divecelistfile);
        }

        public void SaveData()
        {
            XML.SaveDeviceListToXmlFile(DeviceList, divecelistfile);
        }
    }
}
