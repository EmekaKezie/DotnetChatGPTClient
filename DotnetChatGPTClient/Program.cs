using DotnetChatGPTClient;
using Newtonsoft.Json;
using System.Text;


using (HttpClient client = new())
{
    Console.Write("Write your question: ");
    string? entry = Console.ReadLine();

    try
    {
        if (!string.IsNullOrEmpty(entry))
        {
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {Constants.Key}");

            GPTModel gptModel = new()
            {
                model = "text-davinci-001",
                prompt = entry!,
                temperature = 1,
                max_tokens = 100
            };


            string stringifyModel = JsonConvert.SerializeObject(gptModel);
            var content = new StringContent(stringifyModel, Encoding.UTF8, "application/json");


            HttpResponseMessage response = await client.PostAsync(Constants.UrlEndpoint, content);
            string responseString = await response.Content.ReadAsStringAsync();


            var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dyData?.choices[0].text);
        }
        else
        {
            Console.WriteLine("I couldn't get your question");
        }

        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}