

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "SimpleCommand.Tests\App.config"
//     Connection String Name: "CRM"
//     Connection String:      "Data Source=BSBZGV1\MSSQLSERVER2012;Initial Catalog=CRM;Integrated Security=True"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration;
using System.Threading;
using System.Threading.Tasks;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace SimpleCommand
{
    // ************************************************************************
    // Unit of work
    public interface ICrmDbContext : IDisposable
    {
        IDbSet<Customer> Customers { get; set; } // Customers

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
        // Stored Procedures
    }

    // ************************************************************************
    // Database context
    public class CrmDbContext : DbContext, ICrmDbContext
    {
        public IDbSet<Customer> Customers { get; set; } // Customers
        
        static CrmDbContext()
        {
            Database.SetInitializer<CrmDbContext>(null);
        }

        public CrmDbContext()
            : base("Name=CRM")
        {
        }

        public CrmDbContext(string connectionString) : base(connectionString)
        {
        }

        public CrmDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration(schema));
            return modelBuilder;
        }
        
        // Stored Procedures
    }

    // ************************************************************************
    // Fake Database context
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.1.0")]
    public class FakeCrmDbContext : ICrmDbContext
    {
        public IDbSet<Customer> Customers { get; set; }

        public FakeCrmDbContext()
        {
            Customers = new FakeDbSet<Customer>();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        
        // Stored Procedures
    }

    // ************************************************************************
    // Fake DbSet
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.13.1.0")]
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly HashSet<T> _data;

        public FakeDbSet()
        {
            _data = new HashSet<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public void Detach(T item)
        {
            _data.Remove(item);
        }

        Type IQueryable.ElementType
        {
            get { return _data.AsQueryable().ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _data.AsQueryable().Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _data.AsQueryable().Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public ObservableCollection<T> Local
        {
            get
            {
                return new ObservableCollection<T>(_data);
            }
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
    }

    // ************************************************************************
    // POCO classes

    // Customers
    public class Customer
    {
        public int CustomerId { get; set; } // CustomerId (Primary key)
        public string CustomerFirstName { get; set; } // CustomerFirstName
        public string CustomerMarket { get; set; } // CustomerMarket
        public int BillToAddressId { get; set; } // BillToAddressId
        public int ShipToAddressId { get; set; } // ShipToAddressId
        public string CustomerLastName { get; set; } // CustomerLastName
    }


    // ************************************************************************
    // POCO Configuration

    // Customers
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Customers");
            HasKey(x => x.CustomerId);

            Property(x => x.CustomerId).HasColumnName("CustomerId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.CustomerFirstName).HasColumnName("CustomerFirstName").IsOptional().HasMaxLength(50);
            Property(x => x.CustomerMarket).HasColumnName("CustomerMarket").IsOptional().HasMaxLength(25);
            Property(x => x.BillToAddressId).HasColumnName("BillToAddressId").IsRequired();
            Property(x => x.ShipToAddressId).HasColumnName("ShipToAddressId").IsRequired();
            Property(x => x.CustomerLastName).HasColumnName("CustomerLastName").IsOptional().HasMaxLength(50);
        }
    }


    // ************************************************************************
    // Stored procedure return models

}

