using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Enums;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using System.Diagnostics;
using porTIEVserver.Domain.Entities.eTraining;

namespace porTIEVserver.Infrastructure.Context
{
    internal sealed class FirmDbContext : DbContext, IUnitOfWorkFirm
    {
        private string connectionString = string.Empty;
        public FirmDbContext(Firm firm)
        {
            CreateConnecitonStringWithFirm(firm);
        }
        public FirmDbContext(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            CreateConnecitonString(httpContextAccessor, context);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        #region eBizService
        public DbSet<BizService>        PT_BizService      { get; set; }
        #endregion eBizService
        #region eCargo
        public DbSet<CargoAction>       PT_CargoActions { get; set; }
        public DbSet<CargoDetail>       PT_CargoDetails    { get; set; }
        public DbSet<CargoMain>         PT_CargoMains      { get; set; }
        public DbSet<Carrier>           PT_Carriers        { get; set; }
        public DbSet<Office>            PT_Offices         { get; set; }
        #endregion eCargo
        #region CRM
        public DbSet<Contact>           PT_Contacts        { get; set; }
        public DbSet<CrmAction>         PT_CrmActions      { get; set; }
        #endregion CRM
        #region FIN
        public DbSet<BankAccount>       PT_BankAccounts     { get; set; }
        public DbSet<Cashier>           PT_Cashiers         { get; set; }
        public DbSet<Customer>          PT_Customers        { get; set; }
        public DbSet<Trading>           PT_Tradings        { get; set; }
        #endregion FIN
        #region HR
        public DbSet<Personnel>         PT_Personnels       { get; set; }
        public DbSet<Presence>          PT_Presences        { get; set; }
        #endregion HR
        #region STK
        public DbSet<Product>           PT_Products           { get; set; }
        public DbSet<ProductStkUnit>    PT_ProductStkUnits    { get; set; }
        #endregion STK
        #region eTraining
        public DbSet<Branch>            PT_Branch             { get; set; }
        public DbSet<Classroom>         PT_Classroom          { get; set; }
        public DbSet<Course>            PT_Course             { get; set; }
        public DbSet<Participant>       PT_Participant        { get; set; }
        public DbSet<Partner>           PT_Partner            { get; set; }
        public DbSet<Status>            PT_Status             { get; set; }
        #endregion eTraining

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region eBizService
            #region eBizService BizService
            modelBuilder.Entity<BizService>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<BizService>().HasIndex(p => p.Code);
            modelBuilder.Entity<BizService>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<BizService>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<BizService>().Property(p => p.Name).HasColumnType("varchar(250)");
            modelBuilder.Entity<BizService>().Property(p => p.Desc).HasColumnType("varchar(max)");

            //modelBuilder.Entity<BizService>().HasIndex(p => new { p.TraderClientId, p.TraderServerId }).IsClustered();
            //modelBuilder.Entity<BizService>().HasIndex(p => new { p.StartDate }).IsClustered();

            #endregion eBizService BizService
            #endregion eBizService
            #region eCargo
            #region Cargo CargoAction
            modelBuilder.Entity<CargoAction>().HasKey(p => new { p.Ref });
            //modelBuilder.Entity<CargoAction>().HasIndex(p => p.CargoMainRef && p.CargoStatus);
            modelBuilder.Entity<CargoAction>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<CargoAction>().Property(p => p.CargoStatus).HasConversion(type => type.Value, value => CargoStatusEnum.FromValue(value));
            #endregion Cargo
            #region Cargo CargoDetail
            modelBuilder.Entity<CargoDetail>().HasKey(p => new { p.Ref });
            //modelBuilder.Entity<CargoDetail>().HasIndex(p => p.CargoMainRef && p.CargoDetailType);
            modelBuilder.Entity<CargoDetail>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyRate1).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyRate2).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyRate3).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Amount1      ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Amount2      ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Amount3      ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Total1       ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Total2       ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Total3       ).HasColumnType("money");
            modelBuilder.Entity<CargoDetail>().Property(p => p.Quantity     ).HasColumnType("money");

            modelBuilder.Entity<CargoDetail>().Property(p => p.CargoDetailType).HasConversion(type => type.Value,value => CargoDetailTypeEnum.FromValue(value));
            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyType1  ).HasConversion(type => type.Value,value =>    CurrencyTypeEnum.FromValue(value));
            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyType2  ).HasConversion(type => type.Value,value =>    CurrencyTypeEnum.FromValue(value));
            modelBuilder.Entity<CargoDetail>().Property(p => p.CurrencyType3  ).HasConversion(type => type.Value,value =>    CurrencyTypeEnum.FromValue(value));

            #endregion CargoDetail 
            #region Cargo CargoMain
            modelBuilder.Entity<CargoMain>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<CargoMain>().HasIndex(p => p.FicheNumber);
            modelBuilder.Entity<CargoMain>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<CargoMain>().Property(p => p.TradingType  ).HasConversion(type => type.Value, value =>   TradingTypeEnum.FromValue(value));
            modelBuilder.Entity<CargoMain>().Property(p => p.CargoStatus  ).HasConversion(type => type.Value, value =>   CargoStatusEnum.FromValue(value));
            modelBuilder.Entity<CargoMain>().Property(p => p.TransportType).HasConversion(type => type.Value, value => TransportTypeEnum.FromValue(value));
            #endregion Cargo CargoMain
            #region Cargo Carrier            
            modelBuilder.Entity<Carrier>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Carrier>().HasIndex(p => p.Code);
            modelBuilder.Entity<Carrier>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Carrier>().Property(p => p.Code    ).HasColumnType("varchar(50)");
            modelBuilder.Entity<Carrier>().Property(p => p.Name    ).HasColumnType("varchar(250)");
            modelBuilder.Entity<Carrier>().Property(p => p.Debit   ).HasColumnType("money");
            modelBuilder.Entity<Carrier>().Property(p => p.Credit  ).HasColumnType("money");
            modelBuilder.Entity<Carrier>().Property(p => p.Balance ).HasColumnType("money");

            modelBuilder.Entity<Carrier>().Property(p => p.CurrencyType).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            #endregion Cargo Carrier            
            #region Cargo Office            
            modelBuilder.Entity<Office>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Office>().HasIndex(p => p.Code);
            modelBuilder.Entity<Office>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Office>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Office>().Property(p => p.Name).HasColumnType("varchar(250)");
            #endregion Cargo Office
            #endregion eCargo 
            #region CRM
            #region CRM Contact
            modelBuilder.Entity<Contact>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Contact>().HasIndex(p => p.Code);
            modelBuilder.Entity<Contact>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Contact>().Property(p => p.Code     ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Contact>().Property(p => p.FirstName).HasColumnType("varchar(050)");
            modelBuilder.Entity<Contact>().Property(p => p.LastName ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Contact>().Property(p => p.Phone    ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Contact>().Property(p => p.Mobile   ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Contact>().Property(p => p.Email    ).HasColumnType("varchar(100)");

            modelBuilder.Entity<Contact>().Property(p => p.ContactType).HasConversion(type => type.Value,value => ContactTypeEnum.FromValue(value));
            #endregion Contact
            #region CRM CrmAction 
            modelBuilder.Entity<CrmAction>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<CrmAction>().HasIndex(p => p.FicheNumber);
            modelBuilder.Entity<CrmAction>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<CrmAction>().Property(p => p.FicheNumber   ).HasColumnType("varchar(050)");
            modelBuilder.Entity<CrmAction>().Property(p => p.DocumentNumber).HasColumnType("varchar(050)");
            modelBuilder.Entity<CrmAction>().Property(p => p.Description1  ).HasColumnType("varchar(250)");
            modelBuilder.Entity<CrmAction>().Property(p => p.Description2  ).HasColumnType("varchar(250)");
            modelBuilder.Entity<CrmAction>().Property(p => p.Description3  ).HasColumnType("varchar(250)");
            modelBuilder.Entity<CrmAction>().Property(p => p.Description4  ).HasColumnType("varchar(250)");
            modelBuilder.Entity<CrmAction>().Property(p => p.Description5  ).HasColumnType("varchar(250)");

            modelBuilder.Entity<CrmAction>().Property(p => p.CrmActionType).HasConversion(type => type.Value, value => CrmActionTypeEnum.FromValue(value));
            #endregion CrmAction
            #endregion
            #region FIN
            #region FIN BankAccount
            modelBuilder.Entity<BankAccount>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<BankAccount>().HasIndex(p => p.Code);
            modelBuilder.Entity<BankAccount>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<BankAccount>().Property(p => p.Code        ).HasColumnType("varchar(50)");
            modelBuilder.Entity<BankAccount>().Property(p => p.Debit       ).HasColumnType("money");
            modelBuilder.Entity<BankAccount>().Property(p => p.Credit      ).HasColumnType("money");
            modelBuilder.Entity<BankAccount>().Property(p => p.Balance     ).HasColumnType("money");
            modelBuilder.Entity<BankAccount>().Property(p => p.CurrencyType).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            #endregion FIN BankAccount
            #region FIN Cashier
            modelBuilder.Entity<Cashier>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Cashier>().HasIndex(p => p.Code);
            modelBuilder.Entity<Cashier>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Cashier>().Property(p => p.Code        ).HasColumnType("varchar(50)");
            modelBuilder.Entity<Cashier>().Property(p => p.Debit       ).HasColumnType("money");
            modelBuilder.Entity<Cashier>().Property(p => p.Credit      ).HasColumnType("money");
            modelBuilder.Entity<Cashier>().Property(p => p.Balance     ).HasColumnType("money");
            modelBuilder.Entity<Cashier>().Property(p => p.CurrencyType).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            #endregion FIN Cashier
            #region FIN Customer
            modelBuilder.Entity<Customer>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Customer>().HasIndex(p => p.Code);
            modelBuilder.Entity<Customer>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Customer>().Property(p => p.Code        ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Customer>().Property(p => p.FirstName   ).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().Property(p => p.LastName    ).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().Property(p => p.Debit       ).HasColumnType("money");
            modelBuilder.Entity<Customer>().Property(p => p.Credit      ).HasColumnType("money");
            modelBuilder.Entity<Customer>().Property(p => p.Balance     ).HasColumnType("money");

            modelBuilder.Entity<Customer>().Property(p => p.CustomerType).HasConversion(type => type.Value,value => CustomerTypeEnum.FromValue(value));
            modelBuilder.Entity<Customer>().Property(p => p.FirmType    ).HasConversion(type => type.Value,value =>     FirmTypeEnum.FromValue(value));
            modelBuilder.Entity<Customer>().Property(p => p.CurrencyType).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));

            #endregion FIN Customer
            #region FIN Trading
            modelBuilder.Entity<Trading>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Trading>().HasIndex(p => p.FicheNumber);
            modelBuilder.Entity<Trading>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Trading>().Property(p => p.DebitCurrRate).HasColumnType("money");
            modelBuilder.Entity<Trading>().Property(p => p.CreditCurrRate).HasColumnType("money");
            modelBuilder.Entity<Trading>().Property(p => p.DebitAmount).HasColumnType("money");
            modelBuilder.Entity<Trading>().Property(p => p.CreditAmount).HasColumnType("money");
            modelBuilder.Entity<Trading>().Property(p => p.DebitDescription).HasColumnType("varchar(250)");
            modelBuilder.Entity<Trading>().Property(p => p.CreditDescription).HasColumnType("varchar(250)");

            modelBuilder.Entity<Trading>().Property(p => p.TradingType     ).HasConversion(type => type.Value, value =>  TradingTypeEnum.FromValue(value));
            modelBuilder.Entity<Trading>().Property(p => p.DebitTraderType ).HasConversion(type => type.Value, value =>   TraderTypeEnum.FromValue(value));
            modelBuilder.Entity<Trading>().Property(p => p.CreditTraderType).HasConversion(type => type.Value, value =>   TraderTypeEnum.FromValue(value));
            modelBuilder.Entity<Trading>().Property(p => p.DebitCurrType   ).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            modelBuilder.Entity<Trading>().Property(p => p.CreditCurrType  ).HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
            #endregion FIN Trading
            #endregion FIN
            #region HR
            #region HR Personnel
            modelBuilder.Entity<Personnel>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Personnel>().HasIndex(p => p.Code);
            modelBuilder.Entity<Personnel>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Personnel>().Property(p => p.Code     ).HasColumnType("varchar(050)");
            modelBuilder.Entity<Personnel>().Property(p => p.FirstName).HasColumnType("varchar(250)");
            modelBuilder.Entity<Personnel>().Property(p => p.LastName ).HasColumnType("varchar(250)");
            modelBuilder.Entity<Personnel>().Property(p => p.Debit    ).HasColumnType("money");
            modelBuilder.Entity<Personnel>().Property(p => p.Credit   ).HasColumnType("money");
            modelBuilder.Entity<Personnel>().Property(p => p.Balance  ).HasColumnType("money");
            #endregion HR Personnel
            #region HR Presence
            modelBuilder.Entity<Presence>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Presence>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Presence>().Property(p => p.ScanCode).HasColumnType("varchar(250)");
            #endregion HR Presence            
            #endregion HR
            #region STK
            #region STK Product            
            modelBuilder.Entity<Product>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Product>().HasIndex(p => p.Code);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Product>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("varchar(250)");
            modelBuilder.Entity<Product>().Property(p => p.ProductType).HasConversion(type => type.Value,value => ProductTypeEnum.FromValue(value));
            #endregion STK Product
            #region STK ProductStkUnit            
            modelBuilder.Entity<ProductStkUnit>().HasKey(p => new { p.Ref });
            //modelBuilder.Entity<ProductStkUnit>().HasIndex(p => p.ProductRef && p.StkUnitRef);
            modelBuilder.Entity<ProductStkUnit>().HasQueryFilter(p => p.IsDeleted == false);
            #endregion STK ProductStkUnit
            #endregion STK
            #region eTraining
            #region eTraining Branch            
            modelBuilder.Entity<Branch>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Branch>().HasIndex(p => p.Code);
            modelBuilder.Entity<Branch>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Branch>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Branch>().Property(p => p.Name).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Branch>().Property(p => p.BranchType).HasConversion(type => type.Value, value => BranchTypeEnum.FromValue(value));
            #endregion eTraining Branch
            #region eTraining Classroom            
            modelBuilder.Entity<Classroom>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Classroom>().HasIndex(p => p.Code);
            modelBuilder.Entity<Classroom>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Classroom>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Classroom>().Property(p => p.Name).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Classroom>().Property(p => p.ClassroomType).HasConversion(type => type.Value, value => ClassroomTypeEnum.FromValue(value));
            #endregion eTraining Classroom
            #region eTraining Course            
            modelBuilder.Entity<Course>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Course>().HasIndex(p => p.Code);
            modelBuilder.Entity<Course>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Course>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Course>().Property(p => p.Name).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Course>().Property(p => p.CourseType).HasConversion(type => type.Value, value => CourseTypeEnum.FromValue(value));
            #endregion eTraining Course
            #region eTraining Participant            
            modelBuilder.Entity<Participant>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Participant>().HasIndex(p => p.Code);
            modelBuilder.Entity<Participant>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Participant>().Property(p => p.Code     ).HasColumnType("varchar(50)");
            modelBuilder.Entity<Participant>().Property(p => p.FirstName).HasColumnType("varchar(100)");
            modelBuilder.Entity<Participant>().Property(p => p.LastName ).HasColumnType("varchar(100)");
            //modelBuilder.Entity<Participant>().Property(p => p.ParticipantType).HasConversion(type => type.Value, value => ParticipantTypeEnum.FromValue(value));
            #endregion eTraining Participant
            #region eTraining Partner            
            modelBuilder.Entity<Partner>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Partner>().HasIndex(p => p.Code);
            modelBuilder.Entity<Partner>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Partner>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Partner>().Property(p => p.Name).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Partner>().Property(p => p.PartnerType).HasConversion(type => type.Value, value => PartnerTypeEnum.FromValue(value));
            #endregion eTraining Partner
            #region eTraining Status            
            modelBuilder.Entity<Status>().HasKey(p => new { p.Ref });
            modelBuilder.Entity<Status>().HasIndex(p => p.Code);
            modelBuilder.Entity<Status>().HasQueryFilter(p => p.IsDeleted == false);

            modelBuilder.Entity<Status>().Property(p => p.Code).HasColumnType("varchar(50)");
            modelBuilder.Entity<Status>().Property(p => p.Name).HasColumnType("varchar(250)");
            //modelBuilder.Entity<Status>().Property(p => p.StatusType).HasConversion(type => type.Value, value => StatusTypeEnum.FromValue(value));
            #endregion eTraining Status

            #endregion eTraining
        }
        private void CreateConnecitonString(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        {
            if (httpContextAccessor.HttpContext is null) return;

            string? firmRef = httpContextAccessor.HttpContext.User.FindFirstValue("FirmRef");

            if (firmRef == null) return;

            //short firmRefSH = Convert.ToByte(firmRef);

            Firm? firm = context.PT_Firms.Where(p => p.Ref == Convert.ToInt16(firmRef)).FirstOrDefault(); // Guid.Parse(firmRef)

            if (firm == null) return;

            CreateConnecitonStringWithFirm(firm);

        }

        private void CreateConnecitonStringWithFirm(Firm firm)
        {
            var builder = WebApplication.CreateBuilder();
            string? cString = builder.Configuration.GetConnectionString("FirmSqlServer");

            if (cString is null) return;

            connectionString = cString
                .Replace("#SrvrName#", firm.DbServ)
                .Replace("#DtbsName#", firm.DbName)
                .Replace("#UserName#", firm.DbUser)
                .Replace("#PassWord#", firm.DbPass);

        }
    }
}
