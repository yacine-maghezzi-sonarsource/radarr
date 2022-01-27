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
        public void should_get_unacceptable_with_accept_header(string header)
        {
            var sql = @"Update [User] SET FirstName = @FirstName WHERE Id = @Id";
            context.Database.ExecuteSqlCommand(
                sql,
                new SqlParameter("@FirstName", firstname),
                new SqlParameter("@Id", id));
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
                services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 6;


    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 3;

    options.SignIn.RequireConfirmedEmail = true;

    options.User.RequireUniqueEmail = true;
});

                //startup.cs
                services.ConfigureApplicationCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Expiration = TimeSpan.FromHours(1);


                 options.SlidingExpiration = true;
                });


            }

        }




    }
}
