using NUnit.Framework;

namespace SKIT.FlurlHttpClient.UnitTests.TestCases.JsonConverter
{
    using SKIT.FlurlHttpClient.Configuration;

    public class TestCase_JsonConverterOfTextualNumberTest
    {
        private sealed class MockObject
        {
            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsByte), Order = 101)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public byte PropertyAsByte { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsSByte), Order = 102)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public sbyte PropertyAsSByte { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsInt16), Order = 103)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public short PropertyAsInt16 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsUInt16), Order = 104)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public ushort PropertyAsUInt16 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsInt32), Order = 105)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public int PropertyAsInt32 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsUInt32), Order = 106)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public uint PropertyAsUInt32 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsInt64), Order = 107)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public long PropertyAsInt64 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsUInt64), Order = 108)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public ulong PropertyAsUInt64 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsFloat), Order = 109)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public float PropertyAsFloat { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsDouble), Order = 110)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public double PropertyAsDouble { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsDecimal), Order = 111)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public decimal PropertyAsDecimal { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableByte), Order = 201)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public byte? PropertyAsNullableByte { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableSByte), Order = 202)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public sbyte? PropertyAsNullableSByte { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableInt16), Order = 203)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public short? PropertyAsNullableInt16 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableUInt16), Order = 204)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public ushort? PropertyAsNullableUInt16 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableInt32), Order = 205)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public int? PropertyAsNullableInt32 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableUInt32), Order = 206)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public uint? PropertyAsNullableUInt32 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableInt64), Order = 207)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public long? PropertyAsNullableInt64 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableUInt64), Order = 208)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public ulong? PropertyAsNullableUInt64 { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableFloat), Order = 209)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public float? PropertyAsNullableFloat { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableDouble), Order = 210)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public double? PropertyAsNullableDouble { get; set; }

            [Newtonsoft.Json.JsonProperty(nameof(PropertyAsNullableDecimal), Order = 211)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.TextualNumberConverter))]
            public decimal? PropertyAsNullableDecimal { get; set; }
        }

        private static void TestCustomJsonConverter(IJsonSerializer jsonSerializer)
        {
            var mockObj1 = new MockObject()
            {
                PropertyAsByte = byte.MaxValue,
                PropertyAsSByte = sbyte.MaxValue,
                PropertyAsInt16 = short.MaxValue,
                PropertyAsUInt16 = ushort.MaxValue,
                PropertyAsInt32 = int.MaxValue,
                PropertyAsUInt32 = uint.MaxValue,
                PropertyAsInt64 = long.MaxValue,
                PropertyAsUInt64 = ulong.MaxValue,
                PropertyAsFloat = 1.23F,
                PropertyAsDouble = 1.23D,
                PropertyAsDecimal = 1.23M
            };
            var actualJson1 = jsonSerializer.Serialize(mockObj1);
            var actualObj1 = jsonSerializer.Deserialize<MockObject>(actualJson1);
            StringAssert.Contains("\"PropertyAsByte\":\"255\"", actualJson1);
            StringAssert.Contains("\"PropertyAsSByte\":\"127\"", actualJson1);
            StringAssert.Contains("\"PropertyAsInt16\":\"32767\"", actualJson1);
            StringAssert.Contains("\"PropertyAsUInt16\":\"65535\"", actualJson1);
            StringAssert.Contains("\"PropertyAsInt32\":\"2147483647\"", actualJson1);
            StringAssert.Contains("\"PropertyAsUInt32\":\"4294967295\"", actualJson1);
            StringAssert.Contains("\"PropertyAsInt64\":\"9223372036854775807\"", actualJson1);
            StringAssert.Contains("\"PropertyAsUInt64\":\"18446744073709551615\"", actualJson1);
            StringAssert.Contains("\"PropertyAsDecimal\":\"1.23\"", actualJson1);
            Assert.AreEqual(mockObj1.PropertyAsByte, actualObj1.PropertyAsByte);
            Assert.AreEqual(mockObj1.PropertyAsByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsByte\":255}").PropertyAsByte);
            Assert.AreEqual(mockObj1.PropertyAsByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsByte\":\"255\"}").PropertyAsByte);
            Assert.AreEqual(mockObj1.PropertyAsSByte, actualObj1.PropertyAsSByte);
            Assert.AreEqual(mockObj1.PropertyAsSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsSByte\":127}").PropertyAsSByte);
            Assert.AreEqual(mockObj1.PropertyAsSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsSByte\":\"127\"}").PropertyAsSByte);
            Assert.AreEqual(mockObj1.PropertyAsInt16, actualObj1.PropertyAsInt16);
            Assert.AreEqual(mockObj1.PropertyAsInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt16\":32767}").PropertyAsInt16);
            Assert.AreEqual(mockObj1.PropertyAsInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt16\":\"32767\"}").PropertyAsInt16);
            Assert.AreEqual(mockObj1.PropertyAsUInt16, actualObj1.PropertyAsUInt16);
            Assert.AreEqual(mockObj1.PropertyAsUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt16\":65535}").PropertyAsUInt16);
            Assert.AreEqual(mockObj1.PropertyAsUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt16\":\"65535\"}").PropertyAsUInt16);
            Assert.AreEqual(mockObj1.PropertyAsInt32, actualObj1.PropertyAsInt32);
            Assert.AreEqual(mockObj1.PropertyAsInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt32\":2147483647}").PropertyAsInt32);
            Assert.AreEqual(mockObj1.PropertyAsInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt32\":\"2147483647\"}").PropertyAsInt32);
            Assert.AreEqual(mockObj1.PropertyAsUInt32, actualObj1.PropertyAsUInt32);
            Assert.AreEqual(mockObj1.PropertyAsUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt32\":4294967295}").PropertyAsUInt32);
            Assert.AreEqual(mockObj1.PropertyAsUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt32\":\"4294967295\"}").PropertyAsUInt32);
            Assert.AreEqual(mockObj1.PropertyAsInt64, actualObj1.PropertyAsInt64);
            Assert.AreEqual(mockObj1.PropertyAsInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt64\":9223372036854775807}").PropertyAsInt64);
            Assert.AreEqual(mockObj1.PropertyAsInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt64\":\"9223372036854775807\"}").PropertyAsInt64);
            Assert.AreEqual(mockObj1.PropertyAsUInt64, actualObj1.PropertyAsUInt64);
            Assert.AreEqual(mockObj1.PropertyAsUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt64\":18446744073709551615}").PropertyAsUInt64);
            Assert.AreEqual(mockObj1.PropertyAsUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt64\":\"18446744073709551615\"}").PropertyAsUInt64);
            Assert.AreEqual(mockObj1.PropertyAsFloat, actualObj1.PropertyAsFloat);
            Assert.AreEqual(mockObj1.PropertyAsFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsFloat\":1.23}").PropertyAsFloat);
            Assert.AreEqual(mockObj1.PropertyAsFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsFloat\":\"1.23\"}").PropertyAsFloat);
            Assert.AreEqual(mockObj1.PropertyAsDouble, actualObj1.PropertyAsDouble);
            Assert.AreEqual(mockObj1.PropertyAsDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDouble\":1.23}").PropertyAsDouble);
            Assert.AreEqual(mockObj1.PropertyAsDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDouble\":\"1.23\"}").PropertyAsDouble);
            Assert.AreEqual(mockObj1.PropertyAsDecimal, actualObj1.PropertyAsDecimal);
            Assert.AreEqual(mockObj1.PropertyAsDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDecimal\":1.23}").PropertyAsDecimal);
            Assert.AreEqual(mockObj1.PropertyAsDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDecimal\":\"1.23\"}").PropertyAsDecimal);
            Assert.AreEqual(mockObj1.PropertyAsNullableByte, actualObj1.PropertyAsNullableByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableByte\":null}").PropertyAsNullableByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableByte\":\"\"}").PropertyAsNullableByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableSByte, actualObj1.PropertyAsNullableSByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableSByte\":null}").PropertyAsNullableSByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableSByte\":\"\"}").PropertyAsNullableSByte);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt16, actualObj1.PropertyAsNullableInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt16\":null}").PropertyAsNullableInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt16\":\"\"}").PropertyAsNullableInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt16, actualObj1.PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt16\":null}").PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt16\":\"\"}").PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt32, actualObj1.PropertyAsNullableInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt32\":null}").PropertyAsNullableInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt32\":\"\"}").PropertyAsNullableInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt32, actualObj1.PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt32\":null}").PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt32\":\"\"}").PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt64, actualObj1.PropertyAsNullableInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt64\":null}").PropertyAsNullableInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt64\":\"\"}").PropertyAsNullableInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt64, actualObj1.PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt64\":null}").PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt64\":\"\"}").PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj1.PropertyAsNullableFloat, actualObj1.PropertyAsNullableFloat);
            Assert.AreEqual(mockObj1.PropertyAsNullableFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableFloat\":null}").PropertyAsNullableFloat);
            Assert.AreEqual(mockObj1.PropertyAsNullableFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableFloat\":\"\"}").PropertyAsNullableFloat);
            Assert.AreEqual(mockObj1.PropertyAsNullableDouble, actualObj1.PropertyAsNullableDouble);
            Assert.AreEqual(mockObj1.PropertyAsNullableDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDouble\":null}").PropertyAsNullableDouble);
            Assert.AreEqual(mockObj1.PropertyAsNullableDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDouble\":\"\"}").PropertyAsNullableDouble);
            Assert.AreEqual(mockObj1.PropertyAsNullableDecimal, actualObj1.PropertyAsNullableDecimal);
            Assert.AreEqual(mockObj1.PropertyAsNullableDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDecimal\":null}").PropertyAsNullableDecimal);
            Assert.AreEqual(mockObj1.PropertyAsNullableDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDecimal\":\"\"}").PropertyAsNullableDecimal);

            var mockObj2 = new MockObject()
            {
                PropertyAsNullableByte = byte.MaxValue,
                PropertyAsNullableSByte = sbyte.MaxValue,
                PropertyAsNullableInt16 = short.MaxValue,
                PropertyAsNullableUInt16 = ushort.MaxValue,
                PropertyAsNullableInt32 = int.MaxValue,
                PropertyAsNullableUInt32 = uint.MaxValue,
                PropertyAsNullableInt64 = long.MaxValue,
                PropertyAsNullableUInt64 = ulong.MaxValue,
                PropertyAsNullableFloat = 1.23F,
                PropertyAsNullableDouble = 1.23D,
                PropertyAsNullableDecimal = 1.23M
            };
            var actualJson2 = jsonSerializer.Serialize(mockObj2);
            var actualObj2 = jsonSerializer.Deserialize<MockObject>(actualJson2);
            Assert.AreEqual(mockObj2.PropertyAsByte, actualObj2.PropertyAsByte);
            Assert.AreEqual(mockObj2.PropertyAsByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsByte\":null}").PropertyAsByte);
            Assert.AreEqual(mockObj2.PropertyAsByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsByte\":\"\"}").PropertyAsByte);
            Assert.AreEqual(mockObj2.PropertyAsSByte, actualObj2.PropertyAsSByte);
            Assert.AreEqual(mockObj2.PropertyAsSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsSByte\":null}").PropertyAsSByte);
            Assert.AreEqual(mockObj2.PropertyAsSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsSByte\":\"\"}").PropertyAsSByte);
            Assert.AreEqual(mockObj2.PropertyAsInt16, actualObj2.PropertyAsInt16);
            Assert.AreEqual(mockObj2.PropertyAsInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt16\":null}").PropertyAsInt16);
            Assert.AreEqual(mockObj2.PropertyAsInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt16\":\"\"}").PropertyAsInt16);
            Assert.AreEqual(mockObj2.PropertyAsUInt16, actualObj2.PropertyAsUInt16);
            Assert.AreEqual(mockObj2.PropertyAsUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt16\":null}").PropertyAsUInt16);
            Assert.AreEqual(mockObj2.PropertyAsUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt16\":\"\"}").PropertyAsUInt16);
            Assert.AreEqual(mockObj2.PropertyAsInt32, actualObj2.PropertyAsInt32);
            Assert.AreEqual(mockObj2.PropertyAsInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt32\":null}").PropertyAsInt32);
            Assert.AreEqual(mockObj2.PropertyAsInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt32\":\"\"}").PropertyAsInt32);
            Assert.AreEqual(mockObj2.PropertyAsUInt32, actualObj2.PropertyAsUInt32);
            Assert.AreEqual(mockObj2.PropertyAsUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt32\":null}").PropertyAsUInt32);
            Assert.AreEqual(mockObj2.PropertyAsUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt32\":\"\"}").PropertyAsUInt32);
            Assert.AreEqual(mockObj2.PropertyAsInt64, actualObj2.PropertyAsInt64);
            Assert.AreEqual(mockObj2.PropertyAsInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt64\":null}").PropertyAsInt64);
            Assert.AreEqual(mockObj2.PropertyAsInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsInt64\":\"\"}").PropertyAsInt64);
            Assert.AreEqual(mockObj2.PropertyAsUInt64, actualObj2.PropertyAsUInt64);
            Assert.AreEqual(mockObj2.PropertyAsUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt64\":null}").PropertyAsUInt64);
            Assert.AreEqual(mockObj2.PropertyAsUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsUInt64\":\"\"}").PropertyAsUInt64);
            Assert.AreEqual(mockObj2.PropertyAsFloat, actualObj2.PropertyAsFloat);
            Assert.AreEqual(mockObj2.PropertyAsFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsFloat\":null}").PropertyAsFloat);
            Assert.AreEqual(mockObj2.PropertyAsFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsFloat\":\"\"}").PropertyAsFloat);
            Assert.AreEqual(mockObj2.PropertyAsDouble, actualObj2.PropertyAsDouble);
            Assert.AreEqual(mockObj2.PropertyAsDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDouble\":null}").PropertyAsDouble);
            Assert.AreEqual(mockObj2.PropertyAsDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDouble\":\"\"}").PropertyAsDouble);
            Assert.AreEqual(mockObj2.PropertyAsDecimal, actualObj2.PropertyAsDecimal);
            Assert.AreEqual(mockObj2.PropertyAsDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDecimal\":null}").PropertyAsDecimal);
            Assert.AreEqual(mockObj2.PropertyAsDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsDecimal\":\"\"}").PropertyAsDecimal);
            StringAssert.Contains("\"PropertyAsNullableByte\":\"255\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableSByte\":\"127\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableInt16\":\"32767\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableUInt16\":\"65535\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableInt32\":\"2147483647\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableUInt32\":\"4294967295\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableInt64\":\"9223372036854775807\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableUInt64\":\"18446744073709551615\"", actualJson2);
            StringAssert.Contains("\"PropertyAsNullableDecimal\":\"1.23\"", actualJson2);
            Assert.AreEqual(mockObj2.PropertyAsNullableByte, actualObj2.PropertyAsNullableByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableByte\":255}").PropertyAsNullableByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableByte\":\"255\"}").PropertyAsNullableByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableSByte, actualObj2.PropertyAsNullableSByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableSByte\":127}").PropertyAsNullableSByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableSByte, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableSByte\":\"127\"}").PropertyAsNullableSByte);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt16, actualObj2.PropertyAsNullableInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt16\":32767}").PropertyAsNullableInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt16\":\"32767\"}").PropertyAsNullableInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt16, actualObj2.PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt16\":65535}").PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt16, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt16\":\"65535\"}").PropertyAsNullableUInt16);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt32, actualObj2.PropertyAsNullableInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt32\":2147483647}").PropertyAsNullableInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt32\":\"2147483647\"}").PropertyAsNullableInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt32, actualObj2.PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt32\":4294967295}").PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt32, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt32\":\"4294967295\"}").PropertyAsNullableUInt32);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt64, actualObj2.PropertyAsNullableInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt64\":9223372036854775807}").PropertyAsNullableInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableInt64\":\"9223372036854775807\"}").PropertyAsNullableInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt64, actualObj2.PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt64\":18446744073709551615}").PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableUInt64, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableUInt64\":\"18446744073709551615\"}").PropertyAsNullableUInt64);
            Assert.AreEqual(mockObj2.PropertyAsNullableFloat, actualObj2.PropertyAsNullableFloat);
            Assert.AreEqual(mockObj2.PropertyAsNullableFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableFloat\":1.23}").PropertyAsNullableFloat);
            Assert.AreEqual(mockObj2.PropertyAsNullableFloat, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableFloat\":\"1.23\"}").PropertyAsNullableFloat);
            Assert.AreEqual(mockObj2.PropertyAsNullableDouble, actualObj2.PropertyAsNullableDouble);
            Assert.AreEqual(mockObj2.PropertyAsNullableDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDouble\":1.23}").PropertyAsNullableDouble);
            Assert.AreEqual(mockObj2.PropertyAsNullableDouble, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDouble\":\"1.23\"}").PropertyAsNullableDouble);
            Assert.AreEqual(mockObj2.PropertyAsNullableDecimal, actualObj2.PropertyAsNullableDecimal);
            Assert.AreEqual(mockObj2.PropertyAsNullableDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDecimal\":1.23}").PropertyAsNullableDecimal);
            Assert.AreEqual(mockObj2.PropertyAsNullableDecimal, jsonSerializer.Deserialize<MockObject>("{\"PropertyAsNullableDecimal\":\"1.23\"}").PropertyAsNullableDecimal);
        }

        [Test(Description = "测试用例：自定义 Newtosoft.Json.JsonConverter 之 TextualNumberConverter")]
        public void TestNewtosoftJsonConverter()
        {
            var jsonSettings = NewtonsoftJsonSerializer.GetDefaultSerializerSettings();
            jsonSettings.Formatting = Newtonsoft.Json.Formatting.None;
            jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            TestCustomJsonConverter(new NewtonsoftJsonSerializer(jsonSettings));
        }
    }
}