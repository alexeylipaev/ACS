namespace ACS.DAL.Migrations
{
    using EF;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XMLData;

    internal sealed class Configuration : DbMigrationsConfiguration<ACSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ACSContext db)
        {
            Console.WriteLine("GenerateUserRepository");
            GenerateUserRepository(db);
            Console.WriteLine("GenerateDepartmentRepository");
            GenerateDepartmentRepository(db);
            Console.WriteLine("GeneratePostRepository");
            GeneratePostRepository(db);
            Console.WriteLine("GeneratePostUserСode1СRepository");
            GeneratePostUserСode1СRepository(db);
            Console.WriteLine("GenerateWorkHistoryRepository");
            GenerateWorkHistoryRepository(db);
            Console.WriteLine("GenerateTypeAccessRepository");
            GenerateTypeAccessRepository(db);
            Console.WriteLine("GenerateTypeRecordChancelleryRepository");
            GenerateTypeRecordChancelleryRepository(db);
        }

        /// <summary>
        /// заполнение базы данных пользователей
        /// </summary>
        static void GenerateUserRepository(ACSContext Context)
        {
            // var location = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //отфильтровали по актуальности
            //сгрупировали по кодфизлица
            //выбрали из каждой группы запись с самой новой датой принятия
            //т.к там самые свежие паспортные данные и фамилии
            //отсортировали по дате принятия и фамилии
            var query = from db in DataLoader1C.Data.Сотрудники
                        where db.Актуальность == "Да"
                        group db by db.КодФизЛицо into @group
                        from dataEmpl in @group
                        where XMLDataTypeConverter.GetDateTime(dataEmpl.Принят)
                        == @group.Max(dataEmpl => XMLDataTypeConverter.GetDateTime(dataEmpl.Принят))
                        orderby XMLDataTypeConverter.GetDateTime(dataEmpl.Принят), dataEmpl.ФИО
                        select dataEmpl;


            foreach (var dataUser in query)
            {
                string[] DataFullNameEmp = dataUser.ФИО.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DataUserInActiveDirectory dataUserAD = new DataUserInActiveDirectory();

                dataUserAD.SearchData(DataFullNameEmp[0], DataFullNameEmp[1]);

                Console.WriteLine(dataUserAD.SID.ToString().Length.ToString());
                var newDataUser = new User()
                {
                    
                    LName = DataFullNameEmp[0],
                    FName = DataFullNameEmp[1],
                    MName = DataFullNameEmp[2],
                    //FullName = dataUser.ФИО,
                    //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                    SID = dataUserAD.SID,
                    Guid1C = Guid.Parse(dataUser.КодФизЛицо),

                    Birthday = XMLDataTypeConverter.GetDateTime(dataUser.ДатаРождения),
                    //EMail = dataUserAD.Email,
                    //PersonnelNumber = Convert.ToInt32(dataUser.ТабельныйНомер),
                    PersonnelNumber = dataUser.ТабельныйНомер,

                    Passport = new UserPassport()
                    {
                        //паспортные данные
                        DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.ДокументДатаВыдачи),
                        IssuedBy = dataUser.ДокументКемВыдан,
                        Number = dataUser.ДокументНомер.ToString(),
                        Series = dataUser.ДокументСерия,
                        UnitCode = dataUser.ДокументКодПодразделения,
                    },

                    //s_AuthorID = 1,
                    //s_EditorID = 1,
                };

                //if (newDataUser.Passport == null)
                //{
                //    newDataUser.Passport = new UserPassport()
                //    {
                //        //паспортные данные
                //        DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.ДокументДатаВыдачи),
                //        IssuedBy = dataUser.ДокументКемВыдан,
                //        Number = dataUser.ДокументНомер.ToString(),
                //        Series = dataUser.ДокументСерия,
                //        UnitCode = dataUser.ДокументКодПодразделения,
                //    };
                //}
                //else
                //{
                //    //паспортные данные
                //    newDataUser.Passport.DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.ДокументДатаВыдачи);
                //    newDataUser.Passport.IssuedBy = dataUser.ДокументКемВыдан;
                //    newDataUser.Passport.Number = dataUser.ДокументНомер.ToString();
                //    newDataUser.Passport.Series = dataUser.ДокументСерия;
                //    newDataUser.Passport.UnitCode = dataUser.ДокументКодПодразделения;
                //}

                Context.Users.Add(newDataUser);

                Context.SaveChanges();
            }

        }

        /// <summary>
        /// заполнение базы данных отделов
        /// </summary>
        static void GenerateDepartmentRepository(ACSContext Context)
        {
            // var location = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //сортировка отделов по коду возрастания
            var query = from dataDeport in DataLoader1C.Data.ОрганизационнаяСтруктура
                        orderby dataDeport.Код
                        select dataDeport;

            foreach (var dataDepartment in query)
            {
                var department = new Department()
                {
                    Name = dataDepartment.Наименование,
                    Code1C = int.Parse(dataDepartment.Код),
                    IsDeleted = XMLDataTypeConverter.ToBoolean(dataDepartment.ПометкаУдаления),
                    Inactive = XMLDataTypeConverter.ToBoolean(dataDepartment.Неактивное),
                    s_AuthorID = 1,
                    s_EditorID = 1,
                };

                Context.Departments.Add(department);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Заполнение бд именами должностей
        /// </summary>
        public static void GeneratePostRepository(ACSContext Context)
        {

            //все должности
            var query = (from dataUser in DataLoader1C.Data.Сотрудники
                         from PostHistory in dataUser.КадроваяИстория
                         select PostHistory.Должность).Distinct();

            foreach (var namePost in query)
            {
                var post = new PostNameUser()
                {
                    Name = namePost,
                    s_AuthorID = 1,
                    s_EditorID = 1,
                };

                Context.PostUsers.Add(post);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Возращает код физлица обладалетя кода должности 1С
        /// </summary>
        /// <param name="codePost1C"></param>
        /// <returns></returns>
        static Guid? GetGuid1CUser(string codePost1C)
        {
            var result = (from dUser in DataLoader1C.Data.Сотрудники
                          where dUser.Код == codePost1C
                          select dUser.КодФизЛицо).Distinct().First();
            return Guid.Parse(result);
        }

        /// <summary>
        /// Заполнение бд код должности 1с и кому этот код пренадлежит
        /// </summary>
        static void GeneratePostUserСode1СRepository(ACSContext Context)
        {
            //все должности
            //var query = (from dUser in DataLoader1C.Data.Сотрудники
            //             select dUser.Код).Distinct();

            var query = from db in DataLoader1C.Data.Сотрудники
                        where db.Актуальность == "Да"
                        group db by db.Код into @group
                        from dataEmpl in @group
                        where XMLDataTypeConverter.GetDateTime(dataEmpl.Принят)
                        == @group.Max(dataEmpl => XMLDataTypeConverter.GetDateTime(dataEmpl.Принят))
                        orderby XMLDataTypeConverter.GetDateTime(dataEmpl.Принят), dataEmpl.ФИО
                        select dataEmpl;

            foreach (var empl in query)
            {
                Guid Guid1C;

                if (!Guid.TryParse(empl.КодФизЛицо, out Guid1C)) continue;

                User userWithGuid1C = Context.Users.First(u => u.Guid1C == Guid1C);

                if (userWithGuid1C == null) continue;

                int? Id = userWithGuid1C.Id;

                var postUserСode1С = new PostUserСode1С()
                {
                    CodePost1C = Guid.Parse(empl.Код),

                    User = userWithGuid1C,
                    s_AuthorID = 1,
                    s_EditorID = 1
                };

                Context.PostUserСode1С.Add(postUserСode1С);
                Context.SaveChanges();
            }
        }

        static DateTime? GetEndDateWorkHistory(СотрудникиСотрудник dUser, СотрудникиСотрудникЗаписьКадровойИстории wh)
        {
            var WHlist = dUser.КадроваяИстория.ToList();

            if (WHlist == null) return null;

            int indexLastElement = WHlist.Count - 1;

            int indexWH = dUser.КадроваяИстория.ToList().IndexOf(wh);

            if (indexLastElement == indexWH)
                return null;

            return XMLDataTypeConverter.GetDateTime(WHlist.ElementAt(indexWH + 1).Дата);
        }


        static void GenerateWorkHistoryRepository(ACSContext Context)
        {
            //все должности
            var query = (from dUser in DataLoader1C.Data.Сотрудники
                         from wh in dUser.КадроваяИстория
                         orderby wh.Дата
                         select new
                         {
                             КодПодразделения = wh.КодПодразделения,
                             Должность = wh.Должность,
                             КодФизЛицо = dUser.КодФизЛицо,
                             Код = Guid.Parse(dUser.Код),
                             ДатаНачала = wh.Дата,
                             ДатаОкончания = GetEndDateWorkHistory(dUser, wh),
                             Ставка = wh.Ставка
                         });

            foreach (var WorkHistory in query)
            {

                Department department = Context.Departments.First(d => d.Code1C == WorkHistory.КодПодразделения);
                if (department == null) continue;

                //КодДолжности1С
                PostUserСode1С PUC = Context.PostUserСode1С.First
                    (puc => puc.CodePost1C == WorkHistory.Код);

                if (PUC == null) continue;

                var wh = new WorkHistory()
                {

                    Department = department,
                    PostName = WorkHistory.Должность,
                    StartDate = XMLDataTypeConverter.GetDateTime(WorkHistory.ДатаНачала),
                    EndDate = WorkHistory.ДатаОкончания,
                    Rate = double.Parse(WorkHistory.Ставка),

                    PostUserСode1С = PUC,
                    s_AuthorID = 1,
                    s_EditorID = 1
                };

                //Context.PostUserСode1С.Add(postUserСode1С);
                Context.SaveChanges();
            }
        }
        static void GenerateTypeAccessRepository(ACSContext Context)
        {

            var tA1 = new TypeAccess()
            {
                Name = "Просмотр",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tA2 = new TypeAccess()
            {
                Name = "Редактирование",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tA3 = new TypeAccess()
            {
                Name = "Удаление",
                s_AuthorID = 1,
                s_EditorID = 1,
            };

            Context.TypeAccesses.AddRange(new List<TypeAccess>() { tA1, tA2, tA3 });
            Context.SaveChanges();

        }
        static void GenerateTypeRecordChancelleryRepository(ACSContext Context)
        {

            var tRC1 = new TypeRecordChancellery()
            {
                Name = "Входящая",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tRC2 = new TypeRecordChancellery()
            {
                Name = "Исходящая",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tRC3 = new TypeRecordChancellery()
            {
                Name = "Внутреняя",
                s_AuthorID = 1,
                s_EditorID = 1,
            };

            Context.TypeRecordChancelleries.AddRange(new List<TypeRecordChancellery>() { tRC1, tRC2, tRC3 });
            Context.SaveChanges();

        }
    }




}
