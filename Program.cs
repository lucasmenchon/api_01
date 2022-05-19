using Microsoft.AspNetCore.Mvc;

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

//api.app.com/users?datastart={date}&dataend={date} < "exemplo enviar relatorio" > via query string
app.MapGet("/getproduct", ([FromQuery]string dateStart, string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

//api.app.com/user/{code} < via rota "pertence a x endpoint" < e obrigatorio
app.MapGet("/getproduct/{code}", ([FromRoute]string code) => {
    return code;
});

//atraves do header solicitante
app.MapGet("/getproductheader", (HttpRequest request) => { 
    return request.Headers["product-code"].ToString();
});

app.Run();

public class Product
{
    
    public string Code { get; set; }

    public string Name { get; set; }
}