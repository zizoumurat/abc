using Azure.Core;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using porTIEVserver.Application.Globals;
using porTIEVserver.Domain.Repositories.Admin;
using porTIEVserver.Domain.Entities.Admin.AppSets;
using porTIEVserver.Domain.Repositories.Admin.AppSets;
using porTIEVserver.Domain.Enums;
using System.Security.Policy;
using System.ComponentModel;

namespace porTIEVserver.WebAPI.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateTestFirmAndFirstUsers(WebApplication app)
        {
            using var scoped = app.Services.CreateScope();

            // First Users
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            // First Admin User
            AppUser? adminUser1 = userManager.Users.Where(p => p.IsAdmin == true).FirstOrDefault();
            AppUser? adminUser2 = userManager.Users.Where(p => p.UserName == Parameters.AdminUser_UserName).FirstOrDefault();

            if (adminUser1 is null && adminUser2 is null)
            {
                AppUser user = new()
                {
                    Ref             = 1,
                    UserName        = Parameters.AdminUser_UserName,
                    Email           = Parameters.AdminUser_Email,
                    FirstName       = Parameters.AdminUser_FirstName,
                    LastName        = Parameters.AdminUser_LastName,
                    ImgUrl          = Parameters.AdminUser_ImgUrl,
                    IsAdmin         = true,
                    IsDeleted       = false,
                    EmailConfirmed  = true,
                };
                userManager.CreateAsync(user, Parameters.AdminUser_Password).Wait();
                //UserRites(user, 1);
                userManager.UpdateAsync(user).Wait();
            }
            else if (adminUser1 is not null)
            {
                adminUser1.IsDeleted = false;
                //adminUser1.RiteRefs = UserRites(adminUser1);
                userManager.UpdateAsync(adminUser1).Wait();
            }

            // First Test USer
            AppUser? testUser = userManager.Users.Where(p => p.UserName == Parameters.TestUser_UserName).FirstOrDefault();

            if (testUser is null)
            {
                AppUser user = new()
                {
                    Ref             = 2,
                    UserName        = Parameters.TestUser_UserName,
                    Email           = Parameters.TestUser_Email,
                    FirstName       = Parameters.TestUser_FirstName,
                    LastName        = Parameters.TestUser_LastName,
                    ImgUrl          = Parameters.TestUser_ImgUrl,
                    IsAdmin         = false,
                    IsDeleted       = false,
                    EmailConfirmed  = true
                };
                userManager.CreateAsync(user, Parameters.TestUser_Password).Wait();
                //UserRites(user, 1);
                userManager.UpdateAsync(user).Wait();
            }
            else 
            {
                testUser.IsDeleted = false;
                //testUser.RiteRefs = UserRites(testUser);
                userManager.UpdateAsync(testUser).Wait();
            }

        }
    
        public static List<Rite> UserRites(AppUser user, int right)
        {
            int admin = user.UserName == Parameters.AdminUser_UserName ? 1 : 0;

            List<Rite> rites= new List<Rite>();

            #region
            Rite xRite = new Rite();
            
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1001, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1001	Ana Sayfa               */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1100, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * admin) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * admin) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1100	Admin İşlemleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1110, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * admin) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * admin) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1110	Kullanıcılar            */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1120, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * admin) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * admin) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1120	Firmalar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1130, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * admin) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * admin) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1130	Roller                  */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1140, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * admin) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * admin) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1140	Menuler                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1200, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1200	Genel Tanımlar          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1210, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1210	Stok Birimleri          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1220, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1220	Stok Birim Setleri      */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1230, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1230	Ülkeler                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1240, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1240	Şehirler                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1250, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1250	Bankalar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1260, BttnRef = (ButtonTypeEnum.CREATE * admin) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * admin) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * 1    ) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1260	Banka Şubeleri          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1300, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1300	Firma Tanımları         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1310, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1310	Personeller             */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1320, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1320	Kasalar                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1330, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1330	Banka Hesapları         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1340, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1340	Cariler                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1350, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1350	Stoklar                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1360, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1360	Fiyatlar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1400, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1400	Kurs İşlemleri          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1410, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1410	Sınıflar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1420, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1420	Kurslar                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1430, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1430	Katılımcılar            */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1440, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1440	Ortak Firmalar          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1450, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1450	Durum Kodları           */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1460, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1460	Raporlar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1500, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1500	Satış Öncesi            */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1510, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1510	Adaylar                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1520, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1520	Kişiler                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1530, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1530	Faaliyetler             */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1540, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1540	Teklifler               */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1600, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1600	Satış İşlemleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1610, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1610	Siparişler              */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1620, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1620	Sipariş Sevk            */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1630, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1630	Toplu Mal Ayırma        */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1640, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1640	Mal Teslim              */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1700, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1700	Satın alma İşlemleri    */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1710, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1710	Siparişler              */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1720, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1720	Mal Kabul               */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1730, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1730	Kalite kontrol          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1740, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1740	Kesin Kabul/Red         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1800, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1800	Satış Sonrası           */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1810, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1810	Sozlesmeler             */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1820, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1820	Bakımlar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1830, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1830	Görevler                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1900, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1900	Ambar İşlemleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1910, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1910	Ambar Transfer          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 1920, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 1920	Adres/Raf Değiştirme    */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2000, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2000	Sayım İşlemleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2010, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2010	Sayımlar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2020, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2020	Sayım Birleştirme       */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2030, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2030	Sayım Karşılaştırma     */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2040, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2040	Sayım Kesinleştirme     */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2100, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2100	Üretim İşlemleri        */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2110, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2110	Üretim Emri Başla/Bitir */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2120, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2120	Üretimde Harcananlar    */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2130, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2130	Üretilen Mallar         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2140, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2140	Hurdaya Ayırma          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2300, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2300	Personel İşlemleri      */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2310, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2310	Avans Talepleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2320, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2320	İzin Talepleri          */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2330, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2330	Masraf Girişleri        */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2340, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2340	Yoklama                 */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2400, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2400	Kargo İşlemleri         */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2410, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2410	Müşteriler              */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2420, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2420	Taşıyıcılar             */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2430, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2430	Kargolar                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2440, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2440	Tahsilatlar             */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2450, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2450	Ödemeler                */
            xRite = new Rite { AppUserRef = user.Ref, FirmRef = 1, RoleRef = 1, MenuRef = 2460, BttnRef = (ButtonTypeEnum.CREATE * right) + (ButtonTypeEnum.SELECT * right) + (ButtonTypeEnum.UPDATE * right) + (ButtonTypeEnum.DELETE * admin) + (ButtonTypeEnum.EXCEPT * right) + (ButtonTypeEnum.MIGRATE * admin) }; rites.Add(xRite);/* 2460	Raporlar                */
            #endregion

            return rites;

        }
    
    }
}

