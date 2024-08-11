using backend.Models;
using Newtonsoft.Json;

namespace backend.Seeds
{
    public class CategoryProductSeed
    {
        private readonly FinalContext db = new FinalContext();
        private static CategoryProductSeed instance;
        public static CategoryProductSeed Instance
        {
            get { if (instance == null) instance = new CategoryProductSeed(); return CategoryProductSeed.instance; }
            private set { CategoryProductSeed.instance = value; }
        }
        public async Task<int> GetInformation()
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://api-gateway.pharmacity.vn/api/category?slug=duoc-pham");
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var data = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                        return 1;
                    }
                }catch (Exception ex)
                {
                    return 0;
                }
            }
            return 0;
        }

    }
}
