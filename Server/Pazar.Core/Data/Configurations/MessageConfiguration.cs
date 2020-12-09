using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pazar.Core.Data.Models;
using System;

namespace Pazar.Core.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property<string>("serializedData")
                .HasField("serializedData")
                .IsRequired();

            builder
                .Property(m => m.Type)
                .HasConversion(
                    t => t.AssemblyQualifiedName,
                    t => Type.GetType(t))
                .IsRequired();
        }
    }
}
