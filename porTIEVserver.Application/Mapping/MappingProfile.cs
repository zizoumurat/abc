using AutoMapper;
using porTIEVserver.Application.Features.Admin.AppSets.Firms.CreateFirm;
using porTIEVserver.Application.Features.Admin.AppSets.Firms.UpdateFirm;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.CreateMenu;
using porTIEVserver.Application.Features.Admin.AppSets.Menus.UpdateMenu;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.CreateRole;
using porTIEVserver.Application.Features.Admin.AppSets.Roles.UpdateRole;
using porTIEVserver.Application.Features.Admin.AppSets.Users.CreateUser;
using porTIEVserver.Application.Features.Admin.AppSets.Users.UpdateUser;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.CreateBankBranch;
using porTIEVserver.Application.Features.Admin.ToolSets.BankBranchs.UpdateBankBranch;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.CreateBank;
using porTIEVserver.Application.Features.Admin.ToolSets.Banks.UpdateBank;
using porTIEVserver.Application.Features.Admin.ToolSets.Cities.CreateCity;
using porTIEVserver.Application.Features.Admin.ToolSets.Cities.UpdateCity;
using porTIEVserver.Application.Features.Admin.ToolSets.Countries.CreateCountry;
using porTIEVserver.Application.Features.Admin.ToolSets.Countries.UpdateCountry;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.CreateStkUnit;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnits.UpdateStkUnit;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.CreateStkUnitSet;
using porTIEVserver.Application.Features.Admin.ToolSets.StkUnitSets.UpdateStkUnitSet;
using porTIEVserver.Application.Features.eCargo.BizServices.CreateBizService;
using porTIEVserver.Application.Features.eCargo.BizServices.UpdateBizService;
using porTIEVserver.Application.Features.eCargo.CargoActions.CreateCargoAction;
using porTIEVserver.Application.Features.eCargo.CargoActions.UpdateCargoAction;
using porTIEVserver.Application.Features.eCargo.Cargos.CreateCargo;
using porTIEVserver.Application.Features.eCargo.Cargos.UpdateCargo;
using porTIEVserver.Application.Features.eCargo.Carriers.CreateCarrier;
using porTIEVserver.Application.Features.eCargo.Carriers.UpdateCarrier;
using porTIEVserver.Application.Features.eCargo.Offices.CreateOffice;
using porTIEVserver.Application.Features.eCargo.Offices.UpdateOffice;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.CreateContact;
using porTIEVserver.Application.Features.ERP.CRM.Contacts.UpdateContact;
using porTIEVserver.Application.Features.ERP.CRM.CrmActions.CreateCrmAction;
using porTIEVserver.Application.Features.ERP.CRM.CrmActions.UpdateCrmAction;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.CreateBankAccount;
using porTIEVserver.Application.Features.ERP.FIN.BankAccounts.UpdateBankAccount;
using porTIEVserver.Application.Features.ERP.FIN.Cashiers.CreateCashier;
using porTIEVserver.Application.Features.ERP.FIN.Cashiers.UpdateCashier;
using porTIEVserver.Application.Features.ERP.FIN.Customers.CreateCustomer;
using porTIEVserver.Application.Features.ERP.FIN.Customers.UpdateCustomer;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.CreateTrading;
using porTIEVserver.Application.Features.ERP.FIN.Tradings.UpdateTrading;
using porTIEVserver.Application.Features.ERP.HR.Personnels.CreatePersonnel;
using porTIEVserver.Application.Features.ERP.HR.Personnels.UpdatePersonnel;
using porTIEVserver.Application.Features.ERP.HR.Presences.CreatePresence;
using porTIEVserver.Application.Features.ERP.HR.Presences.UpdatePresence;
using porTIEVserver.Application.Features.ERP.STK.Products.CreateProduct;
using porTIEVserver.Application.Features.ERP.STK.Products.UpdateProduct;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.CreateProductStkUnit;
using porTIEVserver.Application.Features.ERP.STK.ProductStkUnits.UpdateProductStkUnit;
using porTIEVserver.Application.Features.eTraining.Branchs.CreateBranch;
using porTIEVserver.Application.Features.eTraining.Branchs.UpdateBranch;
using porTIEVserver.Application.Features.eTraining.Classrooms.CreateClassroom;
using porTIEVserver.Application.Features.eTraining.Classrooms.UpdateClassroom;
using porTIEVserver.Application.Features.eTraining.Courses.CreateCourse;
using porTIEVserver.Application.Features.eTraining.Courses.UpdateCourse;
using porTIEVserver.Application.Features.eTraining.Participants.CreateParticipant;
using porTIEVserver.Application.Features.eTraining.Participants.UpdateParticipant;
using porTIEVserver.Application.Features.eTraining.Partners.CreatePartner;
using porTIEVserver.Application.Features.eTraining.Partners.UpdatePartner;
using porTIEVserver.Application.Features.eTraining.Statues.CreateStatus;
using porTIEVserver.Application.Features.eTraining.Statues.UpdateStatus;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Entities.Admin.ToolSets;
using porTIEVserver.Domain.Entities.eBizService.eBizService;
using porTIEVserver.Domain.Entities.eCargo.eCargo;
using porTIEVserver.Domain.Entities.ERP.CRM;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Entities.ERP.HR;
using porTIEVserver.Domain.Entities.ERP.STK;
using porTIEVserver.Domain.Entities.eTraining;
using porTIEVserver.Domain.Enums;


namespace porTIEVserver.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Admin
            #region Admin User
            CreateMap<CreateUserCommand, AppUser>();
            CreateMap<UpdateUserCommand, AppUser>();
            #endregion Admin User            
            #region Admin Firm
            CreateMap<CreateFirmCommand, Firm>()
                .ForMember(member => member.CurrencyType, options => { options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue)); })
                .ForMember(member => member.FirmType    , options => { options.MapFrom(map =>     FirmTypeEnum.FromValue(map.FirmTypeValue    )); });
            CreateMap<UpdateFirmCommand, Firm>()
                .ForMember(member => member.CurrencyType, options => { options.MapFrom(map => CurrencyTypeEnum.FromValue(map.CurrencyTypeValue)); })
                .ForMember(member => member.FirmType    , options => { options.MapFrom(map =>     FirmTypeEnum.FromValue(map.FirmTypeValue    )); });
            #endregion Admin Firm
            #region Admin Role
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            #endregion Admin Role
            #region Admin Menu
            CreateMap<CreateMenuCommand, Menu>();
            CreateMap<UpdateMenuCommand, Menu>();
            #endregion Admin Menu
            #region Admin Tools
            #region Admin Tools Bank
            CreateMap<CreateBankCommand, Bank>();
            CreateMap<UpdateBankCommand, Bank>();
            #endregion Admin Tools Bank            
            #region Admin Tools BankBranch
            CreateMap<CreateBankBranchCommand, BankBranch>();
            CreateMap<UpdateBankBranchCommand, BankBranch>();
            #endregion Admin Tools BankBranch            
            #region Admin Tools City
            CreateMap<CreateCityCommand, City>();
            CreateMap<UpdateCityCommand, City>();
            #endregion Admin Tools City            
            #region Admin Tools Country
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<UpdateCountryCommand, Country>();
            #endregion Admin Tools Country
            #region Admin Tools StkUnit
            CreateMap<CreateStkUnitCommand, StkUnit>();
            CreateMap<UpdateStkUnitCommand, StkUnit>();
            #endregion Admin Tools StkUnit
            #region Admin Tools StkUnitSet
            CreateMap<CreateStkUnitSetCommand, StkUnitSet>();
            CreateMap<UpdateStkUnitSetCommand, StkUnitSet>();
            #endregion Admin Tools StkUnitSet
            #endregion Admin Tools
            #endregion Admin

            #region eBizService
            CreateMap<CreateBizServiceCommand, BizService>();
            CreateMap<UpdateBizServiceCommand, BizService>();
            #endregion eBizService

            #region eCargo
            #region eCargo CargoAction
            CreateMap<CreateCargoActionCommand, CargoAction>();
            CreateMap<UpdateCargoActionCommand, CargoAction>();
            #endregion eCargo CargoAction
            #region eCargo CargoAction
            CreateMap<CreateCargoActionCommand, CargoAction>();
            CreateMap<UpdateCargoActionCommand, CargoAction>();
            #endregion eCargo CargoAction
            #region eCargo CargoMain
            CreateMap<CreateCargoMainCommand, CargoMain>();
            CreateMap<UpdateCargoMainCommand, CargoMain>();
            #endregion eCargo CargoMain
            #region eCargo Carrier
            CreateMap<CreateCarrierCommand, Carrier>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            CreateMap<UpdateCarrierCommand, Carrier>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            #endregion eCargo Carrier
            #region eCargo Office
            CreateMap<CreateOfficeCommand   , Office>();
            CreateMap<UpdateOfficeCommand   , Office>();
            #endregion eCargo Office            
            
            #endregion eCargo

            #region CRM
            #region CRM Contact
            CreateMap<CreateContactCommand  , Contact>();
            CreateMap<UpdateContactCommand  , Contact>();
            #endregion CRM Contact
            #region CRM CrmAction
            CreateMap<CreateCrmActionCommand, CrmAction>();
            CreateMap<UpdateCrmActionCommand, CrmAction>();
            #endregion CRM CrmAction
            #endregion CRM 

            #region FIN
            #region FIN BankAccount
            CreateMap<CreateBankAccountCommand, BankAccount>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            CreateMap<UpdateBankAccountCommand, BankAccount>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            #endregion FIN BankAccount
            #region FIN Cashier
            CreateMap<CreateCashierCommand, Cashier>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue))); ;
            CreateMap<UpdateCashierCommand, Cashier>().ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue))); ;
            #endregion FIN Cashier
            #region FIN Customer
            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => CustomerTypeEnum.FromValue(src.CustomerTypeValue)))
                .ForMember(dest => dest.FirmType    , opt => opt.MapFrom(src =>     FirmTypeEnum.FromValue(src.FirmTypeValue    )))
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => CustomerTypeEnum.FromValue(src.CustomerTypeValue)))
                .ForMember(dest => dest.FirmType    , opt => opt.MapFrom(src =>     FirmTypeEnum.FromValue(src.FirmTypeValue    )))
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CurrencyTypeValue)));
            #endregion FIN Customer
            #region FIN Trading
            CreateMap<CreateTradingCommand, Trading>()
                .ForMember(dest => dest.TradingType     , opt => opt.MapFrom(src =>  TradingTypeEnum.FromValue(src.TradingTypeValue      )))
                .ForMember(dest => dest.DebitTraderType , opt => opt.MapFrom(src =>   TraderTypeEnum.FromValue(src.DebitTraderTypeValue  )))
                .ForMember(dest => dest.CreditTraderType, opt => opt.MapFrom(src =>   TraderTypeEnum.FromValue(src.CreditTraderTypeValue )))
                .ForMember(dest => dest.DebitCurrType   , opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.DebitCurrTypeValue    )))
                .ForMember(dest => dest.CreditCurrType  , opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CreditCurrTypeValue   )));
            CreateMap<UpdateTradingCommand, Trading>()
                .ForMember(dest => dest.TradingType     , opt => opt.MapFrom(src =>  TradingTypeEnum.FromValue(src.TradingTypeValue      )))
                .ForMember(dest => dest.DebitTraderType , opt => opt.MapFrom(src =>   TraderTypeEnum.FromValue(src.DebitTraderTypeValue  )))
                .ForMember(dest => dest.CreditTraderType, opt => opt.MapFrom(src =>   TraderTypeEnum.FromValue(src.CreditTraderTypeValue )))
                .ForMember(dest => dest.DebitCurrType   , opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.DebitCurrTypeValue    )))
                .ForMember(dest => dest.CreditCurrType  , opt => opt.MapFrom(src => CurrencyTypeEnum.FromValue(src.CreditCurrTypeValue   )));
            #endregion FIN Trading
            #endregion FIN

            #region HR
            #region HR Personnel
            CreateMap<CreatePersonnelCommand, Personnel>();
            CreateMap<UpdatePersonnelCommand, Personnel>();
            #endregion HR Personnel
            #region HR Presence
            CreateMap<CreatePresenceCommand, Presence>();
            CreateMap<UpdatePresenceCommand, Presence>();
            #endregion HR Presence
            #endregion HR 

            #region STK
            #region STK Product
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            #endregion STK Product
            #region STK ProductStkUnit
            CreateMap<CreateProductStkUnitCommand, ProductStkUnit>();
            CreateMap<UpdateProductStkUnitCommand, ProductStkUnit>();
            #endregion STK ProductStkUnit
            #endregion STK

            #region eTraining
            #region eTraining Branch
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<UpdateBranchCommand, Branch>();
            #endregion eTraining Branch
            #region eTraining Classroom
            CreateMap<CreateClassroomCommand, Classroom>();
            CreateMap<UpdateClassroomCommand, Classroom>();
            #endregion eTraining Classroom
            #region eTraining Course
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
            #endregion eTraining Course
            #region eTraining Participant
            CreateMap<CreateParticipantCommand, Participant>();
            CreateMap<UpdateParticipantCommand, Participant>();
            #endregion eTraining Participant
            #region eTraining Partner
            CreateMap<CreatePartnerCommand, Partner>();
            CreateMap<UpdatePartnerCommand, Partner>();
            #endregion eTraining Partner
            #region eTraining Status
            CreateMap<CreateStatusCommand, Status>();
            CreateMap<UpdateStatusCommand, Status>();
            #endregion eTraining Status
            #endregion eTraining
        }
    }
}
