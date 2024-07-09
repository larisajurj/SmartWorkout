using SmartWorkout.Components;
using SmartWorkout.DataAccess;
using SmartWorkout.DataAccess.Entities;
using SmartWorkout.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<IGenericRepo<User>, UserRepo>();
builder.Services.AddScoped<IGenericRepo<Exercise>, ExerciseRepo>();
builder.Services.AddScoped<IGenericRepo<Trainer>, TrainerRepo>();
builder.Services.AddScoped<IGenericRepo<Workout>, WorkoutRepo>();

builder.Services.AddDbContext<SmartWorkoutContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
