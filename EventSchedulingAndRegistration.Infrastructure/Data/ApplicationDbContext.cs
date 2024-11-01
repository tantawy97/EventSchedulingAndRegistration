﻿using EventSchedulingAndRegistration.Application.Data;
using EventSchedulingAndRegistration.Domain.Abstract;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventSchedulingAndRegistration.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeletedEntity).IsAssignableFrom(entityType.ClrType))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }
        base.OnModelCreating(builder);
    }
}
