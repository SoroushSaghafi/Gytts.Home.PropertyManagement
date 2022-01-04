namespace Gytts.Home.PropertyManagement.API;

public static class PropertyAPI
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoint mapping
        app.MapGet("/Properties", GetProperties);
        app.MapGet("/Properties/{id}", GetProperty);
        app.MapPost("/Properties", InsertProperty);
        app.MapPut("/Properties", UpdateProperty);
        app.MapDelete("/Properties", DeleteProperty);
    }

    private static async Task<IResult> GetProperties(IPropertyData data)
    {
        try
        {
            return Results.Ok(await data.GetProperties());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetProperty(int id, IPropertyData data)
    {
        try
        {
            var results = await data.GetProperty(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertProperty(PropertyEntity Property, IPropertyData data)
    {
        try
        {
            await data.InsertProperty(Property);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateProperty(PropertyEntity Property, IPropertyData data)
    {
        try
        {
            await data.UpdateProperty(Property);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteProperty(int id, IPropertyData data)
    {
        try
        {
            await data.DeleteProperty(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
