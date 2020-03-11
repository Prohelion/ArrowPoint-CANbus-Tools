using System;
using NUnit.Framework;
using ArrowPointCANBusTool.CanLibrary;
using Prohelion.CanLibrary;

namespace ArrowPointCANBusTest.Canbus
{
    [TestFixture]
    public class CanPacketTest
    {
        [Test]
        public void TestCanId500()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanId, (uint)0x500);
        }

        [Test]
        public void TestCanId500Base10()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanIdBase10, (uint)1280);
        }

        [Test]
        public void TestCanId500Hex()
        {
            CanPacket canPacket = new CanPacket(0x500);
            Assert.AreEqual(canPacket.CanIdAsHex, "0x500");
        }

        [Test]
        public void TestCanIdLarge()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanId, (uint)0x1806E5F4ul);
        }

        [Test]
        public void TestCanIdLargeBase10()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanIdBase10, (uint)403105268);
        }

        [Test]
        public void TestCanIdLargeHex()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            Assert.AreEqual(canPacket.CanIdAsHex, "0x1806E5F4");
        }

        [Test]
        public void TestCanIdChange()
        {
            CanPacket canPacket = new CanPacket(0x500)
            {
                CanId = 0x505
            };
            Assert.AreEqual(canPacket.CanIdAsHex, "0x505");
        }

        [Test]
        public void TestCanIdBase10Change()
        {
            CanPacket canPacket = new CanPacket(0x500)
            {
                CanIdBase10 = 1285
            };
            Assert.AreEqual(canPacket.CanIdAsHex, "0x505");

            canPacket.CanId = 0x600;
            Assert.AreEqual(canPacket.CanIdAsHex, "0x600");

            canPacket.CanIdBase10 = 1285;
            Assert.AreEqual(canPacket.CanIdAsHex, "0x505");
        }


        [Test]
        public void TestExtended()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul)
            {
                Extended = true
            };
            Assert.AreEqual(canPacket.Extended, true);
            canPacket.Extended = false;
            Assert.AreEqual(canPacket.Extended, false);
        }

        [Test]
        public void TestRtr()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul)
            {
                Rtr = true
            };
            Assert.AreEqual(canPacket.Rtr, true);
            canPacket.Rtr = false;
            Assert.AreEqual(canPacket.Rtr, false);
        }


        [Test]
        public void TestByte()
        {
            CanPacket canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.UBytePos0 = 1;
            Assert.AreEqual(canPacket.UBytePos0, 1);
            canPacket.UBytePos0 = 12;
            Assert.AreEqual(canPacket.UBytePos0, 12);
        }


        public static void TestByteString(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.UBytePos0 = Convert.ToByte("1A");
            Assert.AreEqual(canPacket.Byte0AsHex, "1A");
            canPacket.UBytePos0 = Convert.ToByte("B");
            Assert.AreEqual(canPacket.Byte0AsHex, "0B");
        }


        [Test]
        public void TestByteStringLittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestByteString(canPacket);
        }

        [Test]
        public void TestByteStringBigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestByteString(canPacket);
        }



        public static void TestInt8(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.Int8Pos0 = 123;
            Assert.AreEqual(canPacket.Int8Pos0, 123);

            canPacket.Int8Pos1 = -12;
            Assert.AreEqual(canPacket.Int8Pos1, (int)-12);
        }


        [Test]
        public void TestInt8LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestInt8(canPacket);
        }

        [Test]
        public void TestInt8BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestInt8(canPacket);
        }


        public static void TestUInt8(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.UInt8Pos0 = 123;
            Assert.AreEqual(canPacket.UInt8Pos0, (uint)123);

        }


        [Test]
        public void TestUInt8LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestUInt8(canPacket);
        }

        [Test]
        public void TestUInt8BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestUInt8(canPacket);
        }



        /* 
         * 
         * 
         *  INT16
         *  
         *  
         */



        public static void TestInt16(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.Short16Pos0 = 12001;
            Assert.AreEqual(canPacket.Short16Pos0, 12001);

            canPacket.Short16Pos1 = -12002;
            Assert.AreEqual(canPacket.Short16Pos1, (int)-12002);
        }


        [Test]
        public void TestInt16LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestInt16(canPacket);
        }

        [Test]
        public void TestInt16BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestInt16(canPacket);
        }


        public static void TestUInt16(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.UShort16Pos0 = 32760;
            Assert.AreEqual(canPacket.UShort16Pos0, (uint)32760);

        }


        [Test]
        public void TestUInt16LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestUInt16(canPacket);
        }

        [Test]
        public void TestUInt16BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestUInt16(canPacket);
        }


        /* 
        * 
        * 
        *  INT32
        *  
        *  
        */



        public static void TestInt32(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.Int32Pos0 = 21474836;
            Assert.AreEqual(canPacket.Int32Pos0, 21474836);

            canPacket.Int32Pos1 = -21474836;
            Assert.AreEqual(canPacket.Int32Pos1, (int)-21474836);
        }


        [Test]
        public void TestInt32LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestInt32(canPacket);
        }

        [Test]
        public void TestInt32BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestInt32(canPacket);
        }


        public static void TestUInt32(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.UInt32Pos0 = 2147483;
            Assert.AreEqual(canPacket.UInt32Pos0, (uint)2147483);
        }


        [Test]
        public void TestUInt32LittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestUInt32(canPacket);
        }

        [Test]
        public void TestUInt32BigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestUInt32(canPacket);
        }


        /* 
        * 
        * 
        *  Float
        *  
        *  
        */



        public static void TestFloat(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((uint)0x1806E5F4ul);
            canPacket.Int32Pos0 = 21474836;
            Assert.AreEqual(canPacket.Int32Pos0, 21474836);

            canPacket.Int32Pos1 = -21474836;
            Assert.AreEqual(canPacket.Int32Pos1, (int)-21474836);
        }


        [Test]
        public void TestFloatLittleEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505);
            TestFloat(canPacket);
        }

        [Test]
        public void TestFloatBigEndian()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                IsLittleEndian = false
            };

            TestFloat(canPacket);
        }


        [Test]
        public void TestPacket1()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                RawBytesString = "005472697469756d008e0ea8c00047eb0000040400081122334455667788"
            };

            Assert.AreEqual(canPacket.Byte7AsHex,"88");
            Assert.AreEqual(canPacket.Byte6AsHex,"77");
            Assert.AreEqual(canPacket.Byte5AsHex,"66");
            Assert.AreEqual(canPacket.Byte4AsHex,"55");
            Assert.AreEqual(canPacket.Byte3AsHex,"44");
            Assert.AreEqual(canPacket.Byte2AsHex,"33");
            Assert.AreEqual(canPacket.Byte1AsHex,"22");
            Assert.AreEqual(canPacket.Byte0AsHex,"11");

            Assert.AreEqual(canPacket.Short16Pos0,8721);
            Assert.AreEqual(canPacket.Short16Pos1,17459);
            Assert.AreEqual(canPacket.Short16Pos2,26197);
            Assert.AreEqual(canPacket.Short16Pos3,-30601);

            Assert.AreEqual(canPacket.FloatPos1, (float)-7.444915E-34);
            Assert.AreEqual(canPacket.FloatPos0, (float)716.532288);
        }

        [Test]
        public void TestPacket2()
        {
            CanPacket canPacket = new CanPacket((int)0x505)
            {
                RawBytesString = "005472697469756d008e0ea8c00047eb0000040400080020000000100000"
            };
            Assert.IsFalse(canPacket.Extended);
            Assert.AreEqual(canPacket.Flags, "");

            canPacket.RawBytesString = "005472697469756d008e0ea8c00047eb0000040401080020000000100000";
            Assert.IsTrue(canPacket.Extended);
            Assert.IsFalse(canPacket.Rtr);
            Assert.AreEqual(canPacket.Flags, "E");

            canPacket.RawBytesString = "005472697469756d008e0ea8c00047eb0000040403000000000000000000";
            Assert.IsTrue(canPacket.Extended);
            Assert.IsTrue(canPacket.Rtr);
            Assert.AreEqual(canPacket.Flags, "ER");

            canPacket.RawBytesString = "005472697469756d008e0ea8c00047eb0000040402000000000000000000";
            Assert.IsFalse(canPacket.Extended);
            Assert.IsTrue(canPacket.Rtr);
            Assert.AreEqual(canPacket.Flags, "R");
        }


    }
}
