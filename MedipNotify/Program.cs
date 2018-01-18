using System;
using System.Threading;
using Newtonsoft.Json;
using RestSharp;

namespace MedipNotify
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"{DateTime.Now} - Rozpoczynam wyszukiwanie..");

                var result = Execute();

                if (result.Appointments.Length > 0)
                {
                    Console.WriteLine($"{DateTime.Now} - Znalazłem wolnych terminów = {result.Appointments.Length}");
                    foreach (var app in result.Appointments)
                    {
                        Console.WriteLine(
                            $"Data='{app.DateTime}', Doctor='{app.Doctor.Description}', Clinic='{app.Clinic.Description}', Duration='{app.Duration}'");
                    }
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now} - nic");
                }

                Console.WriteLine($"{DateTime.Now} - Zakończyłem wyszukiwanie!");
                Thread.Sleep(1000 * 60);
            }
        }

        private static Result Execute()
        {
            RestClient client = new RestClient("https://rezerwacjawizyt.pl/api/searchAppointment/Search");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "6497f907-84f6-18e6-9988-9b8ddcb8da19");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("referer", "https://rezerwacjawizyt.pl/");
            request.AddHeader("accept-encoding", "gzip, deflate, br");
            request.AddHeader("accept-language", "pl-PL,pl;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("user-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            request.AddHeader("origin", "https://rezerwacjawizyt.pl");
            request.AddHeader("host", "rezerwacjawizyt.pl");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                @"{
	                'StartDate': '2018-01-18T07: 46: 11.174Z',
	                'Vendor': 'MediPartner',
	                'Vendors': ['MediPartner'],
	                'EndDate': '2018-02-10T17: 46: 11.000Z',
	                'region': {
		                'DictionaryType': 1,
		                'Code': '204',
		                'Description': 'Warszawa/Piaseczno'
	                },
	                'clinic': {
		                'Description': 'Wszystkie',
		                'Code': null
	                },
	                'specialization': {
		                'DictionaryType': 3,
		                'Code': 'K198',
		                'Description': 'Okulistadorośli'
	                },
	                'language': null,
	                'languageCode': null,
	                'doctor': null,
	                'doctorCode': null,
	                'clinicCode': null,
	                'regionCode': '204',
	                'specializationCode': 'K198'
                }", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            Result json = JsonConvert.DeserializeObject<Result>(content);

            return json;
        }
    }
}