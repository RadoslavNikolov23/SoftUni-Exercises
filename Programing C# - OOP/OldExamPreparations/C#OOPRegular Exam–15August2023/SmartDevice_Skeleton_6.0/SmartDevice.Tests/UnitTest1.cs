namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {

        [Test]
        public void DeviceIntalization()
        {
            int memoryCapacity = 100;
            Device smartDevice = new Device(memoryCapacity);

            Assert.IsNotNull(smartDevice);
            Assert.That(smartDevice.MemoryCapacity, Is.EqualTo(memoryCapacity));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity));
            Assert.That(smartDevice.Photos, Is.EqualTo(0));
            Assert.IsNotNull(smartDevice.Applications.Count);
            Assert.That(smartDevice.Applications.Count, Is.EqualTo(0));
        }

        [Test]
        public void TakePhoto_worksNormally_RetursTrue()
        {
            int memoryCapacity = 1000;
            int photoSize = 100;
            Device smartDevice = new Device(memoryCapacity);
            bool takenFoto = smartDevice.TakePhoto(photoSize);

            Assert.That(takenFoto, Is.True);
            Assert.That(smartDevice.Photos, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - photoSize));

        }

        [Test]
        public void TakePhoto_worksNormally_RetursFalse()
        {
            int memoryCapacity = 100;
            int photoSize = 1000;
            Device smartDevice = new Device(memoryCapacity);
            bool takenFoto = smartDevice.TakePhoto(photoSize);

            Assert.That(takenFoto, Is.False);
            Assert.That(smartDevice.Photos, Is.EqualTo(0));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity));

        }

        [Test]
        public void InstallApp_worksNormally()
        {
            int memoryCapacity = 1000;
            string appName = "Skype";
            int appSize = 100;
            Device smartDevice = new Device(memoryCapacity);

            string result = smartDevice.InstallApp(appName,appSize);

            Assert.That(result, Is.EqualTo($"{appName} is installed successfully. Run application?"));

            Assert.That(smartDevice.Applications.Count, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - appSize));

        }

        [Test]
        public void InstallApp_ThrowsException()
        {
            int memoryCapacity = 100;
            string appName = "Skype";
            int appSize = 1000;
            Device smartDevice = new Device(memoryCapacity);

            var exception = Assert.Throws<InvalidOperationException>(()=>smartDevice.InstallApp(appName,appSize));

            Assert.That(exception.Message, Is.EqualTo($"Not enough available memory to install the app."));

            Assert.That(smartDevice.Applications.Count, Is.EqualTo(0));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity));

        }


        [Test]
        public void Format_worksNormally()
        {
            int memoryCapacity = 1000;
            string appName = "Skype";
            int appSize = 100;
            int photoSize = 100;
            Device smartDevice = new Device(memoryCapacity);

            bool takenFoto = smartDevice.TakePhoto(photoSize);
            Assert.That(smartDevice.Photos, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - photoSize));

            string result = smartDevice.InstallApp(appName, appSize);
            Assert.That(smartDevice.Applications.Count, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - appSize-photoSize));

            smartDevice.FormatDevice();
            Assert.That(smartDevice.Photos, Is.EqualTo(0));
            Assert.That(smartDevice.Applications.Count, Is.EqualTo(0));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity));

        }

        [Test]
        public void GetDeviceStatus_worksNormally()
        {
            int memoryCapacity = 1000;
            string appName = "Skype";
            int appSize = 100;
            int photoSize = 100;
            Device smartDevice = new Device(memoryCapacity);

            smartDevice.TakePhoto(photoSize);
            Assert.That(smartDevice.Photos, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - photoSize));

            smartDevice.InstallApp(appName, appSize);
            Assert.That(smartDevice.Applications.Count, Is.EqualTo(1));
            Assert.That(smartDevice.AvailableMemory, Is.EqualTo(memoryCapacity - appSize-photoSize));

            string result = smartDevice.GetDeviceStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - appSize - photoSize} MB");
            sb.AppendLine($"Photos Count: {smartDevice.Photos}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", smartDevice.Applications)}");


            Assert.That(result, Is.EqualTo(sb.ToString().Trim()));


        }
    }
}