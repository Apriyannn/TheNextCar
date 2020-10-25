using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccuBatteryController
    {
        private AccuBattery accuBattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccuBatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accuBattery = new AccuBattery(12);
        }
        public void turnOn()
        {
            this.accuBattery.turnOn();
            this.callbackOnPowerChanged.OnPowerChangedStatus("ON", "power is on");
        }
        public void turnOff()
        {
            this.accuBattery.turnOff();
            this.callbackOnPowerChanged.OnPowerChangedStatus("OFF", "power is Off");
        }
        public bool accubatteryIsOn()
        {
            return this.accuBattery.isOn();
        }
    }

    interface OnPowerChanged
    {
        void OnPowerChangedStatus(string value, string message);
    }
}
