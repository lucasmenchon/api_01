var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Enviar Msg
app.MapPost("/", () => new {Name= "Lucas Menchon", Age= 35});
app.MapGet("/AddHeader", (HttpResponse response) => {
response.Headers.Add("Header", "Lucas Menchon");
    return new {Name= "Lucas Menchon", Age= 35};
    });

//Api Post Produto
app.MapPost("/saveproduct", (Product product ) =>  {
return product.Code + " - " + product.Name;
});

app.Run();

public class Product
{
    
    public string Code { get; set; }

    public string Name { get; set; }
}