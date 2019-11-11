using System;
using System.Collections.Generic;
using System.Text;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);
            builder.Property(ba => ba.BankName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(ba => ba.SWIFT).HasMaxLength(20).IsUnicode(false).IsRequired();
        }
    }
}
