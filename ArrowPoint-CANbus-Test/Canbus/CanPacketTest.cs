using System;
using NUnit.Framework;
using ArrowPointCANBusTool.Canbus;

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
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x500");
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
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x1806E5F4");
        }

        [Test]
        public void TestCanIdChange()
        {
            CanPacket canPacket = new CanPacket(0x500)
            {
                CanId = 0x505
            };
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x505");
        }

        [Test]
        public void TestCanIdBase10Change()
        {
            CanPacket canPacket = new CanPacket(0x500)
            {
                CanIdBase10 = 1285
            };
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x505");

            canPacket.CanId = 0x600;
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x600");

            canPacket.CanIdBase10 = 1285;
            Assert.AreEqual(canPacket.CanIdAsHex.ToString(), "0x505");
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
            canPacket.SetByte(0, 1);
            Assert.AreEqual(canPacket.GetByte(0), 1);
            canPacket.SetByte(0, 12);
            Assert.AreEqual(canPacket.GetByte(0), 12);

            Boolean gotException = false;

            try
            {
                canPacket.SetByte(8, 12);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetByte(8);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

        }


        public void TestByteString(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetByteString(0, "1A");
            Assert.AreEqual(canPacket.GetByteString(0).ToUpper(), "1A");
            canPacket.SetByteString(0, "B");
            Assert.AreEqual(canPacket.GetByteString(0).ToUpper(), "0B");

            Boolean gotException = false;

            try
            {
                canPacket.SetByteString(8, "2B");
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetByteString(8);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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



        public void TestInt8(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetInt8(0, 123);
            Assert.AreEqual(canPacket.GetInt8(0), 123);

            canPacket.SetInt8(1, -12);
            Assert.AreEqual(canPacket.GetInt8(1), (int)-12);

            Boolean gotException = false;

            try
            {
                canPacket.SetInt8(8, 321);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetInt8(8);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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


        public void TestUInt8(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetUint8(0, 123);
            Assert.AreEqual(canPacket.GetUint8(0), (uint)123);

            Boolean gotException = false;

            try
            {
                canPacket.SetUint8(8, 321);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetUint8(8);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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



        public void TestInt16(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetInt16(0, 12001);
            Assert.AreEqual(canPacket.GetInt16(0), 12001);

            canPacket.SetInt16(1, -12002);
            Assert.AreEqual(canPacket.GetInt16(1), (int)-12002);

            Boolean gotException = false;

            try
            {
                canPacket.SetInt16(4, 12001);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetInt16(4);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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


        public void TestUInt16(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetUint16(0, 32760);
            Assert.AreEqual(canPacket.GetUint16(0), (uint)32760);

            Boolean gotException = false;

            try
            {
                canPacket.SetUint16(4, 321);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetUint16(4);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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



        public void TestInt32(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetInt32(0, 21474836);
            Assert.AreEqual(canPacket.GetInt32(0), 21474836);

            canPacket.SetInt32(1, -21474836);
            Assert.AreEqual(canPacket.GetInt32(1), (int)-21474836);

            Boolean gotException = false;

            try
            {
                canPacket.SetInt32(4, 12001);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetInt32(4);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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


        public void TestUInt32(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((int)0x1806E5F4ul);
            canPacket.SetUint32(0, 2147483);
            Assert.AreEqual(canPacket.GetUint32(0), (uint)2147483);

            Boolean gotException = false;

            try
            {
                canPacket.SetUint32(4, 321);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetUint32(4);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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



        public void TestFloat(CanPacket canPacket)
        {
            if (canPacket == null) canPacket = new CanPacket((uint)0x1806E5F4ul);
            canPacket.SetInt32(0, 21474836);
            Assert.AreEqual(canPacket.GetInt32(0), 21474836);

            canPacket.SetInt32(1, -21474836);
            Assert.AreEqual(canPacket.GetInt32(1), (int)-21474836);

            Boolean gotException = false;

            try
            {
                canPacket.SetInt32(4, 12001);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

            gotException = false;

            try
            {
                canPacket.GetInt32(4);
            }
            catch
            {
                gotException = true;
            }

            Assert.IsTrue(gotException);

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

            Assert.AreEqual(canPacket.Int16Pos0,8721);
            Assert.AreEqual(canPacket.Int16Pos1,17459);
            Assert.AreEqual(canPacket.Int16Pos2,26197);
            Assert.AreEqual(canPacket.Int16Pos3,-30601);

            Assert.AreEqual(canPacket.Float1, (float)-7.444915E-34);
            Assert.AreEqual(canPacket.Float0, (float)716.532288);
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
