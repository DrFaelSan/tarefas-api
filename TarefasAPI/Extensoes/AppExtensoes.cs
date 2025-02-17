namespace TarefasAPI.Extensoes;

public static class AppExtensoes
{
    public static WebApplication UseService(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        return app;

    }
}
