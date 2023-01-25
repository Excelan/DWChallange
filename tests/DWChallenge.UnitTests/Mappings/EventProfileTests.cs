using AutoMapper;
using DWChallange.Mappings;

namespace DWChallenge.UnitTests.Mappings
{
    public class EventProfileTests
    {
        [Fact]
        public void EventProfile_Configuration_IsValid() {
            var config = new MapperConfiguration(x => {
                x.AddProfile<RegistrationProfile>();
                x.AddProfile<EventProfile>();
            });
            config.AssertConfigurationIsValid();
        }
    }

}
