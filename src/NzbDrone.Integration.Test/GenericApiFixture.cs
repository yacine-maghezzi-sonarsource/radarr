using System.Net;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace NzbDrone.Integration.Test
{
    [TestFixture]
    public class GenericApiFixture : IntegrationTest
    {
        [TestCase("application/json")]
        [TestCase("text/html, application/json")]
        [TestCase("application/xml, application/json")]
        [TestCase("text/html, */*")]
        [TestCase("*/*")]
        [TestCase("")]
        public void should_get_json_with_accept_header(string header)
        {
            var request = new RestRequest("system/status")
            {
                RequestFormat = DataFormat.None
            };
            request.AddHeader("Accept", header);

            var response = RestClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.ContentType.Should().Be("application/json; charset=utf-8");
        }

        [TestCase("application/xml")]
        [TestCase("text/html")]
        [TestCase("application/junk")]
        public void should_get_unacceptable_with_accept_header(string header)
        {
            var request = new RestRequest("system/status")
            {
                RequestFormat = DataFormat.None
            };
            request.AddHeader("Accept", header);

            var response = RestClient.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotAcceptable);
        }
        public string should_get_unacceptable_with_accept_bis(string header)
        {
            var sql = @"Update [User] SET FirstName = @FirstName WHERE Id = @Id";
            this.Database.ExecuteSqlCommand(
                sql,
                new SqlParameter("@FirstName", "hello"),
                new SqlParameter("@Id", "4"));
            //User input
            string ipAddress = "127.0.0.1";

            //check to make sure an ip address was provided
            if (!string.IsNullOrEmpty(ipAddress))
            {
                // Create an instance of IPAddress for the specified address string (in
                // dotted-quad, or colon-hexadecimal notation).
                if (IPAddress.TryParse(ipAddress, out var address))
                {
                    // Display the address in standard notation.
                    return address.ToString();
                }
              
        

            }

        }




    }
}
