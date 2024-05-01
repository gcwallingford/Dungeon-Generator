using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using DungeonGenerator;
using SkiaSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => "Hello!" );

app.MapGet("/generate", () =>
{
    using (var bitmap = new SKBitmap(50, 50))
    {
        using (var canvas = new SKCanvas(bitmap))
        {
            canvas.Clear(SKColors.White);
            return bitmap;
        }
        
    }
});

app.MapGet("/greendots", () =>
{
    using (var bitmap = new SKBitmap(100, 100))
    {
        bitmap.SetPixel(90, 10, SKColors.Chartreuse);
        bitmap.SetPixel(10, 10, SKColors.Chartreuse);
        var data = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
        var imageBytes = data.ToArray();
        return Results.Bytes(imageBytes, "image/png", "image.png");
    }

});

app.MapGet("/hallwayendpoint", () =>
{
    var buildingGen = new BuildingGenerator(2);
    
    int numberOfRows = buildingGen.building.Floors[0].Tiles.GetLength(0);
    int numberOfColumns = buildingGen.building.Floors[0].Tiles.GetLength(1);
    
    using (var bitmap = new SKBitmap(20, 20))
    {
        buildingGen.building.GenerateFloorMaze(buildingGen.building.Floors[0]);
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < numberOfColumns; column++)
            {
                if (buildingGen.building.Floors[0].Tiles[row, column].Type == TileType.Floor)
                {
                    bitmap.SetPixel(row, column, SKColors.Sienna);
                }
                else if (buildingGen.building.Floors[0].Tiles[row, column].Type == TileType.Wall)
                {
                    bitmap.SetPixel(row, column, SKColors.Gray);
                }
                else
                {
                    bitmap.SetPixel(row, column, SKColors.Black);
                }
            }
        }
    }
});

app.MapGet("/BuildingGenerator", () =>
{
    var generatedBuilding = new BuildingGenerator(1);
    using (var bitmap = new SKBitmap(20, 20))
    {
        int numberOfRows = generatedBuilding.building.Floors[0].Tiles.GetLength(0);
        int numberOfColumns = generatedBuilding.building.Floors[0].Tiles.GetLength(1);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < numberOfColumns; column++)
            {
                if (generatedBuilding.building.Floors[0].Tiles[row, column].Type == TileType.Floor)
                {
                    bitmap.SetPixel(row, column, SKColors.Sienna);
                }
                else if (generatedBuilding.building.Floors[0].Tiles[row, column].Type == TileType.Wall)
                {
                    bitmap.SetPixel(row, column, SKColors.Gray);
                }
                else
                {
                    bitmap.SetPixel(row, column, SKColors.Black);
                }
            }
        }

        var data = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
        var imageBytes = data.ToArray();
        return Results.Bytes(imageBytes, "image/png", "image.png");
    }
});

app.MapGet("/CaveGenerator", () =>  
{
    //Creating generator object
    var generatedCave = new CaveGenerator();
    
    //Creating bitmap image object
    using (var bitmap = new SKBitmap(20, 20))
    {
        //Finding information on rows & columns
        int numberOfRows = generatedCave.Cave.Floors[0].Tiles.GetLength(0);
        int numberOfColumns = generatedCave.Cave.Floors[0].Tiles.GetLength(1);
        
        //for each column in each row...
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int column = 0; column < numberOfColumns; column++)
            {
                if (generatedCave.Cave.Floors[0].Tiles[row, column].Type == TileType.Floor)
                {
                    bitmap.SetPixel(row, column, SKColors.Sienna);
                }
                else
                {
                    bitmap.SetPixel(row, column, SKColors.Black);
                }
            }
        }
        var data = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
        var imageBytes = data.ToArray();
        return Results.Bytes(imageBytes, "image/png", "image.png");
    }
    
});                                                                

app.MapGet("/example", (HttpContext context) =>
{
    string imagePath =
        "/Users/guywallingford/Documents/GitHub/Dungeon-Generator/DungeonGenerator/src/DungeonGenerator/Shark.jpeg";

    if (File.Exists(imagePath))
    {
        var imageBytes = File.ReadAllBytes(imagePath);
        //context.Response.Headers.Append("Content-Type", "image/jpeg");
        return Results.Bytes(imageBytes, "image/jpeg", "image.jpeg");//   .Ok(imageBytes);;
    }
    else
    {
        return Results.NotFound("Image not found");
    }
});



app.Run();