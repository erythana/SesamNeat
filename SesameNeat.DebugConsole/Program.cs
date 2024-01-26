using CC1101.NET;

var controller = new CC1101Controller(null);
var cc1101 = controller.Initialize(0x03);

cc1101.SendPacket(0x00, new []{ (byte)0 }, 2, out var ack);