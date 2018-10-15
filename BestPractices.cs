// Example 1: Avoid Mental Mapping

using System.Linq;

namespace CleanCodeDotNet.Variables
{
    public class AvoidMentalMapping
    {
        public AvoidMentalMapping()
        {
            // Bad
            var l = new[] { "Austin", "New York", "San Francisco" };
        
            for(var i = 0; i < l.Count(); i++)
            {
                var li = l[i];
                DoStuff();
                DoSomeOtherStuff();
                
                // ...
                // ...
                // ...
                // umm...what is 'li' for??
                Dispatch(li);
            }
            
            // Good
            var locations = new[] { "Austin", "New York", "San Francisco" };
            
            foreach(var location in locations)
            {
                DoStuff();
                DoSomeOtherStuff();
                
                // ...
                // ...
                // ...
                Dispatch(location);
            }
        }
        
        private string DoStuff()
        {
            return "dummy";
        }
        
        private string DoSomeOtherStuff()
        {
            return "dummy";
        }
        
        private string Dispatch(string li)
        {
            return li;
        }
    }
}


// Example 2: Avoid Nesting Too Deeply, Return Early

using System.Linq;

namespace CleanCodeDotNet.Variables
{
    public class AvoidNestingTooDeeplyReturnEarly
    {
        public AvoidNestingTooDeeplyReturnEarly()
        {
            // Bad
            IsShopOpenBadWay("friday");
            FibonacciBadWay(8);
            
            // Good
            IsShopOpenGoodWay("friday");
            FibonacciGoodWay(8);
        }
        
        private bool IsShopOpenBadWay(string day)
        {
            if(string.IsNullOrEmpty(day))
            {
                day = day.ToLower();
                
                if(day == "friday")
                {
                    return true;
                }
                else if(day == "saturday")
                {
                    return true;
                }
                else if(day == "sunday")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        private bool IsShopOpenGoodWay(string day)
        {
            if(string.IsNullOrEmpty(day))
            {
                return false;
            }
            
            var openingDays = new string[] { "friday", "saturday", "sunday" };
            
            return openingDays.Any(d => d == day.ToLower());
        }
        
        private long FibonacciBadWay(int n)
        {
            if(n < 50)
            {
                if(n != 0)
                {
                    if(n != 1)
                    {
                        return FibonacciBadWay(n - 1) + FibonacciBadWay(n - 2);
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new System.Exception("Not supported");
            }
        }
        
        private long FibonacciGoodWay(int n)
        {
            if(n == 0)
            {
                return 0;
            }
            
            if(n == 1)
            {
                return 1;
            }
            
            if(n > 50)
            {
                throw new System.Exception("Not supported");
            }
            
            return FibonacciGoodWay(n - 1) + FibonacciGoodWay(n - 2);
        }
    }
}

// Example 3: Don’t Add Un-Needed Context

namespace CleanCodeDotNet.Variables
{
    public class DontAddUnNeededContext
    {
        public DontAddUnNeededContext()
        {
            
        }
    }
    
    // Bad
    public class CarBadWay
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        
        // ...
    }
    
    // Good
    public class CarGoodWay
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        
        // ...
    }
}

// Example 4: Use Default Arguments Instead of Short Circuiting or Conditionals

namespace CleanCodeDotNet.Variables
{
    public class UseDefaultArgumentsInsteadOfShortCircuitingOrConditionals()
    {
        public UseDefaultArgumentsInsteadOfShortCircuitingOrConditionals()
        {
            CreateMicrobreweryBadWay();
            CreateMicrobreweryGoodWay();
        }
        
        public void CreateMicrobreweryBadWay(string name = null)
        {
            var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
            // ...
        }
        
        public void CreateMicrobreweryGoodWay(string breweryName = "Hipster Brew Co.")
        {
            // ...
        }
    }
}

// Example 5: Use Explanatory Variables

using System.Text.RegularExpressions;

namespace CleanCodeDotNet.Variables
{
    /// <summary>
    /// Reference @ https://docs.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions
    /// </summary>
    public class UseExplanatoryVariables
    {
        private const string Address = "One Infinite Loop, Chicago 60123";
        
        public UseExplanatoryVariables()
        {
            var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
            var matches = Regex.Matches(Address, cityZipCodeRegex);
            
            // Bad
            if(matches[0].Success == true && matches[1].Success == true)
            {
                SaveCityZipCode(matches[0].Value, matches[1].Value);
            }
            
            // Good
            var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
            var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
            var cityGroup = matchesWithGroup.Groups["city"];
            var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
            
            if(cityGroup.Success == true && zipCodeGroup.Success == true)
            {
                SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
            }
        }
        
        private bool SaveCityZipCode(string city, string zipCode)
        {
            // do saving
            
            return true;
        }
    }
}

// Example 6: Use Meaningful and Pronounceable Variable Names

using System;

namespace CleanCodeDotNet.Variables
{
    public class UseMeaningfulAndPronounceableVariableNames
    {
        public UseMeaningfulAndPronounceableVariableNames()
        {
            // Bad
            var ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");
            
            // Good
            var currentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");
        }
    }
}
 
// Example 7: Use Same Vocabulary for Same Type Variables

namespace CleanCodeDotNet.Variables
{
    public class UseSameVocabularyForSameTypeVariables
    {
        public UseSameVocabularyForSameTypeVariables()
        {
            // Bad
            GetUserInfo();
            GetUserData();
            GetUserRecord();
            GetUserProfile();
            
            // Good
            GetUser();
        }
        
        private object GetUserInfo() { return "dummy"; }
        private object GetUserData() { return "dummy"; }
        private object GetUserRecord() { return "dummy"; }
        private object GetUserProfile() { return "dummy"; }
        private object GetUser() { return "dummy"; }
    }
}

// Example 8: Use Searchable Names

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CleanCodeDotNet.Variables
{
    public enum PersonAccess : int
    {
        ACCESS_READ = 1,
        ACCESS_CREATE = 2,
        ACCESS_UPDATE = 4,
        ACCESS_DELETE = 8
    }
    
    /// <summary>
    /// Reference at https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
    /// </summary>
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string Name { get; set; }
        
        [DataMember]
        internal int Age { get; set; }
        
        [DataMember]
        internal PersonAccess PersonAccess { get; set; }
    }
    
    public class UseSearchableNames
    {
        public UseSearchableNames()
        {
            UseSearchableNames1();
            UseSearchableNames2();
        }
        
        private void UserSearchableNames()
        {
            // Bad
            // um...
            var data = new { Name = "John", Age = 42 };
            
            var stream1 = new MemoryStream();
            DataContractJsonSerializer ser1 = new DataContractJsonSerializer(typeof(object));
            ser1.WriteObject(stream1, data);
            
            stream1.Position = 0;
            var sr1 = new StreamReader(stream1);
            Console.Write("JSON form of Data object: ");
            Console.WriteLine(sr1.ReadToEnd());
            
            // Good
            var person = new Person
            {
                Name = "John",
                Age = 42
            };
            
            var stream2 = new MemoryStream();
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Person));
            ser2.WriteObject(stream2, data);
            
            stream2.Position = 0;
            StreamReader sr2 = new StreamReader(stream2);
            Console.Write("JSON form of Data object: ");
            Console.WriteLine(sr2.ReadToEnd());
        }
        
        private void UserSearchableNames2()
        {
            // Bad
            var data = new { Name = "John", Age = 42, PersonAccess = 4 };
            
            // What is 4 for?
            if(data.PersonAccess == 4)
            {
                // do edit ...
            }
            
            // Good
            var person = new Person
            {
                Name = "John",
                Age = 42,
                PersonAccess = PersonAccess.ACCESS_CREATE
            };
            if(person.PersonAccess == PersonAccess.ACCESS_UPDATE)
            {
                // do edit ...
            }
        }
    }
}
