using System.IO;
using System.Threading.Tasks;
using GunterExtension.Json;
using GunterExtension.Models.RunTest;
using Mailr.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace GunterExtension.Mvc.ModelBinding
{
    public class EmailBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using (var bodyReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                var body = await bodyReader.ReadToEndAsync();
                var email = JsonConvert.DeserializeObject<Email<ResultBody>>(body);
                bindingContext.Result = ModelBindingResult.Success(email);
            }
        }
    }
}