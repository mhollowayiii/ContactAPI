using ContactAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPITest
{
    // Used by the test fixures to get a collection of testable Contacts
    class DummyContacts
    {
        public List<Contact> Contacts { get; set; }

        public DummyContacts()
        {
            var testContact =
                @"{
                    ""name"": {
                        ""first"": ""testFirst"",
	                    ""middle"": ""testMiddle"",
	                    ""last"": ""testLast""
                    },
                    ""address"": {
	                    ""street"": ""123 Test St"",
	                    ""city"": ""Testville"",
	                    ""state"": ""Testaware"",
	                    ""zip"": ""12345""
                    },
                    ""phone"": [
	                    {
		                    ""number"": ""123-456-789"",
		                    ""type"": ""home""

                        },
	                    {
		                    ""number"": ""987-654-3210"",
		                    ""type"": ""mobile""
	                    }
                    ],
                    ""email"": ""Testy@test.com""
                }";

            var haroldGilkey =
                @"{
                    ""name"": {
                         ""first"": ""Harold"",
                         ""middle"": ""Francis"",
                         ""last"": ""Gilkey""
                    },
                    ""address"": {
                         ""street"": ""8360 High Autumn Row"",
                         ""city"": ""Cannon"",
                         ""state"": ""Delaware"",
                         ""zip"": ""19797""
                    },
                    ""phone"": [
                         {
                            ""number"": ""302-611-9148"",
                            ""type"": ""home""
                        },
                        {
                            ""number"": ""302-532-9427"",
                            ""type"": ""mobile""
                        }
                    ],
                    ""email"": ""harold.gilkey@yahoo.com""
                }";

            var noHomePhone =
                @"{
                    ""name"": {
                        ""first"": ""No"",
	                    ""middle"": ""Home"",
	                    ""last"": ""Phone""
                    },
                    ""address"": {
	                    ""street"": ""123 Test St"",
	                    ""city"": ""Testville"",
	                    ""state"": ""Testaware"",
	                    ""zip"": ""12345""
                    },
                    ""phone"": [
	                    {
		                    ""number"": ""987-654-3210"",
		                    ""type"": ""mobile""
	                    }
                    ],
                    ""email"": ""NoHomePhone@test.com""
                }";

            var lastAlphabetical =
                @"{
                    ""name"": {
                        ""first"": ""Zname"",
	                    ""middle"": ""Mid"",
	                    ""last"": ""Zname""
                    },
                    ""address"": {
	                    ""street"": ""123 Test St"",
	                    ""city"": ""Testville"",
	                    ""state"": ""Testaware"",
	                    ""zip"": ""12345""
                    },
                    ""phone"": [
	                    {
		                    ""number"": ""123-456-789"",
		                    ""type"": ""home""

                        },
	                    {
		                    ""number"": ""987-654-3210"",
		                    ""type"": ""mobile""
	                    }
                    ],
                    ""email"": ""NoHomePhone@test.com""
                }";

            // Using JsonConvert to build the test objects just because it's easy and I had the JSON handy
            Contacts = new List<Contact>();
            Contacts.Add(JsonConvert.DeserializeObject<Contact>(testContact));
            Contacts.Add(JsonConvert.DeserializeObject<Contact>(haroldGilkey));
            Contacts.Add(JsonConvert.DeserializeObject<Contact>(noHomePhone));
            Contacts.Add(JsonConvert.DeserializeObject<Contact>(lastAlphabetical));
        }
    }
}
