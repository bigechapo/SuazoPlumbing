using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Handle form submission
app.MapPost("/contact", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();

    var name = form["name"];
    var email = form["email"];
    var message = form["message"];

    var smtp = new SmtpClient("smtp.gmail.com")
    {
        Port = 587,
        Credentials = new NetworkCredential("plumbprosuazo@gmail.com", "YOUR_APP_PASSWORD"),
        EnableSsl = true,
    };

    var mail = new MailMessage
    {
        From = new MailAddress("plumbprosuazo@gmail.com"),
        Subject = $"New Contact Form Message from {name}",
        Body = $"Email: {email}\n\nMessage:\n{message}"
    };

    mail.To.Add("plumbprosuazo@gmail.com");

    await smtp.SendMailAsync(mail);

    return Results.Redirect("/Contact.html");
});

app.Run();
