using NUnit.Framework;

namespace SKIT.FlurlHttpClient.UnitTests.TestCases
{
    public class TestCase_JsonConverterOfNumericalBooleanReadOnlyTest
    {
        private sealed class MockObject
        {
            [Newtonsoft.Json.JsonProperty(Order = 1)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.NumericalBooleanReadOnlyConverter))]
            [System.Text.Json.Serialization.JsonPropertyOrder(1)]
            [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.Common.NumericalBooleanReadOnlyConverter))]
            public bool Property { get; set; }

            [Newtonsoft.Json.JsonProperty(Order = 2)]
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.Common.NumericalBooleanReadOnlyConverter))]
            [System.Text.Json.Serialization.JsonPropertyOrder(2)]
            [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.Common.NumericalBooleanReadOnlyConverter))]
            public bool? NullableProperty { get; set; }
        }

        private static void TestCustomJsonConverter(IJsonSerializer jsonSerializer)
        {
            Assert.Multiple(() =>
            {
                var expectObj = new MockObject() { NullableProperty = null };
                var actualJson = jsonSerializer.Serialize(expectObj);
                var actualObj = jsonSerializer.Deserialize<MockObject>(actualJson);

                Assert.That(actualJson, Is.EqualTo("{\"Property\":false}"));

                Assert.That(actualObj.Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"Property\":0}").Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{}").Property, Is.EqualTo(expectObj.Property));

                Assert.That(actualObj.NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"NullableProperty\":null}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
            });

            Assert.Multiple(() =>
            {
                var expectObj = new MockObject() { Property = false, NullableProperty = false };
                var actualJson = jsonSerializer.Serialize(expectObj);
                var actualObj = jsonSerializer.Deserialize<MockObject>(actualJson);

                Assert.That(actualJson, Is.EqualTo("{\"Property\":false,\"NullableProperty\":false}"));

                Assert.That(actualObj.Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"Property\":0}").Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"Property\":\"0\"}").Property, Is.EqualTo(expectObj.Property));

                Assert.That(actualObj.NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"NullableProperty\":0}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"NullableProperty\":\"0\"}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
            });

            Assert.Multiple(() =>
            {
                var expectObj = new MockObject() { Property = true, NullableProperty = true };
                var actualJson = jsonSerializer.Serialize(expectObj);
                var actualObj = jsonSerializer.Deserialize<MockObject>(actualJson);

                Assert.That(actualJson, Is.EqualTo("{\"Property\":true,\"NullableProperty\":true}"));

                Assert.That(actualObj.Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"Property\":1}").Property, Is.EqualTo(expectObj.Property));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"Property\":\"1\"}").Property, Is.EqualTo(expectObj.Property));

                Assert.That(actualObj.NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"NullableProperty\":1}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
                Assert.That(jsonSerializer.Deserialize<MockObject>("{\"NullableProperty\":\"1\"}").NullableProperty, Is.EqualTo(expectObj.NullableProperty));
            });
        }

        [Test(Description = "测试用例：自定义 Newtosoft.Json.JsonConverter 之 NumericalBooleanReadOnlyConverter")]
        public void TestNewtosoftJsonConverter()
        {
            var jsonSettings = NewtonsoftJsonSerializer.GetDefaultSerializerSettings();
            jsonSettings.Formatting = Newtonsoft.Json.Formatting.None;
            jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            TestCustomJsonConverter(new NewtonsoftJsonSerializer(jsonSettings));
        }

        [Test(Description = "测试用例：自定义 System.Text.Json.Serialization.JsonConverter 之 NumericalBooleanReadOnlyConverter")]
        public void TestSystemTextJsonConverter()
        {
            var jsonOptions = SystemTextJsonSerializer.GetDefaultSerializerOptions();
            jsonOptions.WriteIndented = false;
            jsonOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            jsonOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString;

            TestCustomJsonConverter(new SystemTextJsonSerializer(jsonOptions));
        }
    }
}
