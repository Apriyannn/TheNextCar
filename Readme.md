# THE NEXT CAR APPS

The Next Car adalah sebuah contoh project MVC yang dibuat dengan tujuan pada keamanan saat mengendarai mobil.

# Scope of Functionalities
- Apa kegunaan DoorController.cs?

- Apa kegunaan Model Door.cs?

- Apa kegunaan Interface OnDoorChanged ?

- DoorController.cs ?
- DoorController berfungsi untuk mengetahui apakah udah terLock atau belum pintu dari mobil itu.


# DoorController.cs ?
- Door.cs berfungsi untuk mengetahui fungsi door Closed atau Locked.
 ```csharp
namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorchanged;

        public DoorController(OnDoorChanged callbackOnDoorchanged)
        {
            this.callbackOnDoorchanged = callbackOnDoorchanged;
            this.door = new Door();
        }
```
# Door.cs ?
- Door.cs berfungsi untuk mengetahui fungsi door Closed atau Locked.
 
```csharp
namespace TheNextCar.Model
{
    class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
```
# OnDoorChanged ?
- OnDoorChanged berfungsi untuk mengganti fungsi dari Door dan DoorController.

```csharp
 public DoorController(OnDoorChanged callbackOnDoorchanged)
        {
            this.callbackOnDoorchanged = callbackOnDoorchanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("CLOSED", "door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("OPENED", "door opened");
        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("LOCKED", "door locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("UNLOCKED", "ddoor unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void OnLockDoorStateChanged(string value, string message);

        void OnDoorOpenStateChanged(string value, string message);
    }
}
```
# TERIMA KASIH