using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccuBatteryController accuBatteryController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccuBatteryController accuBatteryController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accuBatteryController = accuBatteryController;
            this.callback = callback;
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accuBatteryController.accubatteryIsOn();
        }
        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "close the door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }
            if (!powerIsReady())
            {
                this.callback.OnCarEngineStateChanged("STOPED", "no power available");
                return;
            }
            this.callback.OnCarEngineStateChanged("STARTED", "Engine Started");
        }
        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }
        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void togglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accuBatteryController.turnOn();
            }
            else
            {
                this.accuBatteryController.turnOff();
            }
        }
    }

    interface OnCarEngineStateChanged
    {
        void OnCarEngineStateChanged(string value, string message);
    }
}
