using DeShawns.blueprint;
using DeShawns.blueprint.DTOs;

List<Dog> dogs = new List<Dog>
{
    new Dog() { Id = 1, Name = "Dianemarie Hartness", WalkerId = 3 },
    new Dog() { Id = 2, Name = "Christoph Fosdyke", WalkerId = 10},
    new Dog() { Id = 3, Name = "Rocket", WalkerId = 7},
    new Dog() { Id = 4, Name = "Ebony", WalkerId = 3},
    new Dog() { Id = 5, Name = "Scotty", WalkerId = 8},
    new Dog() { Id = 6, Name = "Mac", WalkerId = 2},
    new Dog() { Id = 7, Name = "Oreo", WalkerId = 5},
    new Dog() { Id = 8, Name = "Sassy", WalkerId = 1},
    new Dog() { Id = 9, Name = "Salem", WalkerId = 9},
    new Dog() { Id = 10, Name = "Panda", WalkerId = 7}
};

List<Walker> walkers = new List<Walker>
{
    new Walker() { Id = 1, Name = "Alphonse Meron", Email = "ameron0@mashable.com", City = "Chicago"},
    new Walker() { Id = 2, Name = "Damara Pentecust", Email = "dpentecust1@apache.org", City = "White Plains"},
    new Walker() { Id = 3, Name = "Anna Bowton", Email = "abowton2$wisc.edu", City = "Sarasota"},
    new Walker() { Id = 4, Name = "Hunfredo Drynan", Email = "hdrynan3@bizjournals.com", City = "San Diego"},
    new Walker() { Id = 5, Name = "Elmira Bick", Email = "ebick@biblegateway.com", City = "Boise"},
    new Walker() { Id = 6, Name = "Bernie Dreger", Email = "bdreager5@zimbio.com", City = "Denver"},
    new Walker() { Id = 7, Name = "Rolando Gault", Email = "rgault6@google.com", City = "Tucson"},
    new Walker() { Id = 8, Name = "Tiffanie Tubby", Email = "ttubby7@intel.com", City = "Phoenix"},
    new Walker() { Id = 9, Name = "Tomlin Cutill", Email = "tcutill8@marketwatch.com", City = "Minneapolis"},
    new Walker() { Id = 10, Name = "Arv Biddle0", Email = "abiddle9@cafepress.com", City = "Pittsburgh"}
};


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

app.MapGet("/api/hello", () =>
{
    return new { Message = "Welcome to DeShawn's Dog Walking" };
});

app.MapGet("/api/Dogs", () =>
{
    Walker walker = walkers.FirstOrDefault(w => w.Id == dogs.WalkerId);
    return dogs.Select(dog => new Dog
    {
        Id = dog.Id,
        Name = dog.Name,
        WalkerId = dog.WalkerId
    });
});


app.Run();
